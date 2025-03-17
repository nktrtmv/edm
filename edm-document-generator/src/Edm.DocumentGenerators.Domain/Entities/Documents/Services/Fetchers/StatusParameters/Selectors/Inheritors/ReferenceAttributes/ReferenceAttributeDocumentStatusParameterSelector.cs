using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Abstractions.ReferenceTypes;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.References;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Inheritors.ReferenceAttributes;

internal sealed class ReferenceAttributeDocumentStatusParameterSelector
    : DocumentStatusParameterReferenceTypeSelectorGeneric<ReferenceAttributeDocumentStatusParameter, Id<DocumentAttribute>>
{
    internal ReferenceAttributeDocumentStatusParameterSelector(DocumentStatusParameterKind kind) : base(kind)
    {
    }

    protected override Id<DocumentAttribute>? GetSingleValueOrDefault(ReferenceAttributeDocumentStatusParameter parameter)
    {
        return parameter.Values.SingleOrDefault();
    }

    protected override Id<DocumentAttribute>[] GetValues(ReferenceAttributeDocumentStatusParameter parameter)
    {
        return parameter.Values;
    }
}
