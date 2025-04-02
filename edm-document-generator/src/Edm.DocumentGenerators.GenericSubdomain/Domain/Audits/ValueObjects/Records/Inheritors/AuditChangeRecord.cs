using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;

namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.Inheritors;

public abstract record AuditChangeRecord<T, TChange>(AuditRecordHeading<T> Heading, TChange Change) : AuditRecord<T>(Heading);
