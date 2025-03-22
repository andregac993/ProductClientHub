using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductionClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public  class ClientsController : Controller
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestClientJson request)
    {
            var useCase = new RegisterClientUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
    
    [HttpGet]
    [Route("{userId}")]
    public IActionResult GetByUserId([FromRoute]Guid userId)
    {
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
    

}