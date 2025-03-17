using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details.Inheritors.Domestic;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details;

internal static class ApprovalGroupDetailsInternalConverter
{
    internal static ApprovalGroupDetailsInternal FromDto(ApprovalGroupDetailsDto details)
    {
        ApprovalGroupDetailsInternal result = details.DetailsCase switch
        {
            ApprovalGroupDetailsDto.DetailsOneofCase.AsDomestic =>
                DomesticApprovalGroupDetailsInternalConverter.FromDto(details.AsDomestic),

            _ => throw new ArgumentTypeOutOfRangeException(details)
        };

        return result;
    }

    internal static ApprovalGroupDetailsDto ToDto(ApprovalGroupDetailsInternal details)
    {
        ApprovalGroupDetailsDto result = details switch
        {
            DomesticApprovalGroupDetailsInternal d =>
                DomesticApprovalGroupDetailsInternalConverter.ToDto(d),

            _ => throw new ArgumentTypeOutOfRangeException(details)
        };

        return result;
    }
}
