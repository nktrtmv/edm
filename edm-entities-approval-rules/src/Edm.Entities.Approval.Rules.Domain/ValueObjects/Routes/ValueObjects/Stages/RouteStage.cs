using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Types;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages;

public sealed class RouteStage
{
    internal RouteStage(string id, string name, RouteStageType type, RouteGroup[] groups)
    {
        Name = name;
        Type = type;
        Id = id;
        Groups = groups;
    }

    public string Id { get; }
    public string Name { get; }
    public RouteStageType Type { get; }
    public RouteGroup[] Groups { get; }

    public override string ToString()
    {
        string groups = string.Join<RouteGroup>(", ", Groups);

        return $"{{ Name: {Name}, Type: {Type}, Groups: [{groups}] }}";
    }
}
