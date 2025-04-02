namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args.ValueObjects.Contexts;

public abstract class EventContext<TEventHost, TEventActor>
{
    protected EventContext(TEventHost host, Id<TEventActor> actorId)
    {
        Host = host;
        ActorId = actorId;
    }

    public TEventHost Host { get; }
    public Id<TEventActor> ActorId { get; }
}
