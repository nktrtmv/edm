using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts;
using Edm.Document.Classifier.GenericSubdomain.Tracing;
using Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.GetTypes;
using Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.SearchValues;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

using Grpc.Core;

using MediatR;

namespace Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References;

public sealed class ApprovalReferencesController : ApprovalReferencesService.ApprovalReferencesServiceBase
{
    public ApprovalReferencesController(IMediator mediator, ILogger<ApprovalReferencesController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<ApprovalReferencesController> Logger { get; }

    public override async Task<GetTypesApprovalReferencesQueryResponse> GetTypes(GetTypesApprovalReferencesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetTypes),
            query,
            async () =>
            {
                var request = GetTypesDocumentReferencesQueryInternal.Instance;

                GetTypesDocumentReferencesQueryResponseInternal response = await Mediator.Send(request, context.CancellationToken);

                GetTypesApprovalReferencesQueryResponse result = GetTypesApprovalReferencesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<SearchValuesApprovalReferencesQueryResponse> SearchValues(SearchValuesApprovalReferencesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(SearchValues),
            query,
            async () =>
            {
                SearchValuesDocumentReferencesQueryInternal request = SearchValuesApprovalReferencesQueryConverter.ToInternal(query);

                SearchValuesDocumentReferencesQueryResponseInternal response = await Mediator.Send(request, context.CancellationToken);

                SearchValuesApprovalReferencesQueryResponse result = SearchValuesApprovalReferencesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
