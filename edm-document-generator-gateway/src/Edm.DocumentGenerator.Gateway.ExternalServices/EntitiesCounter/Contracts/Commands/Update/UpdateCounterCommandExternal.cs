namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Update;

public sealed record UpdateCounterCommandExternal(string Id, string DomainId, string? EntityTypeId, string Name, int Value);
