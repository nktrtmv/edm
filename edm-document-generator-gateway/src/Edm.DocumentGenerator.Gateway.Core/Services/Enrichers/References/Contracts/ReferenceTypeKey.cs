namespace Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References.Contracts;

public sealed record ReferenceTypeKey(string ReferenceType, string TemplateId, List<ParentInfo>? Parents);
