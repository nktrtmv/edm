namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public sealed record FilterSettings
{
    private FilterSettings()
    {
    }

    public bool AllowForSearch { get; private set; }
    public bool ShowInFilters { get; private set; }
    public bool AllowMultipleValues { get; private set; }
    public SearchKind? SearchKind { get; private set; }
    public Order? Order { get; private set; }

    public static FilterSettings Parse(
        bool allowForSearch,
        bool showInFilters,
        bool allowFilterMultipleValues,
        SearchKind? searchKind,
        Order? order)
    {
        if (showInFilters && searchKind is null or DocumentDomains.SearchKind.None)
        {
            throw new ApplicationException("SearchKind can't be None when showInFilters = true");
        }

        return new FilterSettings
        {
            SearchKind = searchKind,
            AllowMultipleValues = allowFilterMultipleValues,
            ShowInFilters = showInFilters,
            AllowForSearch = allowForSearch,
            Order = order
        };
    }

    public void SetAllowMultipleValues(bool allow)
    {
        AllowMultipleValues = allow;
    }
}
