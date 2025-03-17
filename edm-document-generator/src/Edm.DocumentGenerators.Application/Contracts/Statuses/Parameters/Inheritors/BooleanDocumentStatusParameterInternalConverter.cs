using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Booleans;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters.Inheritors;

internal static class BooleanDocumentStatusParameterInternalConverter
{
    internal static BooleanDocumentStatusParameterInternal FromDomain(DocumentStatusParameterKind kind, BooleanDocumentStatusParameter p)
    {
        var result = new BooleanDocumentStatusParameterInternal(kind, p.Value);

        return result;
    }

    internal static BooleanDocumentStatusParameter ToDomain(DocumentStatusParameterKind kind, BooleanDocumentStatusParameterInternal p)
    {
        var result = new BooleanDocumentStatusParameter(kind, p.Value);

        return result;
    }
}
