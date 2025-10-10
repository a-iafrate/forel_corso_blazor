using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ForelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignalRTestController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public SignalRTestController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("send-test-message")]
        public async Task<IActionResult> SendTestMessage()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "SERVER", "Test SignalR message");
            return Ok(new { result = "Test message sent" });
        }
    }
}
