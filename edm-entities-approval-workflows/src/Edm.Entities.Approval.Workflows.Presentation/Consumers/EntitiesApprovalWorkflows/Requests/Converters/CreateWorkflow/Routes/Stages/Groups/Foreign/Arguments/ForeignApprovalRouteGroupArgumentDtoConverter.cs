using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.Boolean;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.Date;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.Number;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.Reference;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.String;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Groups.Foreign.
    Arguments;

internal static class ForeignApprovalRouteGroupArgumentDtoConverter
{
    internal static ForeignApprovalGroupArgumentInternal ToInternal(ForeignApprovalRouteGroupArgumentDto argument)
    {
        Id<ForeignApprovalGroupArgumentInternal> id =
            IdConverterFrom<ForeignApprovalGroupArgumentInternal>.FromString(argument.Id);

        ForeignApprovalGroupArgumentInternal result = argument.ValueCase switch
        {
            ForeignApprovalRouteGroupArgumentDto.ValueOneofCase.AsBoolean => ToBoolean(id, argument.AsBoolean),
            ForeignApprovalRouteGroupArgumentDto.ValueOneofCase.AsDate => ToDate(id, argument.AsDate),
            ForeignApprovalRouteGroupArgumentDto.ValueOneofCase.AsNumber => ToNumber(id, argument.AsNumber),
            ForeignApprovalRouteGroupArgumentDto.ValueOneofCase.AsReference => ToReference(id, argument.AsReference),
            ForeignApprovalRouteGroupArgumentDto.ValueOneofCase.AsString => ToString(id, argument.AsString),
            _ => throw new ArgumentTypeOutOfRangeException(argument.ValueCase)
        };

        return result;
    }

    private static ForeignApprovalGroupArgumentInternal ToBoolean(Id<ForeignApprovalGroupArgumentInternal> id, BooleanForeignApprovalRouteGroupArgumentDto argument)
    {
        bool[] values = argument.Values.ToArray();

        var result = new BooleanForeignApprovalGroupArgumentInternal(id, values);

        return result;
    }

    private static ForeignApprovalGroupArgumentInternal ToDate(Id<ForeignApprovalGroupArgumentInternal> id, DateForeignApprovalRouteGroupArgumentDto argument)
    {
        UtcDateTime<DateForeignApprovalGroupArgumentInternal>[] values =
            argument.Values.Select(UtcDateTimeConverterFrom<DateForeignApprovalGroupArgumentInternal>.FromTimestamp).ToArray();

        var result = new DateForeignApprovalGroupArgumentInternal(id, values);

        return result;
    }

    private static ForeignApprovalGroupArgumentInternal ToNumber(Id<ForeignApprovalGroupArgumentInternal> id, NumberForeignApprovalRouteGroupArgumentDto argument)
    {
        long[] values = argument.Values.ToArray();

        var result = new NumberForeignApprovalGroupArgumentInternal(id, values);

        return result;
    }

    private static ForeignApprovalGroupArgumentInternal ToReference(Id<ForeignApprovalGroupArgumentInternal> id, ReferenceForeignApprovalRouteGroupArgumentDto argument)
    {
        Id<ReferenceForeignApprovalGroupArgumentInternal>[] values =
            argument.Values.Select(IdConverterFrom<ReferenceForeignApprovalGroupArgumentInternal>.FromString).ToArray();

        var result = new ReferenceForeignApprovalGroupArgumentInternal(id, values);

        return result;
    }

    private static ForeignApprovalGroupArgumentInternal ToString(Id<ForeignApprovalGroupArgumentInternal> id, StringForeignApprovalRouteGroupArgumentDto argument)
    {
        string[] values = argument.Values.ToArray();

        var result = new StringForeignApprovalGroupArgumentInternal(id, values);

        return result;
    }
}
