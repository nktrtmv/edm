using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes;

public sealed class Route
{
    internal Route(string name, RouteStage[] stages, DateTime updatedTime)
    {
        Name = name;
        Stages = stages;
        UpdatedTime = updatedTime;
    }

    public DateTime UpdatedTime { get; set; }
    public string Name { get; }
    public RouteStage[] Stages { get; }

    public override string ToString()
    {
        string stages = string.Join<RouteStage>(", ", Stages);

        return $"{{ Name: {Name}, Stages: [{stages}] }}";
    }
}
