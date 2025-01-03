using ChatService.Models.Dto;
using ChatService.Services.Implementations;
using ChatService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatService.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
[Route("api/v1/messages")]
public class MessageController(MessageService messageService): ControllerBase
{

    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> UpdateMessage([FromRoute] int id, [FromBody] MessageDto chatDto)
    {
        await messageService.UpdateAsync(id, chatDto);
        return Ok();
    }

    [HttpGet("chat/{id:int}/page/{page:int}/page-size/{pageSize:int}")]
    public async Task<IActionResult> GetMessagesOfChatAsync([FromRoute] int id, [FromRoute] int page, [FromRoute] int pageSize)
    {
        var result = await messageService.GetMessagesOfChatAsync(id, page, pageSize);
        return Ok(result);
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteChat([FromRoute] int id)
    {
        await messageService.DeleteAsync(id);
        return Ok();
    } 
}