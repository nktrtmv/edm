using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Types;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages.Types;

internal static class DocumentSigningStageTypeInternalConverter
{
    internal static DocumentSigningStageTypeInternal FromExternal(SigningWorkflowStageTypeExternal type)
    {
        DocumentSigningStageTypeInternal result = type switch
        {
            SigningWorkflowStageTypeExternal.Self => DocumentSigningStageTypeInternal.Self,
            SigningWorkflowStageTypeExternal.Contractor => DocumentSigningStageTypeInternal.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
