using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator
{
    public interface IMediator
    {
        void Publish(string message);
    }
}
