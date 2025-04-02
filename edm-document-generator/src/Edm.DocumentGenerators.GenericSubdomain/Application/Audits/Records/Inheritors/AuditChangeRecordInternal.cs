using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Headings;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.Inheritors;

public abstract record AuditChangeRecordInternal<T, TChange>(AuditRecordHeadingInternal<T> Heading, TChange Change) : AuditRecordInternal<T>(Heading);
