using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Validators;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate.Contracts.AttributesErrors;

internal static class DocumentAttributeErrorBffConverter
{
    internal static DocumentAttributeErrorBff ToBffObsolete(DocumentAttributeErrorDto error) // TODO: Remove when front will be ready
    {
        var result = new DocumentAttributeErrorBff
        {
            AttributeId = error.AttributeId,
            Error = error.Message
        };

        return result;
    }

    internal static DocumentAttributeError FromDto(DocumentAttributeErrorDto error)
    {
        var result = new DocumentAttributeError(error.AttributeId, error.Message);

        return result;
    }
}
