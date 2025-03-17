using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

namespace Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses.Contracts.Commands;

internal static class UpdateDocumentsStatusesCommandBffConverter
{
    public static DocumentStatusBatchUpdateCommand ToDto(UpdateDocumentsStatusesCommandBff bff, UserBff userBff)
    {
        var result = new DocumentStatusBatchUpdateCommand
        {
            DomainId = bff.DomainId,
            DocumentsIds = { bff.DocumentIds },
            NewStatusId = bff.NewStatusId,
            CurrentUserId = userBff.Id
        };

        return result;
    }
}
