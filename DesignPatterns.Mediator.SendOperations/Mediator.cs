using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator.SendOperations
{
    public class Mediator : IMediator
    {
        Assembly _handlersAssembly;

        public Mediator(Assembly handlersAssembly)
        {
            _handlersAssembly = handlersAssembly;
        }

        public Task Send(IRequest request, CancellationToken cancellationToken = default)
        {
            // Buscar en el Assembly un tipo: IRequestHandler<IRequest>
            return Handle<Task, IRequest>(request, cancellationToken);
        }

        public Task<ResponseType> Send<ResponseType>(IRequest<ResponseType> request, CancellationToken cancellationToken = default)
        {
            // Buscar en el Assembly un tipo: IRequestHandler<IRequest<ResponseType>, ResponseType>>
            return Handle<Task<ResponseType>, IRequest<ResponseType>>(request, cancellationToken);
        }

        ReturnType Handle<ReturnType, RequestType>(RequestType request, CancellationToken cancellationToken)
        {
            ReturnType result = default;
            Type RequestHandlerType;
            Func<Type, bool> RequestHandlerGenericParametersCondition;

            if (typeof(ReturnType).IsGenericType)
            {
                RequestHandlerType = typeof(IRequestHandler<,>);
                RequestHandlerGenericParametersCondition = (i) =>
                    i.GetGenericArguments().Length == 2 &&
                    i.GetGenericArguments()[1] == typeof(ReturnType).GetGenericArguments()[0];
            }
            else
            {
                RequestHandlerType = typeof(IRequestHandler<>);
                RequestHandlerGenericParametersCondition = (i) =>
                    i.GetGenericArguments().Length == 1;
            }

            Type handler = _handlersAssembly.GetTypes()
                .Where(t => t.GetInterfaces()
                .Where(i => i.IsGenericType &&  // Cambiar directamente por Any
                            i.GetGenericTypeDefinition() == RequestHandlerType &&
                            i.GetGenericArguments()[0] == request.GetType() &&
                            RequestHandlerGenericParametersCondition(i)) // verificar si es necesario esta condicion
                .Any())
                .FirstOrDefault();

            if (handler != null)
            {
                var handlerInstance = Activator.CreateInstance(handler);
                result = (ReturnType)handler.GetMethod("Handle").Invoke(
                    handlerInstance, new object[] { request, cancellationToken });
            }
            else
            {
                throw new InvalidOperationException(string.Format(
                    "Error al crear instancia de {0}", request.GetType()));
            }

            return result;
        }
    }
}
