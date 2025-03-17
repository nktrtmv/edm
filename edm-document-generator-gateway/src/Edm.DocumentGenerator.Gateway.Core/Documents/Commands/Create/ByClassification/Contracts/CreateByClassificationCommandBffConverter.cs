using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByClassification.Contracts;

internal static class CreateByClassificationCommandBffConverter
{
    internal static CreateByClassificationDocumentsCommand ToDto(CreateByClassificationCommandBff command, UserBff user)
    {
        var classification = new CreateByClassificationDocumentsCommandClassification
        {
            BusinessSegmentId = command.BusinessSegmentId,
            DocumentCategoryId = command.DocumentCategoryId,
            DocumentTypeId = command.DocumentTypeId,
            DocumentKindId = command.DocumentKindId
        };

        var result = new CreateByClassificationDocumentsCommand
        {
            Classification = classification,
            CurrentUserId = user.Id
        };

        return result;
    }
}
