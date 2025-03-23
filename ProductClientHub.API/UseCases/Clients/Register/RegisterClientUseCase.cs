using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductionClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseClientJson Execute(RequestClientJson request)
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

        return new ResponseClientJson
        {
            Name = entity.Name,
            UserId = entity.Id,
        };
    }

    private void Validate(RequestClientJson request)
    {
        var validator = new RegisterClientValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errors);
        }
    }
}