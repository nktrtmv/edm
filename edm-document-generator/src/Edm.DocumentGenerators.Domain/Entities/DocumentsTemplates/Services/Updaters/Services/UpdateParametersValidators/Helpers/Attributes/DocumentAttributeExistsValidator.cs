using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Helpers.Attributes;

internal sealed class DocumentAttributeExistsValidator
{
    public DocumentAttributeExistsValidator(DocumentAttribute[] attributes)
    {
        Attributes = attributes;
    }

    private DocumentAttribute[] Attributes { get; }

    internal bool Validate(Id<DocumentAttribute> attributeId)
    {
        bool attributeExists = Attributes.Any(a => a.Id == attributeId);

        if (attributeExists)
        {
            return true;
        }

        throw new BusinessLogicApplicationException($"Document template does not have attribute (id: {attributeId}).");
    }
}
