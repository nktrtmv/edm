using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Helpers.Attributes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Helpers.Statuses.Collectors;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Helpers.Statuses.Validators;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Attributes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.AttributesRoles.DocumentsRoles;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.AttributesValuesValidators;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Backlogs;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Notifications;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Numbering;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.States;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.StatusParameters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.TransitionParameters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators;

internal static class DocumentTemplateUpdateParametersValidator
{
    internal static void Validate(DocumentTemplateUpdateParameters parameters)
    {
        DocumentPrototype prototype = parameters.UpdatedPrototype;
        DocumentAttribute[] updatedAttributes = parameters.UpdatedAttributes;
        Dictionary<Id<DocumentAttribute>, DocumentAttribute> originalAttributesById = parameters.OriginalAttributesById;

        DocumentAttributesAreDistinctValidator.Validate(updatedAttributes);
        DocumentAttributesHasDistinctSystemNamesValidator.Validate(updatedAttributes);
        DocumentAttributesPreserveTypeValidator.Validate(updatedAttributes, originalAttributesById);
        DocumentAttributesPreservePrecisionValidator.Validate(updatedAttributes, originalAttributesById);
        DocumentAttributesHasCorrectDefaultValues.Validate(updatedAttributes);

        DocumentAttributeDocumentsRolesSingleOrNoUsageValidator.Validate(updatedAttributes);

        DocumentStatus[] statuses = DocumentStatusesCollector.Collect(prototype.StatusTransitions);

        DocumentStatusesParametersValidator.Validate(statuses, prototype);

        DocumentTransitionParametersValidator.Validate(prototype.StatusTransitions);

        var attributeExistsValidator = new DocumentAttributeExistsValidator(updatedAttributes);
        var statusExistsValidator = new DocumentStatusExistsValidator(statuses);

        DocumentValidatorsValidator.Validate(
            prototype.Validators,
            attributeExistsValidator,
            statusExistsValidator);

        var statusTransitionExistsValidator = new DocumentStatusTransitionExistsValidator(prototype.StatusTransitions);

        DocumentNotificationsValidator.Validate(
            prototype.Notifications,
            attributeExistsValidator,
            statusTransitionExistsValidator);

        DocumentBacklogStatusValidator.Validate(statuses, prototype.StatusTransitions);

        DocumentNumberingValidator.Validate(prototype.Numbering);

        DocumentTemplateIsDeletedStateValidator.Validate(parameters.Template);
    }
}
