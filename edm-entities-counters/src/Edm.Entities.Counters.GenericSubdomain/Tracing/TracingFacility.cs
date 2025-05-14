using Microsoft.Extensions.Logging;

namespace Edm.Entities.Counters.GenericSubdomain.Tracing;

public static class TracingFacility
{
    public static async Task<TResponse> TraceGrpc<TResponse, TRequest>(
        ILogger logger,
        string name,
        TRequest request,
        Func<Task<TResponse>> func,
        LogLevel logLevel = LogLevel.Information)
    {
        try
        {
            logger.Log(logLevel, "GRPC START: ⚪️ {Name}\n{@Request}", name, request);

            TResponse response = await func();

            logger.Log(logLevel, "GRPC END: {Name}\n{@Response}", name, response);

            return response;
        }
        catch (Exception e)
        {
            logger.LogError(e, "GRPC EXCEPTION: ❌ {Message} in {Name}\n{@Request}", e.Message, name, request);

            throw;
        }
    }
}
