namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Chief;

public sealed class ChiefRouteGroup : RouteGroup
{
    private new const string Name = "Руководитель";

    public static readonly ChiefRouteGroup Instance = new ChiefRouteGroup();

    private ChiefRouteGroup() : base(Name)
    {
    }

    public override string ToString()
    {
        return $"{{ {BaseToString()} }}";
    }
}
