using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.AttributeChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators;

internal static class DocumentUpdateParametersValidator
{
    internal static void Validate(DocumentUpdateParameters parameters, Document document)
    {
        if (parameters.AttributesChange is not null)
        {
            AttributesChangeValidator.Validate(parameters.AttributesChange);
        }

        if (parameters.StatusChange is not null)
        {
            StatusChangeValidator.Validate(parameters.StatusChange, document);
        }

        AttributesValuesValidator.Validate(parameters, document);
    }
}
