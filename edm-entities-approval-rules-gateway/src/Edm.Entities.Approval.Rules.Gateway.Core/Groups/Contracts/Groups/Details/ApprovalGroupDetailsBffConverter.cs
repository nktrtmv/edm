using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details;

internal static class ApprovalGroupDetailsBffConverter
{
    internal static ApprovalGroupDetailsBff FromDto(ApprovalGroupDetailsDto details, ApprovalEnrichersContext context)
    {
        ApprovalGroupDetailsBff result = details.DetailsCase switch
        {
            ApprovalGroupDetailsDto.DetailsOneofCase.AsDomestic =>
                DomesticApprovalGroupDetailsBffConverter.FromDto(details.AsDomestic, context),

            _ => throw new ArgumentTypeOutOfRangeException(details)
        };

        return result;
    }

    internal static ApprovalGroupDetailsDto ToDto(ApprovalGroupDetailsBff details)
    {
        var result = details switch
        {
            DomesticApprovalGroupDetailsBff d =>
                DomesticApprovalGroupDetailsBffConverter.ToDto(d),

            _ => throw new ArgumentTypeOutOfRangeException(details)
        };

        return result;
    }
}
