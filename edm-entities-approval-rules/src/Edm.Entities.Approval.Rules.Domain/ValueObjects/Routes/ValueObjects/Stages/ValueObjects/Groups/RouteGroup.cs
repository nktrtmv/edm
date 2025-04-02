namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups;

public abstract class RouteGroup
{
    internal RouteGroup(string name)
    {
        Name = name;
    }

    public string Name { get; }

    protected string BaseToString()
    {
        return $"Type: {GetType().Name}, Name: {Name}";
    }
}
