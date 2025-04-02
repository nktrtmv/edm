using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts.Values;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts;

public sealed class SearchValuesApprovalReferencesQueryResponseBff
{
    public required ApprovalReferenceValueBff[] Values { get; init; }
}
