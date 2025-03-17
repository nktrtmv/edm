using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes.Contracts;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes;

public sealed class GetTypesApprovalReferencesQueryService : ApprovalReferencesServiceBase
{
    public GetTypesApprovalReferencesQueryService(IApprovalReferencesClient references) : base(references)
    {
    }

    public async Task<GetTypesApprovalReferencesQueryResponseBff> GetTypes(GetTypesApprovalReferencesQueryBff query, CancellationToken cancellationToken)
    {
        var request = GetTypesApprovalReferencesQueryExternal.Instance;

        var response = await References.GetTypes(request, cancellationToken);

        var result = GetTypesApprovalReferencesQueryResponseBffConverter.FromExternal(response);

        return result;
    }
}
