using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.
    Inheritors;

public sealed record BooleanDocumentAuditAttributeValue(Id<DocumentAttribute> Id, bool[] Values) : DocumentAuditAttributeValueGeneric<bool>(Id, Values);
