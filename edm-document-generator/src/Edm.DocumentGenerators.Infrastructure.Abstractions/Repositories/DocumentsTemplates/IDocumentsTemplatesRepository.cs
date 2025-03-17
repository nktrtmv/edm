using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts.QueryParams;

namespace Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates;

public interface IDocumentsTemplatesRepository
{
    Task Upsert(DocumentTemplate template, CancellationToken cancellationToken);
    Task Delete(DocumentTemplate template, CancellationToken cancellationToken);
    Task<DocumentTemplate?> Get(DomainId domainId, Id<DocumentTemplate> templateId, CancellationToken cancellationToken);
    Task<DocumentTemplate> GetRequired(DomainId domainId, SystemName systemName, CancellationToken cancellationToken);
    Task<DocumentTemplate> GetRequired(DomainId domainId, Id<DocumentTemplate> templateId, CancellationToken cancellationToken);
    Task<DocumentTemplate[]> Search(DomainId domainId, GetAllDocumentsTemplatesQueryParams queryParams, CancellationToken cancellationToken);
    Task<DocumentTemplate[]> GetByIds(DomainId domainId, Id<DocumentTemplate>[] ids, CancellationToken cancellationToken);
    Task<Id<DocumentTemplate>[]> GetAllIds(DomainId domainId, CancellationToken cancellationToken);
}
