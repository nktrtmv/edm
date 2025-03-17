using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;

namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records;

public abstract record AuditRecord<T>(AuditRecordHeading<T> Heading);
