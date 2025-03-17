using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Services.Collectors;

public static class DocumentAttributesCollector
{
    public static IEnumerable<DocumentAttribute> Collect(DocumentAttribute[] attributes)
    {
        foreach (DocumentAttribute attribute in attributes)
        {
            yield return attribute;

            if (attribute is not DocumentTupleAttribute tuple)
            {
                continue;
            }

            IEnumerable<DocumentAttribute> innerAttributes = Collect(tuple.InnerAttributes);

            foreach (DocumentAttribute innerAttribute in innerAttributes)
            {
                yield return innerAttribute;
            }
        }
    }
}
