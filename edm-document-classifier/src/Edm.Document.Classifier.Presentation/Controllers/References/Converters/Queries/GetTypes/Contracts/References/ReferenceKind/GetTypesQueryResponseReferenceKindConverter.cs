using Edm.Document.Classifier.Application.DocumentReferences.Queries.GetTypes.Contracts.Types.ReferenceKind;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Queries.GetTypes.Contracts.References.ReferenceKind;

public static class GetTypesQueryResponseReferenceKindConverter
{
    internal static GetTypesQueryResponseReferenceKind FromInternal(DocumentReferenceKindInternal searchKind)
    {
        GetTypesQueryResponseReferenceKind result = searchKind switch
        {
            DocumentReferenceKindInternal.Employee => GetTypesQueryResponseReferenceKind.Employee,
            _ => GetTypesQueryResponseReferenceKind.None
        };

        return result;
    }
}
