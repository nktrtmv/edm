namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendSelfSigned;

public sealed class SendSelfSignedSigningApplicationEvent : SigningApplicationEvent
{
    public static readonly SendSelfSignedSigningApplicationEvent Instance = new SendSelfSignedSigningApplicationEvent();

    private SendSelfSignedSigningApplicationEvent()
    {
    }
}
