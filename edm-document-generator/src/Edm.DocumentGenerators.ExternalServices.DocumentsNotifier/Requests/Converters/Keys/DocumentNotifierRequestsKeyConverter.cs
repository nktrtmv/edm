using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Documents.Notifiers.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Converters.Keys;

internal static class DocumentNotifierRequestsKeyConverter
{
    internal static DocumentNotifyCommandKey FromExternal(DocumentNotifierRequestExternal request)
    {
        var documentId = IdConverterTo.ToString(request.Document.Id);

        var result = new DocumentNotifyCommandKey
        {
            DocumentId = documentId
        };

        return result;
    }
}
