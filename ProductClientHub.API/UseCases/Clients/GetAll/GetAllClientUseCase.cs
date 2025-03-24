using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.UseCases.Clients.GetAll;

public class GetAllClientUseCase
{
    public ResponseAllClientsJson Execute()
    {
        var dbContext = new ProductClientHubDbContext();
        
        var clients = dbContext.Clients.ToList();

        return new ResponseAllClientsJson
        {
            Clients = clients.Select(client => new ResponseShortClientJson
            {
                Name = client.Name,
                UserId = client.Id,
            }).ToList()
        };
    }
}