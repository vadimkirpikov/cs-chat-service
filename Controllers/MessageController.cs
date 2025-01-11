using ChatService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatService.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = "Client")]
[Route("api/v1/messages")]
public class MessageController(IMessageService messageService): ControllerBase
{

    [HttpGet("chat/{id:int}/page/{page:int}/page-size/{pageSize:int}")]
    public async Task<IActionResult> GetMessagesOfChatAsync([FromRoute] int id, [FromRoute] int page, [FromRoute] int pageSize)
    {
        var result = await messageService.GetMessagesOfChatAsync(id, page, pageSize);
        return Ok(result);
    }
}