using System.Net;

namespace ProductionClientHub.Exceptions.ExceptionsBase;

public class NotFoundException : ProductClientHubException
{
    public NotFoundException(string errorMessage) : base(errorMessage)
    {
    }
    public override List<string> GetErrorMessages() => [Message];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
}