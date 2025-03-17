namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendDocumentsToEdx;

public sealed class SendDocumentsToEdxSigningApplicationEvent : SigningApplicationEvent
{
    public static readonly SendDocumentsToEdxSigningApplicationEvent Instance = new SendDocumentsToEdxSigningApplicationEvent();

    private SendDocumentsToEdxSigningApplicationEvent()
    {
    }
}
