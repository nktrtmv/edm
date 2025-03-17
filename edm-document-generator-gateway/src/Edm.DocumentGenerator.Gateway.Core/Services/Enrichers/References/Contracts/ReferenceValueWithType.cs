using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References.Contracts;

public record ReferenceValueWithType(ReferenceTypeKey Key, ReferenceTypeValueBff Value);
