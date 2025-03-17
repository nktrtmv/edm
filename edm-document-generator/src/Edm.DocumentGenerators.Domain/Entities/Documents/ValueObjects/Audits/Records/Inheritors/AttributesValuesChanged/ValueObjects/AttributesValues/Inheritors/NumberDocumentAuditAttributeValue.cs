using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.
    Inheritors;

public sealed record NumberDocumentAuditAttributeValue(Id<DocumentAttribute> Id, Number<NumberDocumentAuditAttributeValue>[] Values)
    : DocumentAuditAttributeValueGeneric<Number<NumberDocumentAuditAttributeValue>>(Id, Values);
