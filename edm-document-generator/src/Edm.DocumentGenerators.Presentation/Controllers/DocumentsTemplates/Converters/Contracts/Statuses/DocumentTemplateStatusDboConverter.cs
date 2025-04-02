using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Statuses;

internal static class DocumentTemplateStatusDboConverter
{
    internal static DocumentTemplateStatusDto FromInternal(DocumentTemplateStatus status)
    {
        DocumentTemplateStatusDto result = status switch
        {
            DocumentTemplateStatus.Draft => DocumentTemplateStatusDto.Draft,
            DocumentTemplateStatus.ReadyForApprovalGraphCreation => DocumentTemplateStatusDto.ReadyForApprovalGraphCreation,
            DocumentTemplateStatus.ReadyForDocumentCreation => DocumentTemplateStatusDto.ReadyForDocumentCreation,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static DocumentTemplateStatus ToInternal(DocumentTemplateStatusDto type)
    {
        DocumentTemplateStatus result = type switch
        {
            DocumentTemplateStatusDto.Draft => DocumentTemplateStatus.Draft,
            DocumentTemplateStatusDto.ReadyForApprovalGraphCreation => DocumentTemplateStatus.ReadyForApprovalGraphCreation,
            DocumentTemplateStatusDto.ReadyForDocumentCreation => DocumentTemplateStatus.ReadyForDocumentCreation,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
