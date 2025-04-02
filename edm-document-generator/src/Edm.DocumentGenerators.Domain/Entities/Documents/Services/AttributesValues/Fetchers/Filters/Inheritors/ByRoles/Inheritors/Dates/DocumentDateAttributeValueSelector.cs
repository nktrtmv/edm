using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.Dates;

public sealed class DocumentDateAttributeValueSelector(DocumentAttributeDocumentRole role)
    : DocumentAttributeValueByRoleSelectorGeneric<DateDocumentAttributeValue, DocumentDateAttribute, UtcDateTime<DateDocumentAttributeValue>>(role);
