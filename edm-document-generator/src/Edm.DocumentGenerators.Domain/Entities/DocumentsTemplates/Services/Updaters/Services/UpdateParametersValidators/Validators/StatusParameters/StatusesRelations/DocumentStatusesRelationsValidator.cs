using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.References;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.StatusParameters.StatusesRelations;

internal static class DocumentStatusesRelationsValidator
{
    public static void Validate(DocumentStatus status, DocumentStatus[] statuses, DocumentPrototype prototype)
    {
        DocumentStatusDocumentStatusParameter[] statusRelations = status.Parameters.OfType<DocumentStatusDocumentStatusParameter>().ToArray();

        ReferenceAttributeDocumentStatusParameter[] attributeRelations = status.Parameters.OfType<ReferenceAttributeDocumentStatusParameter>().ToArray();

        foreach (DocumentStatusDocumentStatusParameter statusRelation in statusRelations)
        {
            if (statusRelation.Value is null)
            {
                continue;
            }

            DocumentStatus? foundStatus = statuses.FirstOrDefault(s => s.Id == statusRelation.Value);

            if (foundStatus is null)
            {
                throw new BusinessLogicApplicationException(
                    $"Не найден статус ({statusRelation.Value}) на который ссылается параметр ({statusRelation.Kind}) в этапе {status.DisplayName} ({status.Id})");
            }
        }

        foreach (ReferenceAttributeDocumentStatusParameter attributeRelation in attributeRelations)
        {
            if (attributeRelation.Values.Length == 0)
            {
                continue;
            }

            foreach (Id<DocumentAttribute> attributeRelationValue in attributeRelation.Values)
            {
                DocumentAttribute? attribute = prototype.Attributes.FirstOrDefault(a => a.Id == attributeRelationValue);

                if (attribute is null)
                {
                    throw new BusinessLogicApplicationException(
                        $"Не найден атрибут ({attributeRelationValue}) на который ссылается параметр ({attributeRelation.Kind}) в этапе {status.DisplayName} ({status.Id})");
                }
            }
        }
    }
}
