using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.Statuses;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Converters;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments;

internal static class EntitiesApprovalWorkflowAssignmentBffConverter
{
    public static EntitiesApprovalWorkflowAssignmentBff[] FromExternal(
        EntitiesApprovalWorkflowAssignmentExternal[] assignments,
        DocumentConversionContext conversionContext)
    {
        var index = 1;

        var result = new List<EntitiesApprovalWorkflowAssignmentBff>();

        foreach (var assignment in assignments)
        {
            var executor = PersonBff.CreateNotEnriched(assignment.ExecutorId);

            conversionContext.Enricher.Add(executor);

            var status =
                EntitiesApprovalWorkflowAssignmentStatusBffConverter.FromExternal(assignment.Status);

            var completionDetails =
                NullableConverter.Convert(assignment.CompletionDetails, EntitiesApprovalWorkflowAssignmentCompletionDetailsBffConverter.FromExternal);

            PersonBff? author = null;

            if (assignment.AuthorId is not null)
            {
                author = PersonBff.CreateNotEnriched(assignment.AuthorId);
                conversionContext.Enricher.Add(author);
            }

            var tempParticipant = new EntitiesApprovalWorkflowAssignmentBff
            {
                Id = assignment.Id,
                Number = index,
                Executor = executor,
                Status = status,
                CreatedDate = assignment.CreatedDate,
                CompletionDetails = completionDetails,
                Author = author,
                IsFixed = assignment.IsFixed
            };

            result.Add(tempParticipant);

            index++;
        }

        return result.ToArray();
    }
}
