using Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsReferenceDetails.Contracts.Contracts.DocumentReferenceDetails;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.DocumentsStagesTypes;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsDetails.Converters.Queries.GetDocumentsReferenceDetails.Contracts.DocumentsReferenceDetails;

internal static class DocumentReferenceDetailsDtoConverter
{
    internal static DocumentReferenceDetailsDto FromInternal(DocumentReferenceDetailsInternal details)
    {
        var documentId = IdConverterTo.ToString(details.DocumentId);

        DocumentStageTypeDto stageType = DocumentStageTypeDtoConverter.FromInternal(details.StageType);

        var result = new DocumentReferenceDetailsDto
        {
            DocumentId = documentId,
            RegistrationNumber = details.RegistrationNumber,
            StageType = stageType
        };

        return result;
    }
}
