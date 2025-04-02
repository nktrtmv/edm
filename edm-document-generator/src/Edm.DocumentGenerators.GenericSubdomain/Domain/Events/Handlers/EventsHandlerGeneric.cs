namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

public abstract class EventsHandlerGeneric<TEventArgs> : EventsHandler
{
    public abstract void Handle(TEventArgs args);
}
