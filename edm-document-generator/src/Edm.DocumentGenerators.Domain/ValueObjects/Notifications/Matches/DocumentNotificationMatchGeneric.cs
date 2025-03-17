namespace Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;

public abstract class DocumentNotificationMatchGeneric<TEventsArgs> : DocumentNotificationMatch
{
    public abstract bool IsMatched(TEventsArgs args);
}
