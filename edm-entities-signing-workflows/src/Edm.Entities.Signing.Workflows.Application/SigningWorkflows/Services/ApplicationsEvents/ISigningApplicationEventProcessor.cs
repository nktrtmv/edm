using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents;

public interface ISigningApplicationEventProcessor
{
    Task Process(SigningApplicationEvent applicationEvent, SigningWorkflow workflow, CancellationToken cancellationToken);
}
