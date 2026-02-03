using Microsoft.AspNetCore.Mvc;
using To_Do_Flip.Application.Service;
using To_Do_Flip.Contract;
using To_Do_Flip.Store.Model;

namespace To_Do_Flip.Controller;

[ApiController]
[Route("api/tasks")]
public class To_Do_Flip_Controller : ControllerBase
{
    private readonly To_Do_Flip_IService _to_Do_Flip_IService;
    public To_Do_Flip_Controller(To_Do_Flip_IService to_Do_Flip_IService)
    {
        _to_Do_Flip_IService = to_Do_Flip_IService;
    }

    [HttpGet]
    public async Task<ActionResult<List<To_Do_Flip_Response>>> Get()
    {
        var to_Do_Flip = await _to_Do_Flip_IService.GetAllTask();
        
        var response = to_Do_Flip.Select(t => new To_Do_Flip_Response(t.Id, t.Name, t.Description));
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<To_Do_Flip_Response>> CreateTask([FromBody] To_Do_Flip_Request request)
    {
        var (to_Do, error) = To_Do.Create(
            Guid.NewGuid(),
            request.Name,
            request.Description);
        
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }
        
        var taskId = await _to_Do_Flip_IService.CreateTask(to_Do);
        
        var response = new To_Do_Flip_Response(to_Do.Id, to_Do.Name, to_Do.Description);
        
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateTask(Guid id, [FromBody] To_Do_Flip_Request request)
    {
        var to_Do_Flip = await _to_Do_Flip_IService.UpdateTask(id, request.Name, request.Description);
        
        return Ok(to_Do_Flip);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteTask(Guid id)
    {
        var to_Do_Flip = await _to_Do_Flip_IService.DeleteTask(id);
        
        return Ok(to_Do_Flip);
    }
}