using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.AttributesChanges;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.AttributesChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.StatusChanges;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters;

internal static class DocumentUpdateParametersInternalConverter
{
    internal static DocumentUpdateParameters ToDomain(DocumentUpdateParametersInternal parameters, Document document)
    {
        DocumentStatusChange? statusChange = DocumentStatusChangeConverter.FromInternal(parameters, document);

        DocumentAttributesChange attributesChange = DocumentAttributesChangeConverter.FromInternal(parameters, document);

        DocumentUpdateParameters result = DocumentUpdateParametersFactory.Create(statusChange, attributesChange);

        return result;
    }
}
