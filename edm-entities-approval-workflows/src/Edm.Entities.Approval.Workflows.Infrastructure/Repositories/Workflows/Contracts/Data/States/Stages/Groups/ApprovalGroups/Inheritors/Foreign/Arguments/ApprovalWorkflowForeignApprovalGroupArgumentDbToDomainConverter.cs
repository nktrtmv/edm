using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments.Inheritors.Boolean;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments.Inheritors.Date;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments.Inheritors.Number;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments.Inheritors.Reference;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments.Inheritors.String;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Foreign.Arguments;

internal static class ApprovalWorkflowForeignApprovalGroupArgumentDbToDomainConverter
{
    internal static ForeignApprovalGroupArgument ToDomain(ApprovalWorkflowForeignApprovalGroupArgumentDb argument)
    {
        Id<ForeignApprovalGroupArgument> id =
            IdConverterFrom<ForeignApprovalGroupArgument>.FromString(argument.Id);

        ForeignApprovalGroupArgument result = argument.ValueCase switch
        {
            ApprovalWorkflowForeignApprovalGroupArgumentDb.ValueOneofCase.AsBoolean => ToBoolean(id, argument.AsBoolean),
            ApprovalWorkflowForeignApprovalGroupArgumentDb.ValueOneofCase.AsDate => ToDate(id, argument.AsDate),
            ApprovalWorkflowForeignApprovalGroupArgumentDb.ValueOneofCase.AsNumber => ToNumber(id, argument.AsNumber),
            ApprovalWorkflowForeignApprovalGroupArgumentDb.ValueOneofCase.AsReference => ToReference(id, argument.AsReference),
            ApprovalWorkflowForeignApprovalGroupArgumentDb.ValueOneofCase.AsString => ToString(id, argument.AsString),
            _ => throw new ArgumentTypeOutOfRangeException(argument.ValueCase)
        };

        return result;
    }

    private static ForeignApprovalGroupArgument ToBoolean(Id<ForeignApprovalGroupArgument> id, BooleanApprovalWorkflowForeignApprovalGroupArgumentDb argument)
    {
        bool[] value = argument.Value.ToArray();

        var result = new BooleanForeignApprovalGroupArgument(id, value);

        return result;
    }

    private static ForeignApprovalGroupArgument ToDate(Id<ForeignApprovalGroupArgument> id, DateApprovalWorkflowForeignApprovalGroupArgumentDb argument)
    {
        UtcDateTime<DateForeignApprovalGroupArgument>[] value =
            argument.Value.Select(UtcDateTimeConverterFrom<DateForeignApprovalGroupArgument>.FromTimestamp).ToArray();

        var result = new DateForeignApprovalGroupArgument(id, value);

        return result;
    }

    private static ForeignApprovalGroupArgument ToNumber(Id<ForeignApprovalGroupArgument> id, NumberApprovalWorkflowForeignApprovalGroupArgumentDb argument)
    {
        long[] value = argument.Value.ToArray();

        var result = new NumberForeignApprovalGroupArgument(id, value);

        return result;
    }

    private static ForeignApprovalGroupArgument ToReference(Id<ForeignApprovalGroupArgument> id, ReferenceApprovalWorkflowForeignApprovalGroupArgumentDb argument)
    {
        Id<ReferenceForeignApprovalGroupArgument>[] value =
            argument.Value.Select(IdConverterFrom<ReferenceForeignApprovalGroupArgument>.FromString).ToArray();

        var result = new ReferenceForeignApprovalGroupArgument(id, value);

        return result;
    }

    private static ForeignApprovalGroupArgument ToString(Id<ForeignApprovalGroupArgument> id, StringApprovalWorkflowForeignApprovalGroupArgumentDb argument)
    {
        string[] value = argument.Value.ToArray();

        var result = new StringForeignApprovalGroupArgument(id, value);

        return result;
    }
}
