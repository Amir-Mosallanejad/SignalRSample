using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Backend.Hubs;

namespace SignalRSample.Backend.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class ChatController(Chathub chathub) : ControllerBase
{
    [HttpPost]
    public IActionResult NewMessage([FromBody] string message)
    {
        chathub.SendMessage(message);
        return Ok();
    }

    // [HttpGet]
    // public ActionResult<string> GetConnectionId()
    // {
    //     try
    //     {
    //         string response = chathub.GetConnectionId;
    //
    //         return Ok(response);
    //
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         throw;
    //     }
    // }
}