using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Keys;

internal sealed record AttributesPermissionsEnricherKey(
    DocumentAttributeValueDetailedBff[] AttributesValues,
    DocumentDetailedDto Document,
    UserBff User,
    DocumentWorkflows Workflows);
