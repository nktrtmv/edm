using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses.Contracts.Commands;
using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses.Contracts.Queries;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

namespace Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses;

public sealed class UpdateDocumentsStatusesService(DocumentsService.DocumentsServiceClient documents)
{
    public async Task<GetDocumentsAllowedStatusesResponseBff> GetDocumentsAllowedStatuses(
        GetDocumentsAllowedStatusesQueryBff query,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var request = GetDocumentsAllowedStatusesQueryBffConverter.ToDto(query);

        var response = await documents.GetDocumentsAllowedStatusesAsync(request, cancellationToken: cancellationToken);

        var result = GetDocumentsAllowedStatusesResponseBffConverter.FromDto(response);

        return result;
    }

    public async Task<UpdateDocumentsResponseBff> Update(
        UpdateDocumentsStatusesCommandBff commandBff,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var query = UpdateDocumentsStatusesCommandBffConverter.ToDto(commandBff, user);

        var response = await documents.DocumentStatusBatchUpdateAsync(query, cancellationToken: cancellationToken);

        var result = UpdateDocumentsResponseBffConverter.FromDto(response);

        return result;
    }
}
