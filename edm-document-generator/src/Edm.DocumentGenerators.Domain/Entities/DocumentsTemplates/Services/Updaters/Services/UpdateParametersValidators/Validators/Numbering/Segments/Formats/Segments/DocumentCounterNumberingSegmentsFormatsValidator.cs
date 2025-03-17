using System.Text.RegularExpressions;

using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Numbering.Segments.Formats.Segments;

internal static partial class DocumentCounterNumberingSegmentsFormatsValidator
{
    internal static None Validate(DocumentCounterNumberingSegment segment)
    {
        string format = segment.Data.Format;

        if (!IntegerSegmentFormatRegex().IsMatch(format))
        {
            throw new ArgumentException($"Counter segment (id: {segment.Data.Id}) has invalid format: {format}. Digits count has to be between 1 and 10.");
        }

        return default;
    }

    [GeneratedRegex("^D([1-9]|10)?$", RegexOptions.Compiled)]
    private static partial Regex IntegerSegmentFormatRegex();
}
