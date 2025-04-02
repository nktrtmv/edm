using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Events;

public sealed class Events<TEventContext>
{
    public Events(EventsHandler[] handlers, TEventContext context)
    {
        Handlers = handlers;
        Context = context;
    }

    private EventsHandler[] Handlers { get; }

    public TEventContext Context { get; }

    public void Trigger<TEventArgs>(TEventArgs args)
    {
        EventsHandlerGeneric<TEventArgs>[] handlers = Handlers
            .OfType<EventsHandlerGeneric<TEventArgs>>()
            .ToArray();

        foreach (EventsHandlerGeneric<TEventArgs> handler in handlers)
        {
            handler.Handle(args);
        }
    }
}
