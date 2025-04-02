namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups;

public abstract class RouteGroupInternal
{
    internal RouteGroupInternal(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
