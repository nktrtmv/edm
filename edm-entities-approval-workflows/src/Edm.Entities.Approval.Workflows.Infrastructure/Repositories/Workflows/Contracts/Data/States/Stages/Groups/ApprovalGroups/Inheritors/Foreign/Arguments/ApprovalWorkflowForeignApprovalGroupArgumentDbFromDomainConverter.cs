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

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Foreign.Arguments;

internal static class ApprovalWorkflowForeignApprovalGroupArgumentDbFromDomainConverter
{
    internal static ApprovalWorkflowForeignApprovalGroupArgumentDb FromDomain(ForeignApprovalGroupArgument argument)
    {
        ApprovalWorkflowForeignApprovalGroupArgumentDb result = argument switch
        {
            BooleanForeignApprovalGroupArgument a => ToBoolean(a),
            DateForeignApprovalGroupArgument a => ToDate(a),
            NumberForeignApprovalGroupArgument a => ToNumber(a),
            ReferenceForeignApprovalGroupArgument a => ToReference(a),
            StringForeignApprovalGroupArgument a => ToString(a),
            _ => throw new ArgumentTypeOutOfRangeException(argument)
        };

        var id = IdConverterTo.ToString(argument.Id);

        result.Id = id;

        return result;
    }

    private static ApprovalWorkflowForeignApprovalGroupArgumentDb ToBoolean(BooleanForeignApprovalGroupArgument argument)
    {
        bool[] value = argument.Value.ToArray();

        var asBoolean = new BooleanApprovalWorkflowForeignApprovalGroupArgumentDb
        {
            Value = { value }
        };

        var result = new ApprovalWorkflowForeignApprovalGroupArgumentDb
        {
            AsBoolean = asBoolean
        };

        return result;
    }

    private static ApprovalWorkflowForeignApprovalGroupArgumentDb ToDate(DateForeignApprovalGroupArgument argument)
    {
        Timestamp[] value = argument.Value.Select(UtcDateTimeConverterTo.ToTimeStamp).ToArray();

        var asDate = new DateApprovalWorkflowForeignApprovalGroupArgumentDb
        {
            Value = { value }
        };

        var result = new ApprovalWorkflowForeignApprovalGroupArgumentDb
        {
            AsDate = asDate
        };

        return result;
    }

    private static ApprovalWorkflowForeignApprovalGroupArgumentDb ToNumber(NumberForeignApprovalGroupArgument argument)
    {
        long[] value = argument.Value.ToArray();

        var asNumber = new NumberApprovalWorkflowForeignApprovalGroupArgumentDb
        {
            Value = { value }
        };

        var result = new ApprovalWorkflowForeignApprovalGroupArgumentDb
        {
            AsNumber = asNumber
        };

        return result;
    }

    private static ApprovalWorkflowForeignApprovalGroupArgumentDb ToReference(ReferenceForeignApprovalGroupArgument argument)
    {
        string[] value = argument.Value.Select(IdConverterTo.ToString).ToArray();

        var asReference = new ReferenceApprovalWorkflowForeignApprovalGroupArgumentDb
        {
            Value = { value }
        };

        var result = new ApprovalWorkflowForeignApprovalGroupArgumentDb
        {
            AsReference = asReference
        };

        return result;
    }

    private static ApprovalWorkflowForeignApprovalGroupArgumentDb ToString(StringForeignApprovalGroupArgument argument)
    {
        string[] value = argument.Value.ToArray();

        var asString = new StringApprovalWorkflowForeignApprovalGroupArgumentDb
        {
            Value = { value }
        };

        var result = new ApprovalWorkflowForeignApprovalGroupArgumentDb
        {
            AsString = asString
        };

        return result;
    }
}
