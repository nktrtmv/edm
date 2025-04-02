using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Actions;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Actions.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Executors.ReplacePersons;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Executors;

public static class ApprovalRulesUpdateActionExecutor
{
    public static string? Execute(ApprovalRule rule, ApprovalRulesUpdateAction action, bool isDryRun)
    {
        try
        {
            ExecuteAction(rule, action);
        }
        catch (Exception e)
        {
            if (isDryRun)
            {
                return e.Message;
            }

            throw;
        }

        return null;
    }

    private static void ExecuteAction(ApprovalRule rule, ApprovalRulesUpdateAction updateAction)
    {
        _ = updateAction switch
        {
            ApprovalRulesReplacePersonAction replacePersonAction =>
                ApprovalRulesReplacePersonActionExecutor.ReplacePerson(rule, replacePersonAction),

            _ => throw new ArgumentTypeOutOfRangeException(updateAction)
        };
    }
}
