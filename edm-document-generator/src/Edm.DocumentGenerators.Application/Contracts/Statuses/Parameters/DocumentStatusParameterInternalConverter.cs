using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Booleans;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.References;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Strings;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters;

internal static class DocumentStatusParameterInternalConverter
{
    internal static DocumentStatusParameterInternal FromDomain(DocumentStatusParameter parameter)
    {
        DocumentStatusParameterKind kind = parameter.Kind;

        DocumentStatusParameterInternal result = parameter switch
        {
            BooleanDocumentStatusParameter p => BooleanDocumentStatusParameterInternalConverter.FromDomain(kind, p),
            StringDocumentStatusParameter p => StringDocumentStatusParameterInternalConverter.FromDomain(kind, p),
            ReferenceAttributeDocumentStatusParameter p => ReferenceAttributeDocumentStatusParameterInternalConverter.FromDomain(kind, p),
            DocumentStatusDocumentStatusParameter p => DocumentStatusDocumentStatusParameterInternalConverter.FromDomain(kind, p),
            _ => throw new ArgumentTypeOutOfRangeException(parameter)
        };

        return result;
    }

    internal static DocumentStatusParameter ToDomain(DocumentStatusParameterInternal parameter)
    {
        DocumentStatusParameterKind kind = parameter.Kind;

        DocumentStatusParameter result = parameter switch
        {
            BooleanDocumentStatusParameterInternal p => BooleanDocumentStatusParameterInternalConverter.ToDomain(kind, p),
            StringDocumentStatusParameterInternal p => StringDocumentStatusParameterInternalConverter.ToDomain(kind, p),
            ReferenceAttributeDocumentStatusParameterInternal p => ReferenceAttributeDocumentStatusParameterInternalConverter.ToDomain(kind, p),
            DocumentStatusDocumentStatusParameterInternal p => DocumentStatusDocumentStatusParameterInternalConverter.ToDomain(kind, p),
            _ => throw new ArgumentTypeOutOfRangeException(parameter)
        };

        return result;
    }
}
