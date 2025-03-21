using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseClientJson Execute(ResponseClientJson request)
    {
        var validator = new RegisterClientValidator();
        var result = validator.Validate(request);
        return new ResponseClientJson();
    }
}