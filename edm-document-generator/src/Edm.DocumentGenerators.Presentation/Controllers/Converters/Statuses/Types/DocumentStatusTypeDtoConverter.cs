using Edm.DocumentGenerators.Application.Contracts.Statuses.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses.Types;

internal static class DocumentStatusTypeDtoConverter
{
    internal static DocumentStatusTypeDto FromInternal(DocumentStatusTypeInternal type)
    {
        DocumentStatusTypeDto result = type switch
        {
            DocumentStatusTypeInternal.Initial => DocumentStatusTypeDto.Initial,
            DocumentStatusTypeInternal.Backlog => DocumentStatusTypeDto.Backlog,
            DocumentStatusTypeInternal.Simple => DocumentStatusTypeDto.Simple,
            DocumentStatusTypeInternal.Approval => DocumentStatusTypeDto.Approval,
            DocumentStatusTypeInternal.Signing => DocumentStatusTypeDto.Signing,
            DocumentStatusTypeInternal.Completed => DocumentStatusTypeDto.Completed,
            DocumentStatusTypeInternal.Cancelled => DocumentStatusTypeDto.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentStatusTypeInternal ToInternal(DocumentStatusTypeDto type)
    {
        DocumentStatusTypeInternal result = type switch
        {
            DocumentStatusTypeDto.Initial => DocumentStatusTypeInternal.Initial,
            DocumentStatusTypeDto.Backlog => DocumentStatusTypeInternal.Backlog,
            DocumentStatusTypeDto.Simple => DocumentStatusTypeInternal.Simple,
            DocumentStatusTypeDto.Approval => DocumentStatusTypeInternal.Approval,
            DocumentStatusTypeDto.Signing => DocumentStatusTypeInternal.Signing,
            DocumentStatusTypeDto.Completed => DocumentStatusTypeInternal.Completed,
            DocumentStatusTypeDto.Cancelled => DocumentStatusTypeInternal.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
