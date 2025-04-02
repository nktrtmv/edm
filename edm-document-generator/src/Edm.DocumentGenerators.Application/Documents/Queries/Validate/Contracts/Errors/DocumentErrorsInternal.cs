using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesErrors;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts.Errors;

public sealed record DocumentErrorsInternal(string[] Errors, DocumentAttributeErrorInternal[] AttributesErrors);
