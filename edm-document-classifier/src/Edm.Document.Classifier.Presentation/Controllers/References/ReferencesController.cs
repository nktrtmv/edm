using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetNewReferenceTypeId.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts;
using Edm.Document.Classifier.GenericSubdomain.Tracing;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Commands.Create;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Commands.Update;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.Get;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.GetAll;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.GetNewReferenceTypeId;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.GetTypes;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Commands.Bulk;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Commands.Create;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Commands.Update;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.Get;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.GetAll;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.GetReferenceValuesSearch;

using Grpc.Core;

using MediatR;

namespace Edm.Document.Classifier.Presentation.Controllers.References;

public sealed class ReferencesController(IMediator mediator, ILogger<ReferencesController> logger) : ReferencesService.ReferencesServiceBase
{
    public override async Task<GetTypesQueryResponse> GetTypes(GetTypesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetTypes),
            query,
            async () =>
            {
                var request = GetTypesDocumentReferencesQueryInternal.Instance;

                var response = await mediator.Send(request, context.CancellationToken);

                var result = GetTypesQueryResponseConverter.FromInternal(response);

                return result;
            },
            LogLevel.Debug);
    }

    public override async Task<CreateDocumentReferenceTypeCommandResponse> CreateReference(CreateDocumentReferenceTypeCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(CreateReference),
            command,
            async () =>
            {
                var request = CreateDocumentReferenceTypeCommandConverter.ToInternal(command);

                var response = await mediator.Send(request, context.CancellationToken);

                var result = CreateDocumentReferenceTypeCommandResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<UpdateDocumentReferenceTypeCommandResponse> UpdateReference(UpdateDocumentReferenceTypeCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(UpdateReference),
            command,
            async () =>
            {
                var request = UpdateDocumentReferenceTypeCommandConverter.ToInternal(command);

                var response = await mediator.Send(request, context.CancellationToken);

                var result = UpdateDocumentReferenceTypeCommandResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetDocumentReferenceTypeQueryResponse> GetReference(GetDocumentReferenceTypeQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetReference),
            query,
            async () =>
            {
                var request = GetDocumentReferenceTypeQueryConverter.ToInternal(query);

                var response = await mediator.Send(request, context.CancellationToken);

                var result = GetDocumentReferenceTypeQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetAllDocumentReferenceTypesQueryResponse> GetAllReferences(GetAllDocumentReferenceTypesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetAllReferences),
            query,
            async () =>
            {
                var request = GetAllDocumentReferenceTypesQueryConverter.ToInternal(query);

                var response = await mediator.Send(request, context.CancellationToken);

                var result = GetAllDocumentReferenceTypesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetNewReferenceTypeIdQueryResponse> GetNewReferenceTypeId(GetNewReferenceTypeIdQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetAllReferences),
            query,
            async () =>
            {
                var request = new GetNewReferenceTypeIdQueryInternal();

                var response = await mediator.Send(request, context.CancellationToken);

                var result = GetNewReferenceTypeIdQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetReferenceValuesSearchQueryResponse> GetReferenceValuesSearch(GetReferenceValuesSearchQuery searchQuery, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetReferenceValuesSearch),
            searchQuery,
            async () =>
            {
                var request = GetReferenceValuesSearchQueryConverter.ToInternal(searchQuery);

                var response = await mediator.Send(request, context.CancellationToken);

                var result = GetReferenceValuesSearchQueryResponseConverter.FromInternal(response);

                return result;
            },
            LogLevel.Debug);
    }

    public override async Task<CreateDocumentReferenceValueCommandResponse> CreateReferenceValue(CreateDocumentReferenceValueCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(CreateReferenceValue),
            command,
            async () =>
            {
                var request = CreateDocumentReferenceValueCommandConverter.ToInternal(command);

                var response = await mediator.Send(request, context.CancellationToken);

                var result = CreateDocumentReferenceValueCommandResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<UpdateDocumentReferenceValueCommandResponse> UpdateReferenceValue(UpdateDocumentReferenceValueCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(UpdateReferenceValue),
            command,
            async () =>
            {
                var request = UpdateDocumentReferenceValueCommandConverter.ToInternal(command);

                var response = await mediator.Send(request, context.CancellationToken);

                var result = UpdateDocumentReferenceValueCommandResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<BulkUpsertReferenceValuesCommandResponse> BulkUpsertReferenceValues(BulkUpsertReferenceValuesCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(BulkUpsertReferenceValues),
            command,
            async () =>
            {
                var request = BulkUpsertReferenceValuesCommandConverter.ToInternal(command);

                await mediator.Send(request, context.CancellationToken);

                var result = new BulkUpsertReferenceValuesCommandResponse();

                return result;
            });
    }

    public override async Task<GetDocumentReferenceValueQueryResponse> GetReferenceValue(GetDocumentReferenceValueQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetReferenceValue),
            query,
            async () =>
            {
                var request = GetDocumentReferenceValueQueryConverter.ToInternal(query);

                var response = await mediator.Send(request, context.CancellationToken);

                var result = GetDocumentReferenceValueQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetAllDocumentReferenceValuesQueryResponse> GetAllReferenceValues(GetAllDocumentReferenceValuesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetAllReferenceValues),
            query,
            async () =>
            {
                var request = GetAllDocumentReferenceValuesQueryConverter.ToInternal(query);

                var response = await mediator.Send(request, context.CancellationToken);

                var result = GetAllDocumentReferenceValuesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
