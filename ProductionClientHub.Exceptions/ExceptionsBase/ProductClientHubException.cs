using System.Net;

namespace ProductionClientHub.Exceptions.ExceptionsBase;

public abstract class ProductClientHubException : SystemException
{
    public ProductClientHubException(string errorMessage) : base(errorMessage)
    {
    }
    
    public abstract List<string> GetErrorMessages();
    public abstract HttpStatusCode GetStatusCode();
}