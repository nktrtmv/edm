using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentClerk.Contracts;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.UpdateBatch.DocumentClerk;

internal static class DocumentClerkBatchUpdateCommandConverter
{
    public static DocumentClerkBatchUpdateCommandInternal ToInternal(DocumentClerkBatchUpdateCommand command)
    {
        Id<DocumentInternal>[] documentIds = command.DocumentIds.Select(IdConverterFrom<DocumentInternal>.FromString).Distinct().ToArray();
        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        string domainId = DomainIdHelper.GetDomainIdOrSetDefault(command.DomainId);
        var result = new DocumentClerkBatchUpdateCommandInternal(domainId, documentIds, currentUserId, command.NewClerkId);

        return result;
    }
}
