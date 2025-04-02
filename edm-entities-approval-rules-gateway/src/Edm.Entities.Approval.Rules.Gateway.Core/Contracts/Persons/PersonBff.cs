namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Persons;

public sealed class PersonBff
{
    public required string Id { get; init; }
    public required string MainInfo { get; set; }
    public required string AdditionalInfo { get; set; }
}
