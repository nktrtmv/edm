using System.Transactions;

namespace Edm.Entities.Counters.Infrastructure.Services;

public static class TransactionHelper
{
    public static TransactionScope CreateTransaction()
    {
        var result = new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions
            {
                IsolationLevel = IsolationLevel.Serializable
            },
            TransactionScopeAsyncFlowOption.Enabled);

        return result;
    }
}
