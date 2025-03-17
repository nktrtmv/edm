using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Briefs;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Audits;

public static class AuditInternalConverter<TInternal>
{
    public static AuditInternal<TInternal> FromDomain<T>(Audit<T> audit, Func<AuditRecord<T>, AuditRecordInternal<TInternal>>? converter = null)
    {
        AuditBriefInternal<TInternal> brief = AuditBriefInternalFromDomainConverter<TInternal>.FromDomain(audit.Brief);

        AuditRecordInternal<TInternal>[] records = converter == null
            ? Array.Empty<AuditRecordInternal<TInternal>>()
            : audit.Records.Select(converter).ToArray();

        var result = new AuditInternal<TInternal>(brief, records);

        return result;
    }
}
