using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData.Factories;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.ApprovalParticipantAttributes;

internal static class ApprovalParticipantAttributesMetadataIdsRestorer
{
    internal static void Restore(DocumentTemplateUpdateParameters parameters)
    {
        foreach (DocumentAttribute updatedAttribute in parameters.UpdatedAttributes)
        {
            DocumentAttribute? originalAttribute = parameters.OriginalAttributesById.GetValueOrDefault(updatedAttribute.Id);

            if (originalAttribute is not null)
            {
                Restore(updatedAttribute, originalAttribute);
            }
        }
    }

    private static void Restore(DocumentAttribute updatedAttribute, DocumentAttribute originalAttribute)
    {
        int originalMetadataId = originalAttribute.Data.ApprovalData.MetadataId;

        bool updatedIsParticipant = updatedAttribute.Data.ApprovalData.IsParticipant;

        DocumentAttributeApprovalData approvalData = DocumentAttributeApprovalDataFactory.CreateFrom(
            originalMetadataId,
            updatedIsParticipant);

        updatedAttribute.Data.SetApprovalData(approvalData);
    }
}
