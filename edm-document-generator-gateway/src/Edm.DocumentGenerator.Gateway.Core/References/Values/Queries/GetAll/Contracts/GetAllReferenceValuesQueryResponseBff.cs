using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetAll.Contracts;

public sealed record GetAllReferenceValuesQueryResponseBff
{
    public required ReferenceValueBff[] ReferenceValues { get; init; }
}
