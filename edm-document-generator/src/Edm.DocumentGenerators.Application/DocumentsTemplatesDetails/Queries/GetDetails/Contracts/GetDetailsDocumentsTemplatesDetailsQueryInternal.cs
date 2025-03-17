using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentsTemplatesDetails.Queries.GetDetails.Contracts;

public sealed record GetDetailsDocumentsTemplatesDetailsQueryInternal(string DomainId, Id<DocumentTemplateInternal>[] TemplatesIds)
    : IRequest<GetDetailsDocumentsTemplatesDetailsQueryInternalResponse>;
