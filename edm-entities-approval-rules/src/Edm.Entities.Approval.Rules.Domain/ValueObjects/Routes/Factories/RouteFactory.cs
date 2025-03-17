using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Factories;

public static class RouteFactory
{
    public static Route CreateNew(string name, DateTime updatedTime, RouteStage[] stages)
    {
        var result = new Route(name, stages, updatedTime);

        return result;
    }
}
