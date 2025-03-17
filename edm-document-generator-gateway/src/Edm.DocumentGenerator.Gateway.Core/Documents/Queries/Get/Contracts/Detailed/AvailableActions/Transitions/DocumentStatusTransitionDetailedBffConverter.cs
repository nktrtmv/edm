using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions.Parameters;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Transitions;

internal static class DocumentStatusTransitionDetailedBffConverter
{
    internal static DocumentStatusTransitionDetailedBff FromDto(DocumentStatusTransitionDetailedDto transition)
    {
        var status = DocumentStatusBffConverter.ToBff(transition.Status);

        DocumentStatusTransitionParameterBff[] parameters =
            transition.Parameters.Select(DocumentStatusTransitionParameterBffConverter.FromDto).ToArray();

        var result = new DocumentStatusTransitionDetailedBff
        {
            Status = status,
            Parameters = parameters,
            DisplayName = transition.DisplayName
        };

        return result;
    }
}
