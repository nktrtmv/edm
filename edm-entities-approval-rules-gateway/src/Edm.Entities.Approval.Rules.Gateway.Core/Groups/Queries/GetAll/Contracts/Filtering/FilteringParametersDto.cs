namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts.Filtering;

public sealed class FilteringParametersDto
{
    public string? Search { get; set; }

    public string[]? ParticipantIds { get; set; }
}
