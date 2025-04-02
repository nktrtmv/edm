namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Create;

public sealed record CreateCounterCommandExternal(string DomainId, string? EntityTypeId, string Name, int Value);
