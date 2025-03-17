using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Types;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails.Steps.Transformers.Inheritors;

internal abstract class DocumentWorkflowStepTransformer<T>
{
    protected DocumentWorkflowStepTransformer(T[] workflows, DocumentStatusTypeBff statusType, DocumentConversionContext conversionContext)
    {
        Workflows = workflows;
        StatusType = statusType;
        ConversionContext = conversionContext;
    }

    private T[] Workflows { get; }
    private DocumentStatusTypeBff StatusType { get; }
    private int LastIndex { get; set; }
    protected DocumentConversionContext ConversionContext { get; }

    internal DocumentWorkflowStepBff TryTransform(DocumentWorkflowStepBff step)
    {
        if (step.Status.Type != StatusType)
        {
            return step;
        }

        var workflow = Workflows[LastIndex++];

        var result = Transform(step, workflow);

        return result;
    }

    protected abstract DocumentWorkflowStepBff Transform(DocumentWorkflowStepBff step, T workflow);
}
