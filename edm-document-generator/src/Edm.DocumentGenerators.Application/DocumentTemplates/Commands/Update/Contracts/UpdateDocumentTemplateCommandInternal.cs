using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Update.Contracts.Bare;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Update.Contracts;

public sealed record UpdateDocumentTemplateCommandInternal(DocumentTemplateBareInternal Template, Id<UserInternal> CurrentUserId) : IRequest;
