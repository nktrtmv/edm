using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.Classifications;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Contracts;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.CreateByClassification.Contracts.Classifications;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.CreateByClassification;

internal static class CreateByClassificationDocumentsCommandConverter
{
    internal static CreateByClassificationDocumentsCommandInternal ToInternal(CreateByClassificationDocumentsCommand command)
    {
        DocumentClassificationInternal classification =
            CreateByClassificationDocumentsCommandClassificationConverter.ToInternal(command.Classification);

        Id<UserInternal> currentUserId =
            IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        string domainId = DomainIdHelper.GetDomainIdOrSetDefault(DomainId.Contracts);
        var result = new CreateByClassificationDocumentsCommandInternal(domainId, classification, currentUserId);

        return result;
    }
}
