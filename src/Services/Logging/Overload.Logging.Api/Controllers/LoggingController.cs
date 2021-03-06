﻿using Microsoft.AspNetCore.Mvc;
using Overload.EventBus;
using System.Threading.Tasks;
using global::Overload.Logging.Infrastructure.Events;

namespace Overload.Payment.Logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly IEventBus _eventBus;
        public LoggingController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        [HttpPost]
        public async Task<ActionResult> Log(string error)
        {
            var loggingEvent = new LoggingIntergrationEvent();
            await _eventBus.PublishAsync(loggingEvent);
            return Ok();
        }
    }
}