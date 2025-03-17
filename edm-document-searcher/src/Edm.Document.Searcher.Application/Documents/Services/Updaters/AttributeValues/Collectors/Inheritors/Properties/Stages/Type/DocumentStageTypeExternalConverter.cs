using Edm.Document.Searcher.ExternalServices.Documents.Contracts.StagesTypes;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Properties.Stages.
    Type;

public static class DocumentStageTypeExternalConverter
{
    public static string ToDomain(DocumentStageTypeExternal stageType)
    {
        string result = stageType switch
        {
            DocumentStageTypeExternal.Draft => "Draft",
            DocumentStageTypeExternal.Backlog => "Backlog",
            DocumentStageTypeExternal.ApprovalPreparation => "ApprovalPreparation",
            DocumentStageTypeExternal.Approval => "Approval",
            DocumentStageTypeExternal.SigningPreparation => "SigningPreparation",
            DocumentStageTypeExternal.Signing => "Signing",
            DocumentStageTypeExternal.InEffect => "InEffect",
            DocumentStageTypeExternal.Cancelled => "Cancelled",
            _ => throw new ArgumentTypeOutOfRangeException(stageType)
        };

        return result;
    }
}
