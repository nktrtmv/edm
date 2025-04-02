using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Queries.GetAll.Contracts;

public sealed record GetAllDocumentsQueryInternal(
    Id<DocumentInternal>[] DocumentsIds,
    Id<UserInternal> CurrentUserId,
    bool SkipProcessing) : IRequest<DocumentDetailedInternal[]>;
