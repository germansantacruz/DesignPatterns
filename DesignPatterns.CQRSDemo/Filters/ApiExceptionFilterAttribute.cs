using DesignPatterns.CQRSDemo.Filters.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace DesignPatterns.CQRSDemo.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        readonly IDictionary<Type, IExceptionHandler> _exceptionHandlers;

        public ApiExceptionFilterAttribute(IDictionary<Type, IExceptionHandler> exceptionHandlers)
        {
            _exceptionHandlers = exceptionHandlers;
        }

        public override void OnException(ExceptionContext context)
        {
            Type exceptionType = context.Exception.GetType();

            if (_exceptionHandlers.ContainsKey(exceptionType))
            {
                _exceptionHandlers[exceptionType].Handle(context);
            }
            else
            {
                // Excepciones sin manejador
                new ExceptionHandlerBase().SetResult(context,
                    StatusCodes.Status500InternalServerError,
                    "Ha ocurrido un error al procesar la respuesta.");
            }

            // Buscar el manejador de la excepcion
            // Manejar la excepción

            base.OnException(context);
        }
    }
}
