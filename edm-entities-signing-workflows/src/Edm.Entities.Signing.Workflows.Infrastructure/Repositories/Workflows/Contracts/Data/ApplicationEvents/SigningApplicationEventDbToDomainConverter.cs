using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendContractorSigned;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendDocumentsToEdx;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendSelfSigned;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.Inheritors.SendWorkflowCompleted;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents;

internal static class SigningApplicationEventDbToDomainConverter
{
    internal static SigningApplicationEvent ToDomain(SigningApplicationEventDb applicationEvent)
    {
        SigningApplicationEvent result = applicationEvent.ValueCase switch
        {
            SigningApplicationEventDb.ValueOneofCase.AsSendDocumentsToEdx =>
                SendDocumentsToEdxSigningApplicationEvent.Instance,

            SigningApplicationEventDb.ValueOneofCase.AsSendSelfSigned =>
                SendSelfSignedSigningApplicationEvent.Instance,

            SigningApplicationEventDb.ValueOneofCase.AsSendContractorSigned =>
                SendContractorSignedSigningApplicationEvent.Instance,

            SigningApplicationEventDb.ValueOneofCase.AsSendSignEntityResult =>
                SendWorkflowCompletedSigningApplicationEventDbConverter.ToDomain(applicationEvent.AsSendSignEntityResult),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent.ValueCase)
        };

        return result;
    }
}
