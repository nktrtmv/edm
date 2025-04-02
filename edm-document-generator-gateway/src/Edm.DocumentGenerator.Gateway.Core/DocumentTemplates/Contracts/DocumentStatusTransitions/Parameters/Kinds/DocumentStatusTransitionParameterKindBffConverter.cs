using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions.Parameters.Kinds;

internal static class DocumentStatusTransitionParameterKindBffConverter
{
    public static DocumentStatusTransitionParameterKindBff FromDto(DocumentStatusTransitionParameterKindDto dto)
    {
        var result = dto switch
        {
            DocumentStatusTransitionParameterKindDto.Comment => DocumentStatusTransitionParameterKindBff.Comment,
            DocumentStatusTransitionParameterKindDto.CommentWithAttachments => DocumentStatusTransitionParameterKindBff.CommentWithAttachments,
            _ => throw new ArgumentTypeOutOfRangeException(dto)
        };

        return result;
    }

    public static DocumentStatusTransitionParameterKindDto ToDto(DocumentStatusTransitionParameterKindBff kind)
    {
        var result = kind switch
        {
            DocumentStatusTransitionParameterKindBff.Comment => DocumentStatusTransitionParameterKindDto.Comment,
            DocumentStatusTransitionParameterKindBff.CommentWithAttachments => DocumentStatusTransitionParameterKindDto.CommentWithAttachments,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
