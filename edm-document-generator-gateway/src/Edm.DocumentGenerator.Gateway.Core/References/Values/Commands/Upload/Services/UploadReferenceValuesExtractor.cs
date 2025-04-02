using OfficeOpenXml;

using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Upload.Services.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Upload.Services;

internal static class UploadReferenceValuesExtractor
{
    private static readonly int StartRow = 2;

    private static readonly int IdColumn = 1;
    private static readonly int DisplayValueColumn = 2;
    private static readonly int DisplaySubValueColumn = 3;

    public static ExtractedUploadReferenceValue[] Extract(Stream fileStream)
    {
        using var package = new ExcelPackage();

        package.Load(fileStream);

        var worksheet = package.Workbook.Worksheets.FirstOrDefault();

        if (worksheet is null)
        {
            throw new ApplicationException("Excel worksheet not found.");
        }

        var endRow = worksheet.Dimension.End.Row;

        var result = new List<ExtractedUploadReferenceValue>();

        for (var i = StartRow; i <= endRow; i++)
        {
            var id = GetValue(worksheet.Cells[i, IdColumn]);

            var displayValue = GetRequiredValue(worksheet.Cells[i, DisplayValueColumn]);

            var subValue = GetValue(worksheet.Cells[i, DisplaySubValueColumn]);

            result.Add(new ExtractedUploadReferenceValue(id, displayValue, subValue));
        }

        return result.ToArray();
    }

    private static string GetRequiredValue(ExcelRange cell)
    {
        var result = GetValue(cell);

        if (string.IsNullOrWhiteSpace(result))
        {
            throw new ApplicationException("Excel cell is required.");
        }

        return result;
    }

    private static string? GetValue(ExcelRange cell)
    {
        var result = cell.Value?.ToString()?.Trim();

        return result;
    }
}
