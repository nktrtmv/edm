using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Statuses;

internal static class DocumentTemplateStatusDbConverter
{
    internal static DocumentTemplateStatusDb FromDomain(DocumentTemplateStatus type)
    {
        DocumentTemplateStatusDb result = type switch
        {
            DocumentTemplateStatus.Draft => DocumentTemplateStatusDb.Draft,
            DocumentTemplateStatus.ReadyForApprovalGraphCreation => DocumentTemplateStatusDb.ReadyForApprovalGraphCreation,
            DocumentTemplateStatus.ReadyForDocumentCreation => DocumentTemplateStatusDb.ReadyForDocumentCreation,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentTemplateStatus ToDomain(DocumentTemplateStatusDb type)
    {
        DocumentTemplateStatus result = type switch
        {
            DocumentTemplateStatusDb.Draft => DocumentTemplateStatus.Draft,
            DocumentTemplateStatusDb.ReadyForApprovalGraphCreation => DocumentTemplateStatus.ReadyForApprovalGraphCreation,
            DocumentTemplateStatusDb.ReadyForDocumentCreation => DocumentTemplateStatus.ReadyForDocumentCreation,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
