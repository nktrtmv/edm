using System.Text.Json.Serialization;

using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts.Actions.Inheritors;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts.Actions;

[JsonDerivedType(typeof(UpdateApprovalRulesCommandReplacePersonActionBff), "ReplacePerson")]
public abstract class UpdateApprovalRulesCommandActionBff
{
}
