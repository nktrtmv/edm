using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.ValueObjects.Counters.Values;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Custom.ContractNumbers.Numberings;

internal static class DocumentNumberingFormatter
{
    internal static string? FormatNumber(DocumentNumberingSegment[] segments, CounterValue[] countersValues)
    {
        string?[] formattedSegments = segments.Select(s => Format(s, countersValues)).ToArray();

        if (formattedSegments.Any(s => s is null))
        {
            return null;
        }

        string result = string.Concat(segments.Select(s => Format(s, countersValues)));

        return result;
    }

    private static string? Format(DocumentNumberingSegment segment, CounterValue[] countersValues)
    {
        string? result = segment switch
        {
            DocumentConstantNumberingSegment s => FormatConstantNumberingSegment(s),
            DocumentCounterNumberingSegment s => FormatCounterNumberingSegment(s, countersValues),
            DocumentDateNumberingSegment s => FormatDateNumberingSegment(s),
            _ => throw new ArgumentTypeOutOfRangeException(segment)
        };

        return result;
    }

    private static string FormatConstantNumberingSegment(DocumentConstantNumberingSegment segment)
    {
        string result = segment.Value;

        return result;
    }

    private static string? FormatCounterNumberingSegment(DocumentCounterNumberingSegment segment, CounterValue[] countersValues)
    {
        CounterValue? segmentCounter = countersValues.SingleOrDefault(v => v.Id == segment.CounterId);

        if (segmentCounter is null)
        {
            return null;
        }

        int value = segmentCounter.Value;

        var result = value.ToString(segment.Data.Format);

        return result;
    }

    private static string FormatDateNumberingSegment(DocumentDateNumberingSegment segment)
    {
        DateTime value = DateTime.UtcNow;

        var result = value.ToString(segment.Data.Format);

        return result;
    }
}
