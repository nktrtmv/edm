using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Abstractions.ReferenceTypes;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Strings;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Inheritors.Strings;

internal sealed class StringDocumentStatusParameterSelector : DocumentStatusParameterReferenceTypeSelectorGeneric<StringDocumentStatusParameter, string>
{
    internal StringDocumentStatusParameterSelector(DocumentStatusParameterKind kind) : base(kind)
    {
    }

    protected override string GetSingleValueOrDefault(StringDocumentStatusParameter parameter)
    {
        return parameter.Value;
    }
}
