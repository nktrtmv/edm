using Edm.Document.Classifier.ExternalServices.DocumentGenerators.Converters.DocumentsStagesTypes;
using Edm.Document.Classifier.ExternalServices.Documents.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Classifier.ExternalServices.DocumentGenerators.Converters;

public static class DocumentDetailsExConverter
{
    public static DocumentDetailsEx FromDto(DocumentReferenceDetailsDto details)
    {
        string stageType = DocumentStageTypeDtoConverter.FromDto(details.StageType);

        var result = new DocumentDetailsEx(details.DocumentId, details.RegistrationNumber, stageType);

        return result;
    }
}
