namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendContractorSigned;

public sealed class SendContractorSignedSigningApplicationEvent : SigningApplicationEvent
{
    public static readonly SendContractorSignedSigningApplicationEvent Instance = new SendContractorSignedSigningApplicationEvent();

    private SendContractorSignedSigningApplicationEvent()
    {
    }
}
