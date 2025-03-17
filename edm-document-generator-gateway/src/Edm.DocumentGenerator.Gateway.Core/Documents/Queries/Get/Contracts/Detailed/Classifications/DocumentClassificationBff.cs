namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Classifications;

public sealed record DocumentClassificationBff(
    string BusinessSegment,
    string Category,
    string Type,
    string Kind);
