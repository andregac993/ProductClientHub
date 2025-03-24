using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Infrastructure;
using ProductionClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Delete;

public class DeleteClientUseCase
{
    public void Execute(Guid clientId)
    {
        var dbContext =  new ProductClientHubDbContext();
        
        var deleteClient = dbContext.Clients.FirstOrDefault(client => client.Id == clientId);
        
        if (deleteClient is null)
            throw new NotFoundException("Cliente não encontrado.");

        dbContext.Clients.Remove(deleteClient);
        
        dbContext.SaveChanges();
    }
}