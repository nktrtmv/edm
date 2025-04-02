using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Types.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.GetReferencesTypes.Converters.ReferenceKind;

public static class ReferenceTypeBffReferenceKindConverter
{
    public static ReferenceTypeBffReferenceKind FromDto(GetTypesQueryResponseReferenceKind referenceKind)
    {
        var result = referenceKind switch
        {
            GetTypesQueryResponseReferenceKind.Employee => ReferenceTypeBffReferenceKind.Employee,
            _ => ReferenceTypeBffReferenceKind.None
        };

        return result;
    }
}
