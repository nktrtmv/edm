namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Factories;

internal static class DocumentWorkflowAvailableActionsBffFactory
{
    private static readonly DocumentWorkflowAvailableActionsBff EmptyInstance =
        new DocumentWorkflowAvailableActionsBff(null, null, []);

    internal static DocumentWorkflowAvailableActionsBff CreateEmpty()
    {
        var result = EmptyInstance;

        return result;
    }
}
