using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Strings;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters.Inheritors;

internal static class StringDocumentStatusParameterInternalConverter
{
    internal static StringDocumentStatusParameterInternal FromDomain(DocumentStatusParameterKind kind, StringDocumentStatusParameter p)
    {
        var result = new StringDocumentStatusParameterInternal(kind, p.Value);

        return result;
    }

    internal static StringDocumentStatusParameter ToDomain(DocumentStatusParameterKind kind, StringDocumentStatusParameterInternal p)
    {
        var result = new StringDocumentStatusParameter(kind, p.Value);

        return result;
    }
}
