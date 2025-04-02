using System.Text.RegularExpressions;

using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Numbering.Segments.Formats.Segments;

internal static partial class DocumentDateNumberingSegmentsFormatsValidator
{
    internal static None Validate(DocumentDateNumberingSegment segment)
    {
        string format = segment.Data.Format;

        if (!DateSegmentFormatRegex().IsMatch(format))
        {
            throw new ArgumentException(
                $"DateTime segment (id: {segment.Data.Id}) has invalid format: {format}.\t" +
                $"Valid format can contain: 'dd', 'MM', 'yyyy', whitespaces and next separators: '\\', '/', '-', '–', '_', ',', '.', ':', '|'");
        }

        return default;
    }

    [GeneratedRegex("^(dd|MM|yyyy|[\\s\\/\\-\\.,:|\\\\–_])*$", RegexOptions.Compiled)]
    private static partial Regex DateSegmentFormatRegex();
}
