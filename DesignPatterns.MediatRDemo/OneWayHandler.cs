using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.MediatRDemo
{
    public class OneWayHandler : AsyncRequestHandler<OneWay>
    {
        protected override Task Handle(OneWay request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Mensaje  OneWay...");
            return Task.CompletedTask;
        }
    }
}
