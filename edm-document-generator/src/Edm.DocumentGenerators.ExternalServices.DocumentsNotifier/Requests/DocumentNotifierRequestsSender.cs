using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Contracts;
using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Converters.Keys;
using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Converters.Values;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.Documents.Notifiers.Presentation.Abstractions;

using Google.Protobuf;

using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests;

internal sealed class DocumentNotifierRequestsSender : IDocumentNotifierRequestsSender
{
    public DocumentNotifierRequestsSender(ILogger<DocumentNotifierRequestsSender> logger, IMessageProducer<DocumentNotifierRequestsSender> producer)
    {
        Logger = logger;
        Producer = producer;
    }

    private ILogger<DocumentNotifierRequestsSender> Logger { get; }
    private IMessageProducer<DocumentNotifierRequestsSender> Producer { get; }

    public async Task Send(DocumentNotifierRequestExternal request, CancellationToken cancellationToken)
    {
        DocumentNotifyCommandKey key = DocumentNotifierRequestsKeyConverter.FromExternal(request);

        DocumentNotifyCommand value = DocumentNotifierRequestsValueConverter.FromExternal(request);

        byte[]? byteKey = key.ToByteArray();

        byte[]? byteValue = value.ToByteArray();

        await TracingFacility.TraceKafkaProducer(
            Logger,
            nameof(Send),
            key,
            value,
            async () => await Producer.ProduceAsync(byteKey, byteValue));
    }
}
