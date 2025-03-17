namespace Edm.DocumentGenerators.GenericSubdomain.Domain.ApplicationEvents;

public abstract record ApplicationEventGeneric<TEventArgs>(TEventArgs Args) : ApplicationEvent;
