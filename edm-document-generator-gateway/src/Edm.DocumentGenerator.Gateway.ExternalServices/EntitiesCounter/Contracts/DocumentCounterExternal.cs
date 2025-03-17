namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts;

public sealed record DocumentCounterExternal(string Id, string EntityTypeId, string Name, int Value);
