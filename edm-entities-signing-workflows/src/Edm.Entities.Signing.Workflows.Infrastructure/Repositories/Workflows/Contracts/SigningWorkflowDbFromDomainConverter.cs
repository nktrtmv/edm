using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Stages;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Statuses;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Statuses;

using Google.Protobuf;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts;

internal static class SigningWorkflowDbFromDomainConverter
{
    internal static SigningWorkflowDb FromDomain(SigningWorkflow workflow)
    {
        var id = IdConverterTo.ToString(workflow.Id);

        var entityId = IdConverterTo.ToString(workflow.EntityId);

        var domainId = IdConverterTo.ToString(workflow.DomainId);

        string status = SigningStatusDbFromDomainConverter.FromDomain(workflow.State.Stages);

        var statusChangedAt = UtcDateTimeConverterTo.ToDateTime(workflow.State.StatusChangedAt);

        byte[] data = ToData(workflow);

        var concurrencyToken = ConcurrencyTokenConverterTo.ToDateTime(workflow.ConcurrencyToken);

        var result = new SigningWorkflowDb
        {
            Id = id,
            EntityId = entityId,
            DomainId = domainId,
            Status = status,
            StatusChangedAt = statusChangedAt,
            Data = data,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }

    private static byte[] ToData(SigningWorkflow workflow)
    {
        SigningStatusDb status = SigningStatusDbConverter.FromDomain(workflow.State.Status);

        SigningStageDb[] stages =
            workflow.State.Stages.Select(SigningStageDbConverter.FromDomain).ToArray();

        SigningParametersDb? parameters =
            NullableConverter.Convert(workflow.Parameters, SigningParametersDbConverter.FromDomain);

        SigningApplicationEventDb[] applicationEvents =
            workflow.ApplicationEvents.Select(SigningApplicationEventDbFromDomainConverter.FromDomain).ToArray();

        var data = new SigningWorkflowDataDb
        {
            Status = status,
            Stages = { stages },
            Parameters = parameters,
            ApplicationEvents = { applicationEvents }
        };

        byte[] result = data.ToByteArray();

        return result;
    }
}
