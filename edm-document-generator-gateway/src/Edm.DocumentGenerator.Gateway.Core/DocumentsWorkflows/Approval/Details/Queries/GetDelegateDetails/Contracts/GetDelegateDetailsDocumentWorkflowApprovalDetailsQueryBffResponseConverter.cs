using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetDelegateDetails.Contracts;

internal static class GetDelegateDetailsDocumentWorkflowApprovalDetailsQueryBffResponseConverter
{
    internal static GetDelegateDetailsDocumentWorkflowApprovalDetailsQueryBffResponse ToBff(
        string[] delegateFromExecutorsIds,
        ReferencesEnricher enricher)
    {
        PersonBff[] delegateFromPersons = delegateFromExecutorsIds
            .Select(PersonBff.CreateNotEnriched)
            .ToArray();

        foreach (var delegateFromPerson in delegateFromPersons)
        {
            enricher.Add(delegateFromPerson);
        }

        var result = new GetDelegateDetailsDocumentWorkflowApprovalDetailsQueryBffResponse
        {
            DelegateFromPersons = delegateFromPersons
        };

        return result;
    }
}
