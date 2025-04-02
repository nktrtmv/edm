namespace Edm.DocumentGenerators.GenericSubdomain.Domain.ApplicationEvents;

public abstract record ApplicationEvent
{
    public override string ToString()
    {
        return GetType().Name;
    }
}
