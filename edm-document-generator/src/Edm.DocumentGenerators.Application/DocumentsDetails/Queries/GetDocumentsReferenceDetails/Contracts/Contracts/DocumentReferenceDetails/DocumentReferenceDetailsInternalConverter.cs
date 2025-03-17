using Edm.DocumentGenerators.Application.Contracts.DocumentsStagesTypes;
using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Services.Fetchers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsReferenceDetails.Contracts.Contracts.DocumentReferenceDetails;

internal static class DocumentReferenceDetailsInternalConverter
{
    internal static DocumentReferenceDetailsInternal FromDomain(Document document)
    {
        Id<DocumentInternal> documentId = IdConverterFrom<DocumentInternal>.From(document.Id);

        string registrationNumber =
            DocumentAttributeValueStringByRoleFetcher.FetchSingleOrDefaultValue(document, (int)DocumentAttributeDocumentRole.DocumentRegistrationNumber)!;

        DocumentStageTypeInternal stageType = DocumentStageTypeInternalConverter.FromDomain(document.StageType);

        var result = new DocumentReferenceDetailsInternal(documentId, registrationNumber, stageType);

        return result;
    }
}
