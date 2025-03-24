using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Delete;
using ProductClientHub.API.UseCases.Clients.GetAll;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.UpdateClientUseCase;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers;

[Route("api/clients")]
[ApiController]

public  class ClientsController : Controller
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestClientJson request)
    {
            var useCase = new RegisterClientUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

    [HttpPut]
    [Route("{clientId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid clientId, [FromBody] RequestClientJson request)
    {

        var useCase = new UpdateClientUseCase();
        
        useCase.Execute(clientId, request);
        
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllClientUseCase();
        
        var response = useCase.Execute();
        if (response.Clients.Count == 0)
            return NoContent();

        return Ok(response);
    }
    
    [HttpGet]
    [Route("{clientId}")]
    public IActionResult GetByUserId([FromRoute]Guid clientId)
    {
        return Ok();
    }
    
    [HttpDelete]
    [Route("{clientId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute]Guid clientId)
    {
        var useCase = new DeleteClientUseCase();
        
       useCase.Execute(clientId);
       return NoContent();
    }
}