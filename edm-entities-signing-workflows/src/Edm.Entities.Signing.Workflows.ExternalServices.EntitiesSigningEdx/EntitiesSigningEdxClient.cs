using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Converters.Commands.SendDocuments;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Tracing;

using Google.Protobuf;

using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx;

internal sealed class EntitiesSigningEdxClient(IMessageProducer<EntitiesSigningEdxClient> producer, ILogger<EntitiesSigningEdxClient> logger) : IEntitiesSigningEdxClient
{
    async Task IEntitiesSigningEdxClient.SendDocuments(SendSigningEdxDocumentsCommandExternal request, CancellationToken cancellationToken)
    {
        SigningEdxRequestKey key = SendSigningEdxDocumentsCommandConverter.ToKey(request);
        SigningEdxRequestValue value = SendSigningEdxDocumentsCommandConverter.ToValue(request);

        byte[]? byteKey = key.ToByteArray();
        byte[]? byteValue = value.ToByteArray();

        await TracingFacility.TraceKafkaProducer(
            logger,
            nameof(IEntitiesSigningEdxClient.SendDocuments),
            key,
            value,
            async () => await producer.ProduceAsync(byteKey, byteValue));
    }
}
