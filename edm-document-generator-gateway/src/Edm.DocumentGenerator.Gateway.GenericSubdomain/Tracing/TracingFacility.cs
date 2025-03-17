using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerator.Gateway.GenericSubdomain.Tracing;

public static class TracingFacility
{
    public static async Task<TResponse> TraceGrpc<TResponse, TRequest>(
        ILogger logger,
        string name,
        TRequest request,
        Func<Task<TResponse>> func)
    {
        try
        {
            logger.LogInformation("GRPC START: ⚪️ {Name:l} {@Request}.", name, request);

            var response = await func();

            logger.LogInformation("GRPC END: {Name:l} {@Response}.", name, response);

            return response;
        }
        catch (Exception e)
        {
            logger.LogError(e, "GRPC EXCEPTION: ❌ {Message:l} in {Name:l} {@Request}.", e.Message, name, request);

            throw;
        }
    }
}
