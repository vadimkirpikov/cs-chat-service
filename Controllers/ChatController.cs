using ChatService.Models.Dto;
using ChatService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatService.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
[Route("api/v1/chats")]
public class ChatController(IChatService chatService): ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateChat([FromBody] ChatDto chatDto)
    {
        await chatService.CreateAsync(chatDto);
        return Ok();
    }

    [HttpGet("user/{id:int}/page/{page:int}/page-size/{pageSize:int}")]
    public async Task<IActionResult> GetUserChats([FromRoute] int id, [FromRoute] int page, [FromRoute] int pageSize)
    {
        var result = await chatService.GetChatsOfUserAsync(id, page, pageSize);
        return Ok(result);
    }

    [HttpGet("user-1/{firstId:int}/user-2/{secondId:int}")]
    public async Task<IActionResult> GetChatOfTwoUsersAsync([FromRoute] int firstId, [FromRoute] int secondId)
    {
        var result = await chatService.GetChatOfBothUsersAsync(firstId, secondId);
        return Ok(result);
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteChat([FromRoute] int id)
    {
        await chatService.DeleteAsync(id);
        return Ok();
    }
}