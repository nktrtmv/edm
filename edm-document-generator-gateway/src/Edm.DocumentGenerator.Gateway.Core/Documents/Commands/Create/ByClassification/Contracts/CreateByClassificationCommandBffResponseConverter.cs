using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByClassification.Contracts;

internal static class CreateByClassificationCommandBffResponseConverter
{
    internal static CreateByClassificationCommandBffResponse FromDto(CreateByClassificationDocumentsCommandResponse response)
    {
        var result = new CreateByClassificationCommandBffResponse
        {
            Id = response.DocumentId
        };

        return result;
    }
}
