using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Headings;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.DocumentCreated;

public sealed record DocumentCreatedAuditRecordInternal(
    AuditRecordHeadingInternal<DocumentDetailedInternal> Heading,
    AuditRecordChangeInternal<DocumentAttributeValueInternal>[] Change)
    : AuditChangeRecordInternal<DocumentDetailedInternal, AuditRecordChangeInternal<DocumentAttributeValueInternal>[]>(Heading, Change);
