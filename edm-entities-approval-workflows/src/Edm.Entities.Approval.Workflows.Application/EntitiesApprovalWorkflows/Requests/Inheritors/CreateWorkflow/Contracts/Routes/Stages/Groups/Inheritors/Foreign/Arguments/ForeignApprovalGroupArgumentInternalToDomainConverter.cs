using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.Boolean;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.Date;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.Number;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.Reference;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.String;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign.Arguments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign.Arguments.Inheritors.Boolean;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign.Arguments.Inheritors.Date;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign.Arguments.Inheritors.Number;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign.Arguments.Inheritors.Reference;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign.Arguments.Inheritors.String;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.
    Arguments;

internal static class ForeignApprovalGroupArgumentInternalToDomainConverter
{
    internal static ForeignApprovalGroupArgument ToDomain(ForeignApprovalGroupArgumentInternal argument)
    {
        Id<ForeignApprovalGroupArgument> id =
            IdConverterFrom<ForeignApprovalGroupArgument>.From(argument.Id);

        ForeignApprovalGroupArgument result = argument switch
        {
            BooleanForeignApprovalGroupArgumentInternal a => ToBoolean(id, a),
            DateForeignApprovalGroupArgumentInternal a => ToDate(id, a),
            NumberForeignApprovalGroupArgumentInternal a => ToNumber(id, a),
            ReferenceForeignApprovalGroupArgumentInternal a => ToReference(id, a),
            StringForeignApprovalGroupArgumentInternal a => ToString(id, a),
            _ => throw new ArgumentTypeOutOfRangeException(argument)
        };

        return result;
    }

    private static ForeignApprovalGroupArgument ToBoolean(Id<ForeignApprovalGroupArgument> id, BooleanForeignApprovalGroupArgumentInternal argument)
    {
        bool[] value = argument.Value.ToArray();

        var result = new BooleanForeignApprovalGroupArgument(id, value);

        return result;
    }

    private static ForeignApprovalGroupArgument ToDate(Id<ForeignApprovalGroupArgument> id, DateForeignApprovalGroupArgumentInternal argument)
    {
        UtcDateTime<DateForeignApprovalGroupArgument>[] value =
            argument.Value.Select(UtcDateTimeConverterFrom<DateForeignApprovalGroupArgument>.From).ToArray();

        var result = new DateForeignApprovalGroupArgument(id, value);

        return result;
    }

    private static ForeignApprovalGroupArgument ToNumber(Id<ForeignApprovalGroupArgument> id, NumberForeignApprovalGroupArgumentInternal argument)
    {
        long[] value = argument.Value.ToArray();

        var result = new NumberForeignApprovalGroupArgument(id, value);

        return result;
    }

    private static ForeignApprovalGroupArgument ToReference(Id<ForeignApprovalGroupArgument> id, ReferenceForeignApprovalGroupArgumentInternal argument)
    {
        Id<ReferenceForeignApprovalGroupArgument>[] value =
            argument.Value.Select(IdConverterFrom<ReferenceForeignApprovalGroupArgument>.From).ToArray();

        var result = new ReferenceForeignApprovalGroupArgument(id, value);

        return result;
    }

    private static ForeignApprovalGroupArgument ToString(Id<ForeignApprovalGroupArgument> id, StringForeignApprovalGroupArgumentInternal argument)
    {
        string[] value = argument.Value.ToArray();

        var result = new StringForeignApprovalGroupArgument(id, value);

        return result;
    }
}
