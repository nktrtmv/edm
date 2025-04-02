using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

namespace Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsClerks.Contracts.Commands;

internal static class UpdateDocumentsClerksCommandBffConverter
{
    public static DocumentClerkBatchUpdateCommand ToDto(UpdateDocumentsClerksCommandBff bff, UserBff userBff)
    {
        var result = new DocumentClerkBatchUpdateCommand
        {
            DomainId = bff.DomainId,
            DocumentIds = { bff.DocumentIds },
            NewClerkId = bff.NewClerkId,
            CurrentUserId = userBff.Id
        };

        return result;
    }
}
