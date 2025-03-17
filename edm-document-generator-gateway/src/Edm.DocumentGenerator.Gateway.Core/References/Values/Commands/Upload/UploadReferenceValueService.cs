using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Upload.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Upload.Services;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Upload.Services.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Upload;

public sealed class UploadReferenceValueService(ReferencesService.ReferencesServiceClient documentReferenceClient)
{
    public async Task<UploadReferenceValueCommandResponseBff> Upload(
        UploadReferenceValuesCommandBff request,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var fileStream = request.File.OpenReadStream();

        ExtractedUploadReferenceValue[] extractedValues = UploadReferenceValuesExtractor.Extract(fileStream);

        BulkUpsertReferenceValue[] values = extractedValues.Select(ExtractedUploadReferenceValueConverter.ToDto).ToArray();

        if (values.Length == 0)
        {
            return UploadReferenceValueCommandResponseBff.Instance;
        }

        var command = new BulkUpsertReferenceValuesCommand
        {
            ReferenceType = request.ReferenceType,
            DomainId = request.DomainId,
            Values = { values },
            CurrentUserId = user.Id
        };

        await documentReferenceClient.BulkUpsertReferenceValuesAsync(command, cancellationToken: cancellationToken);

        return UploadReferenceValueCommandResponseBff.Instance;
    }
}
