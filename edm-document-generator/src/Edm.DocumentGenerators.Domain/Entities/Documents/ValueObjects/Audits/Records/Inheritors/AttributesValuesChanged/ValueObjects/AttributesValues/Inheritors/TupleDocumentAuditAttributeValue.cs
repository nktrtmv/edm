using
    Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Inheritors;

public sealed record TupleDocumentAuditAttributeValue(Id<DocumentAttribute> Id, DocumentTupleAuditAttributeInnerValue[] Values)
    : DocumentAuditAttributeValueGeneric<DocumentTupleAuditAttributeInnerValue>(Id, Values);
