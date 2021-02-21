using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerViceBusProducer.Services
{
    public interface IMessagePublisher
    {
        Task Publish<T>(T Obj);
        Task Publish(string raw);

    }
}
