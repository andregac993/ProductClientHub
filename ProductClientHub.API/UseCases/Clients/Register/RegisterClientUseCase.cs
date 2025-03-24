using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductionClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseShortClientJson Execute(RequestClientJson request)
    {
        Validate(request);

        var dbContext = new ProductClientHubDbContext();

        var entity = new Client
        {
            Email = request.Email,
            Name = request.Name,
        };
        
        dbContext.Clients.Add(entity);

        dbContext.SaveChanges();

        return new ResponseShortClientJson
        {
            Name = entity.Name,
            UserId = entity.Id,
        };
    }

    private void Validate(RequestClientJson request)
    {
        var validator = new RequestClientValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errors);
        }
    }
}