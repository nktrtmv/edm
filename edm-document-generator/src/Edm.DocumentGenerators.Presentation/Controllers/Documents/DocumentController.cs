using Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Contracts;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.ByTemplate.Contracts;
using Edm.DocumentGenerators.Application.Documents.Commands.Delete;
using Edm.DocumentGenerators.Application.Documents.Commands.ProcessAll.Contracts;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts;
using Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentClerk.Contracts;
using Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentStatus.Contracts;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.Application.Documents.Queries.GetAll.Contracts;
using Edm.DocumentGenerators.Application.Documents.Queries.GetAllowedStatuses.Contracts;
using Edm.DocumentGenerators.Application.Documents.Queries.GetShortestPathToCompletion.Contracts;
using Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.CreateByClassification;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.CreateByTemplate;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Update;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.UpdateBatch.DocumentClerk;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.UpdateBatch.DocumentStatus;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.GetAll;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.GetAllowedStatuses;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.GetShortestPathToCompletion;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Validate;

using Grpc.Core;

using MediatR;

using GetDocumentQueryResponseConverter = Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.GetDocumentQueryResponseConverter;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents;

internal sealed class DocumentController(ILogger<DocumentController> logger, IMediator mediator) : DocumentsService.DocumentsServiceBase
{
    public override async Task<CreateByClassificationDocumentsCommandResponse> CreateByClassification(
        CreateByClassificationDocumentsCommand command,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(CreateByClassification),
            command,
            async () =>
            {
                CreateByClassificationDocumentsCommandInternal? request = CreateByClassificationDocumentsCommandConverter.ToInternal(command);

                CreateByClassificationDocumentsCommandInternalResponse? response = await mediator.Send(request, context.CancellationToken);

                var result = new CreateByClassificationDocumentsCommandResponse { DocumentId = response.DocumentId };

                return result;
            });
    }

    public override async Task<CreateDocumentByTemplateIdCommandResponse> CreateByTemplateId(
        CreateDocumentByTemplateIdCommand command,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(CreateByTemplateId),
            command,
            async () =>
            {
                CreateDocumentByTemplateIdCommandInternal? request = CreateByTemplateIdDocumentsCommandConverter.ToInternal(command);

                CreateDocumentByTemplateIdCommandInternalResponse? response = await mediator.Send(request, context.CancellationToken);

                var result = new CreateDocumentByTemplateIdCommandResponse { DocumentId = response.DocumentId };

                return result;
            });
    }

    public override async Task<CreateByTemplateSystemName.Types.Response> CreateByTemplateSystemName(
        CreateByTemplateSystemName.Types.Command request,
        ServerCallContext context)
    {
        var command = new CreateDocumentByTemplateSystemNameCommandInternal(
            request.DomainId,
            request.SystemName,
            request.CurrentUserId);

        CreateDocumentByTemplateSystemNameCommandInternalResponse? response = await mediator.Send(command, context.CancellationToken);

        var result = new CreateByTemplateSystemName.Types.Response { DocumentId = response.DocumentId };

        return result;
    }

    public override async Task<DocumentClerkBatchUpdateCommandResponse> DocumentClerkBatchUpdate(DocumentClerkBatchUpdateCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(DocumentClerkBatchUpdate),
            request,
            async () =>
            {
                DocumentClerkBatchUpdateCommandInternal? command = DocumentClerkBatchUpdateCommandConverter.ToInternal(request);

                DocumentClerkBatchUpdateCommandInternalResponse? internalResponse = await mediator.Send(command, context.CancellationToken);

                DocumentClerkBatchUpdateCommandResponse? result = DocumentClerkBatchUpdateCommandResponseConverter.FromInternal(internalResponse);

                return result;
            });
    }

    public override async Task<UpdateDocumentCommandResponse> Update(UpdateDocumentCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Update),
            request,
            async () =>
            {
                UpdateDocumentCommandInternal? command = UpdateDocumentCommandConverter.ToInternal(request);

                await mediator.Send(command, context.CancellationToken);

                var result = new UpdateDocumentCommandResponse();

                return result;
            });
    }

    public override async Task<GetDocumentQueryResponse> Get(GetDocumentQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Get),
            request,
            async () =>
            {
                GetDocumentQueryInternal? query = GetDocumentQueryConverter.ToInternal(request);

                GetDocumentQueryInternalResponse? response = await mediator.Send(query, context.CancellationToken);

                if (response.Document == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"Document with id {request.DocumentId} wasn't found"));
                }

                GetDocumentQueryResponse? result = GetDocumentQueryResponseConverter.FromInternal(response.Document);

                return result;
            });
    }

    public override async Task GetAll(GetAllDocumentsQuery request, IServerStreamWriter<DocumentDetailedDto> responseStream, ServerCallContext context)
    {
        await TracingFacility.TraceGrpc(
            logger,
            nameof(GetAll),
            request,
            async () =>
            {
                GetAllDocumentsQueryInternal? query = GetAllDocumentsQueryConverter.ToInternal(request);

                DocumentDetailedInternal[] response = await mediator.Send(query, context.CancellationToken);

                DocumentDetailedDto[] documents = response.Select(DocumentDetailedDtoConverter.FromInternal).ToArray();

                foreach (DocumentDetailedDto? document in documents)
                {
                    await responseStream.WriteAsync(document);
                }

                return Task.CompletedTask;
            });
    }

    public override async Task<GetShortestPathToCompletionQueryResponse> GetShortestPathToCompletion(
        GetShortestPathToCompletionQueryRequest request,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetShortestPathToCompletion),
            request,
            async () =>
            {
                GetShortestPathToCompletionQueryRequestInternal? query = GetShortestPathToCompletionQueryRequestConverter.ToInternal(request);

                GetShortestPathToCompletionQueryResponseInternal? response = await mediator.Send(query, context.CancellationToken);

                GetShortestPathToCompletionQueryResponse? result = GetShortestPathToCompletionQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<ValidateDocumentQueryResponse> Validate(ValidateDocumentQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Validate),
            request,
            async () =>
            {
                ValidateDocumentQueryInternal? query = ValidateDocumentQueryConverter.ToInternal(request);

                ValidateDocumentQueryInternalResponse? response = await mediator.Send(query, context.CancellationToken);

                ValidateDocumentQueryResponse? result = ValidateDocumentQueryResponseConverter.FormInternal(response);

                return result;
            });
    }

    public override async Task<ProcessAllDocumentsCommandResponse> ProcessAll(ProcessAllDocumentsCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(ProcessAll),
            request,
            async () =>
            {
                var command = new ProcessAllDocumentsCommandInternal(request.DomainId);

                await mediator.Send(command, context.CancellationToken);

                var result = new ProcessAllDocumentsCommandResponse();

                return result;
            });
    }

    public override async Task<GetDocumentsAllowedStatusesQueryResponse> GetDocumentsAllowedStatuses(GetDocumentsAllowedStatusesQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetDocumentsAllowedStatuses),
            request,
            async () =>
            {
                GetDocumentsAllowedStatusesQueryInternal? query = GetDocumentsAllowedStatusesQueryConverter.ToInternal(request);

                GetDocumentsAllowedStatusesQueryResponseInternal? response = await mediator.Send(query, context.CancellationToken);

                GetDocumentsAllowedStatusesQueryResponse? result = GetDocumentsAllowedStatusesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<DocumentStatusBatchUpdateCommandResponse> DocumentStatusBatchUpdate(DocumentStatusBatchUpdateCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(DocumentStatusBatchUpdate),
            request,
            async () =>
            {
                DocumentStatusBatchUpdateCommandInternal? command = DocumentStatusBatchUpdateCommandConverter.ToInternal(request);

                DocumentStatusBatchUpdateCommandInternalResponse? internalResponse = await mediator.Send(command, context.CancellationToken);

                DocumentStatusBatchUpdateCommandResponse? result = DocumentStatusBatchUpdateCommandResponseConverter.FromInternal(internalResponse);

                return result;
            });
    }

    public override async Task<DeleteDocumentsCommandResponse> DeleteDocuments(DeleteDocumentsCommand request, ServerCallContext context)
    {
        var commandInternal = new DeleteDocumentsCommandInternal(request.DomainId, request.Ids.ToArray());

        await mediator.Send(commandInternal, context.CancellationToken);

        return new DeleteDocumentsCommandResponse();
    }
}
