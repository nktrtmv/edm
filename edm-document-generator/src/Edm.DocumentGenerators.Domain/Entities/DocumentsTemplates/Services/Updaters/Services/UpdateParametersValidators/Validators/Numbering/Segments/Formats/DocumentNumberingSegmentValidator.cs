using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Numbering.Segments.Formats.Segments;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Numbering.Segments.Formats;

internal static class DocumentNumberingSegmentValidator
{
    internal static void ValidateFormat(DocumentNumberingSegment segment)
    {
        None _ = segment switch
        {
            DocumentDateNumberingSegment s => DocumentDateNumberingSegmentsFormatsValidator.Validate(s),
            DocumentCounterNumberingSegment s => DocumentCounterNumberingSegmentsFormatsValidator.Validate(s),
            DocumentConstantNumberingSegment => default,
            _ => throw new ArgumentTypeOutOfRangeException(segment)
        };
    }
}
