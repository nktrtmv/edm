using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendContractorSigned;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendDocumentsToEdx;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendSelfSigned;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendWorkflowCompleted;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.Inheritors.SendWorkflowCompleted;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents;

internal static class SigningApplicationEventDbFromDomainConverter
{
    internal static SigningApplicationEventDb FromDomain(SigningApplicationEvent applicationEvent)
    {
        SigningApplicationEventDb result = applicationEvent switch
        {
            SendDocumentsToEdxSigningApplicationEvent => ToSendDocumentsToEdx(),
            SendSelfSignedSigningApplicationEvent => ToSendSelfSigned(),
            SendContractorSignedSigningApplicationEvent => ToSendContractorSigned(),
            SendWorkflowCompletedSigningApplicationEvent e => ToSendSignEntityResult(e),
            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        return result;
    }

    private static SigningApplicationEventDb ToSendDocumentsToEdx()
    {
        var asSendDocumentsToEdx = new SendDocumentsToEdxSigningApplicationEventDb();

        var result = new SigningApplicationEventDb
        {
            AsSendDocumentsToEdx = asSendDocumentsToEdx
        };

        return result;
    }

    private static SigningApplicationEventDb ToSendSelfSigned()
    {
        var asSendSelfSigned = new SendSelfSignedSigningApplicationEventDb();

        var result = new SigningApplicationEventDb
        {
            AsSendSelfSigned = asSendSelfSigned
        };

        return result;
    }

    private static SigningApplicationEventDb ToSendContractorSigned()
    {
        var asSendContractorSigned = new SendContractorSignedSigningApplicationEventDb();

        var result = new SigningApplicationEventDb
        {
            AsSendContractorSigned = asSendContractorSigned
        };

        return result;
    }

    private static SigningApplicationEventDb ToSendSignEntityResult(SendWorkflowCompletedSigningApplicationEvent applicationEvent)
    {
        SendWorkflowCompletedSigningApplicationEventDb asSendWorkflowCompleted =
            SendWorkflowCompletedSigningApplicationEventDbConverter.FromDomain(applicationEvent);

        var result = new SigningApplicationEventDb
        {
            AsSendSignEntityResult = asSendWorkflowCompleted
        };

        return result;
    }
}
