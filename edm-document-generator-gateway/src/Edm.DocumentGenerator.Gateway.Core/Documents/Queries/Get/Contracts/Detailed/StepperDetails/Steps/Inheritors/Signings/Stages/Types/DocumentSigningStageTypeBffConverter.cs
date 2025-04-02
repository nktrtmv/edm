using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages.Types;

internal static class DocumentSigningStageTypeBffConverter
{
    internal static DocumentSigningStageTypeBff FromExternal(SigningWorkflowStageTypeExternal type)
    {
        var result = type switch
        {
            SigningWorkflowStageTypeExternal.Self => DocumentSigningStageTypeBff.Self,
            SigningWorkflowStageTypeExternal.Contractor => DocumentSigningStageTypeBff.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
