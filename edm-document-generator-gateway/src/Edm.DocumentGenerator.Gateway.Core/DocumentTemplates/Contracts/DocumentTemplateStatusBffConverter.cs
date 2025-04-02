using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts;

internal static class DocumentTemplateStatusBffConverter
{
    public static DocumentTemplateStatusDto ToDto(DocumentTemplateStatusBff source)
    {
        var result = source switch
        {
            DocumentTemplateStatusBff.Draft => DocumentTemplateStatusDto.Draft,
            DocumentTemplateStatusBff.ReadyForApprovalGraphCreation => DocumentTemplateStatusDto.ReadyForApprovalGraphCreation,
            DocumentTemplateStatusBff.ReadyForDocumentCreation => DocumentTemplateStatusDto.ReadyForDocumentCreation,
            _ => throw new ArgumentTypeOutOfRangeException(source)
        };

        return result;
    }

    public static DocumentTemplateStatusBff ToBff(DocumentTemplateStatusDto source)
    {
        var result = source switch
        {
            DocumentTemplateStatusDto.Draft => DocumentTemplateStatusBff.Draft,
            DocumentTemplateStatusDto.ReadyForApprovalGraphCreation => DocumentTemplateStatusBff.ReadyForApprovalGraphCreation,
            DocumentTemplateStatusDto.ReadyForDocumentCreation => DocumentTemplateStatusBff.ReadyForDocumentCreation,
            _ => throw new ArgumentTypeOutOfRangeException(source)
        };

        return result;
    }
}
