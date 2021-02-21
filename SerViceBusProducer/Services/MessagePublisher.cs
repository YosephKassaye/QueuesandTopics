using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerViceBusProducer.Services
{
    public class MessagePublisher : IMessagePublisher
    {
        //private readonly IQueueClient _queueClient;
        private readonly ITopicClient _topicClient;

        //public MessagePublisher(IQueueClient queueClient)
        //{
        //    _queueClient = queueClient;
        //}  
        public MessagePublisher(ITopicClient topicClient)
        {
            _topicClient = topicClient;
        }
        public Task Publish<T>(T obj)
        {
            //Take an object and serialize into string and publish
            var objectText = JsonConvert.SerializeObject(obj);
            var message = new Message(Encoding.UTF8.GetBytes(objectText));
            //return _queueClient.SendAsync(message);
            return _topicClient.SendAsync(message);
        }

        public Task Publish(string raw)
        {
            //Publish to queue or Topic
            var message = new Message(Encoding.UTF8.GetBytes(raw));
            //return _queueClient.SendAsync(message);
            return _topicClient.SendAsync(message);
        }
    }
}
