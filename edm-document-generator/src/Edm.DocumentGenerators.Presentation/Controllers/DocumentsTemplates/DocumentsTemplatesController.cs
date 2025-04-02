using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Create.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Delete.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.MigrateAll.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Update.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAllDocumentsStatuses.Contracts;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Commands.Create;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Commands.Delete;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Commands.Update;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.Get;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.GetAll;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.GetAllDocumentsStatuses;

using Grpc.Core;

using MediatR;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates;

internal sealed class DocumentsTemplatesController(IMediator mediator, ILogger<DocumentsTemplatesController> logger) : DocumentTemplateService.DocumentTemplateServiceBase
{
    public override async Task<CreateDocumentTemplateCommandResponse> Create(CreateDocumentTemplateCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Create),
            request,
            async () =>
            {
                CreateDocumentTemplateCommandInternal? command = CreateDocumentTemplateCommandConverter.ToInternal(request);

                await mediator.Send(command, context.CancellationToken);

                var result = new CreateDocumentTemplateCommandResponse();

                return result;
            });
    }

    public override async Task<DeleteDocumentTemplateCommandResponse> Delete(DeleteDocumentTemplateCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Delete),
            request,
            async () =>
            {
                DeleteDocumentTemplateCommandInternal? command = DeleteDocumentTemplateCommandConverter.ToInternal(request);

                await mediator.Send(command, context.CancellationToken);

                var result = new DeleteDocumentTemplateCommandResponse();

                return result;
            });
    }

    public override async Task<UpdateDocumentTemplateCommandResponse> Update(UpdateDocumentTemplateCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Update),
            request,
            async () =>
            {
                UpdateDocumentTemplateCommandInternal? command = UpdateDocumentTemplateCommandConverter.ToInternal(request);

                await mediator.Send(command, context.CancellationToken);

                var result = new UpdateDocumentTemplateCommandResponse();

                return result;
            });
    }

    public override async Task<GetDocumentTemplateQueryResponse> Get(GetDocumentTemplateQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Get),
            request,
            async () =>
            {
                GetDocumentTemplateQueryInternal? query = GetDocumentTemplateQueryConverter.ToInternal(request);

                GetDocumentTemplateQueryInternalResponse? response = await mediator.Send(query, context.CancellationToken);

                GetDocumentTemplateQueryResponse? result = GetDocumentTemplateQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetAllDocumentTemplatesQueryResponse> GetAll(GetAllDocumentTemplatesQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetAll),
            request,
            async () =>
            {
                GetAllDocumentTemplatesQueryInternal? query = GetAllDocumentTemplatesQueryConverter.ToInternal(request);

                GetAllDocumentTemplatesQueryInternalResponse? response = await mediator.Send(query, context.CancellationToken);

                GetAllDocumentTemplatesQueryResponse? result = GetAllDocumentTemplatesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<MigrateAllDocumentsTemplatesCommandResponse> MigrateAll(MigrateAllDocumentsTemplatesCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(MigrateAll),
            request,
            async () =>
            {
                string? domainId = DomainIdHelper.GetDomainIdOrSetDefault(request.DomainId);
                var command = new MigrateAllDocumentsTemplatesCommandInternal(domainId);

                await mediator.Send(command, context.CancellationToken);

                var result = new MigrateAllDocumentsTemplatesCommandResponse();

                return result;
            });
    }

    public override Task<GetAllDocumentsStatusesDocumentTemplatesQueryResponse> GetAllDocumentsStatuses(
        GetAllDocumentsStatusesDocumentTemplatesQuery request,
        ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            logger,
            nameof(GetAllDocumentsStatuses),
            request,
            async () =>
            {
                string? domainId = DomainIdHelper.GetDomainIdOrSetDefault(request.DomainId);
                var query = new GetAllDocumentsStatusesDocumentTemplatesQueryInternal(domainId);

                GetAllDocumentsStatusesDocumentTemplatesQueryResponseInternal? response = await mediator.Send(query, context.CancellationToken);

                GetAllDocumentsStatusesDocumentTemplatesQueryResponse? result = GetAllDocumentsStatusesDocumentTemplatesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
