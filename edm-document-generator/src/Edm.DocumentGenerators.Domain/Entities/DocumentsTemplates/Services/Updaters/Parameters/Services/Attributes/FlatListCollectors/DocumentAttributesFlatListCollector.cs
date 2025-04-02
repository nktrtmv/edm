using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters.Services.Attributes.FlatListCollectors;

internal static class DocumentAttributesFlatListCollector
{
    internal static IEnumerable<DocumentAttribute> GetAll(DocumentAttribute[] attributes)
    {
        foreach (DocumentAttribute attribute in attributes)
        {
            yield return attribute;

            if (attribute is not DocumentTupleAttribute tupleAttribute)
            {
                continue;
            }

            IEnumerable<DocumentAttribute> innerAttributes = GetAll(tupleAttribute.InnerAttributes);

            foreach (DocumentAttribute innerAttribute in innerAttributes)
            {
                yield return innerAttribute;
            }
        }
    }
}
