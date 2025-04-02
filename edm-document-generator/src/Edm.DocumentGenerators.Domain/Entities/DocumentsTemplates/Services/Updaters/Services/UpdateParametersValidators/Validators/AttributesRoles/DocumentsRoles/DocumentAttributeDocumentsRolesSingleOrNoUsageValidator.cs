using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.AttributesRoles.DocumentsRoles;

internal static class DocumentAttributeDocumentsRolesSingleOrNoUsageValidator
{
    private static readonly int[] SingleOrNoUsageDocumentsRoles =
        new[]
            {
                DocumentAttributeDocumentRole.DocumentName,
                DocumentAttributeDocumentRole.DocumentDate,
                DocumentAttributeDocumentRole.DocumentNumber,

                DocumentAttributeDocumentRole.DocumentRegistrationNumber,

                DocumentAttributeDocumentRole.DocumentAuthor,
                DocumentAttributeDocumentRole.DocumentClerk,
                DocumentAttributeDocumentRole.DocumentResponsible,

                DocumentAttributeDocumentRole.SigningType,
                DocumentAttributeDocumentRole.SigningPartySelf,
                DocumentAttributeDocumentRole.SigningPartyContractor,
                DocumentAttributeDocumentRole.SigningSignatory
            }.Cast<int>()
            .ToArray();

    internal static void Validate(DocumentAttribute[] attributes)
    {
        foreach (int singleOrNoUsageDocumentsRole in SingleOrNoUsageDocumentsRoles)
        {
            DocumentAttribute[] documentsRoleUsageCount = attributes.Where(a => a.Data.DocumentsRoles.Contains(singleOrNoUsageDocumentsRole)).ToArray();

            if (documentsRoleUsageCount.Length <= 1)
            {
                continue;
            }

            string? usages = string.Join(", ", documentsRoleUsageCount.Select(a => $"id: {a.Id} [{a.DisplayName}]"));

            throw new BusinessLogicApplicationException(
                $"{singleOrNoUsageDocumentsRole} shall be used at most once, but {documentsRoleUsageCount.Length} usages ({usages}) is found.");
        }
    }
}
