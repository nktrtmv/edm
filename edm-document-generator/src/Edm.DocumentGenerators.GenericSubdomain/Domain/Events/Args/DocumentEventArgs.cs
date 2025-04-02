namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args;

public abstract record DocumentEventArgs<TEventContext>(TEventContext Context);
