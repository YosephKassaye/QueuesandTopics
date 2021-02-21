using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SerViceBusProducer.Services;

namespace SerViceBusProducer.Controllers
{
    public class MessagingController : ControllerBase
    {

        private readonly IMessagePublisher _messagePublisher;

        public MessagingController(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }
        [HttpPost("publish/text")]
        public async Task<IActionResult> PublishText()
        {
            using var reader = new StreamReader(Request.Body);
            var bodyAsText = await reader.ReadToEndAsync();
            await _messagePublisher.Publish(bodyAsText);
            return Ok();
        }
    }
}
