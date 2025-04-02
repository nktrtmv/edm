using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References;

public interface IApprovalReferencesClient
{
    Task<GetTypesApprovalReferencesQueryResponseExternal> GetTypes(GetTypesApprovalReferencesQueryExternal query, CancellationToken cancellationToken);
    Task<SearchValuesApprovalReferencesQueryResponseExternal> SearchValues(SearchValuesApprovalReferencesQueryExternal query, CancellationToken cancellationToken);
}
