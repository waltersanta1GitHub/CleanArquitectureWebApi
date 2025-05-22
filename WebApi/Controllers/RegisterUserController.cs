using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisterUserController : ControllerBase
{
    private readonly RegistredUserService _service;

    public RegisterUserController(RegistredUserService registredUserService)
    {
        _service = registredUserService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRecords()
    {
       return Ok(await _service.GeAllAsync());
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetRegisterById(id);

        if (result is null) {
            return BadRequest();        
        }
        return Ok(result);

    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RegistredUserModelView model )
    {
        if (!ModelState.IsValid) {

            return StatusCode(StatusCodes.Status400BadRequest,ModelState);
        
        }
        await _service.CreateRegisterUser(model);       
        return Ok();
    }

}
