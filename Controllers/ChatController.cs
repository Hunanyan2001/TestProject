using Microsoft.AspNetCore.Mvc;

using TestProject.Interfaces;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private readonly IRabbitMqService _mqService;

        public ChatController(IRabbitMqService mqService)
        {
            _mqService = mqService;
        }

        [HttpPost("send")]
        public IActionResult SendMessage(string message)
        {
            _mqService.SendMessage(message);
            return Ok("Message sended");
        }

        [HttpGet("receive")]
        public async Task<IActionResult> ReceiveMessages()
        {
            var messages = await _mqService.ReceiveMessages();
            return Ok(messages);
        }
    }
}
