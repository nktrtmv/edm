using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Types;

internal static class DocumentStatusTypeBffConverter
{
    internal static DocumentStatusTypeBff FromDto(DocumentStatusTypeDto type)
    {
        var result = type switch
        {
            DocumentStatusTypeDto.Initial => DocumentStatusTypeBff.Initial,
            DocumentStatusTypeDto.Backlog => DocumentStatusTypeBff.Backlog,
            DocumentStatusTypeDto.Simple => DocumentStatusTypeBff.Simple,
            DocumentStatusTypeDto.Approval => DocumentStatusTypeBff.Approval,
            DocumentStatusTypeDto.Signing => DocumentStatusTypeBff.Signing,
            DocumentStatusTypeDto.Completed => DocumentStatusTypeBff.Completed,
            DocumentStatusTypeDto.Cancelled => DocumentStatusTypeBff.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentStatusTypeDto ToDto(DocumentStatusTypeBff type)
    {
        var result = type switch
        {
            DocumentStatusTypeBff.Initial => DocumentStatusTypeDto.Initial,
            DocumentStatusTypeBff.Backlog => DocumentStatusTypeDto.Backlog,
            DocumentStatusTypeBff.Simple => DocumentStatusTypeDto.Simple,
            DocumentStatusTypeBff.Approval => DocumentStatusTypeDto.Approval,
            DocumentStatusTypeBff.Signing => DocumentStatusTypeDto.Signing,
            DocumentStatusTypeBff.Completed => DocumentStatusTypeDto.Completed,
            DocumentStatusTypeBff.Cancelled => DocumentStatusTypeDto.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
