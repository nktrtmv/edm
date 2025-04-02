using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Types;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Contexts;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Transformers.Inheritors;

internal abstract class DocumentWorkflowStepTransformer<T>(T[] workflows, DocumentStatusTypeInternal statusType, DocumentConversionContext conversionContext)
{
    private T[] Workflows { get; } = workflows;
    private DocumentStatusTypeInternal StatusType { get; } = statusType;
    private int LastIndex { get; set; }
    protected DocumentConversionContext ConversionContext { get; } = conversionContext;

    internal DocumentWorkflowStepInternal TryTransform(DocumentWorkflowStepInternal step)
    {
        if (step.Status.Type != StatusType)
        {
            return step;
        }

        T workflow = Workflows[LastIndex++];

        DocumentWorkflowStepInternal result = Transform(step, workflow);

        return result;
    }

    protected abstract DocumentWorkflowStepInternal Transform(DocumentWorkflowStepInternal step, T workflow);
}
