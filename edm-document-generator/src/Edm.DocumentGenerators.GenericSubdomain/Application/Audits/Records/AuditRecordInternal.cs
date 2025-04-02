using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Headings;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records;

public abstract record AuditRecordInternal<T>(AuditRecordHeadingInternal<T> Heading);
