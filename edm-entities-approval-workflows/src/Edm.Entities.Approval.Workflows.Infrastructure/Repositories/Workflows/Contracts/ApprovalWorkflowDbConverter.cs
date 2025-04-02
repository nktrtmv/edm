using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Statuses;

using Google.Protobuf;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts;

internal static class ApprovalWorkflowDbConverter
{
    internal static ApprovalWorkflowDb FromDomain(ApprovalWorkflow workflow)
    {
        var id = IdConverterTo.ToString(workflow.Id);

        var parameters = ApprovalWorkflowParametersDbConverter.FromDomain(workflow.Parameters);

        var state = ApprovalWorkflowStateDbConverter.FromDomain(workflow.State);

        ApprovalWorkflowApplicationEventDb[] applicationEvents =
            workflow.ApplicationEvents.Select(ApprovalWorkflowApplicationEventDbConverter.FromDomain).ToArray();

        var data = new ApprovalWorkflowDataDb
        {
            Parameters = parameters,
            State = state,
            ApplicationEvents = { applicationEvents }
        };

        var byteData = data.ToByteArray();

        var status = ApprovalWorkflowStatusDbConverter.ToString(workflow.Status);

        var createdDate = UtcDateTimeConverterTo.ToDateTime(workflow.Audit.CreatedAt);

        var updatedDate = UtcDateTimeConverterTo.ToDateTime(workflow.Audit.UpdatedAt);

        var actualizedDate = NullableConverter.Convert(workflow.State.ActualizedDate, UtcDateTimeConverterTo.ToDateTime);

        var result = new ApprovalWorkflowDb
        {
            Id = id,
            EntityId = parameters.Entity.Id,
            EntityDomainId = parameters.Entity.DomainId,
            Data = byteData,
            Status = status,
            CreatedDate = createdDate,
            UpdatedDate = updatedDate,
            ActualizedDate = actualizedDate
        };

        return result;
    }

    internal static ApprovalWorkflow ToDomain(ApprovalWorkflowDb workflow)
    {
        var data = ApprovalWorkflowDataDb.Parser.ParseFrom(workflow.Data);

        Id<ApprovalWorkflow> id = IdConverterFrom<ApprovalWorkflow>.FromString(workflow.Id);

        var parameters = ApprovalWorkflowParametersDbConverter.ToDomain(data.Parameters);

        var state = ApprovalWorkflowStateDbConverter.ToDomain(data.State);

        List<ApprovalWorkflowApplicationEvent> applicationEvents =
            data.ApplicationEvents.Select(ApprovalWorkflowApplicationEventDbConverter.ToDomain).ToList();

        Audit<ApprovalWorkflow> audit = AuditConverterFrom<ApprovalWorkflow>.From(workflow.CreatedDate, workflow.UpdatedDate);

        var result = ApprovalWorkflowFactory.CreateFromDb(id, parameters, state, applicationEvents, audit);

        return result;
    }
}
