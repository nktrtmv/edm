using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Abstractions.ValueTypes;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Booleans;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Inheritors.Boolean;

internal sealed class BooleanDocumentStatusParameterSelector : DocumentStatusParameterValueTypeSelectorGeneric<BooleanDocumentStatusParameter, bool>
{
    internal BooleanDocumentStatusParameterSelector(DocumentStatusParameterKind kind) : base(kind)
    {
    }

    protected override bool? GetValue(BooleanDocumentStatusParameter parameter)
    {
        return parameter.Value;
    }
}
