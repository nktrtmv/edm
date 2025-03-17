namespace Edm.Document.Classifier.Domain.ValueObjects.Currencies;

public static class CurrencyService
{
    private static readonly Dictionary<Currency, CurrencyInfo> Currencies = new[]
    {
        new CurrencyInfo(Currency.None, null, "Не определено", null),
        new CurrencyInfo(Currency.Aed, "AED", "Дирхамы (ОАЭ)", "784"),
        new CurrencyInfo(Currency.Amd, "AMD", "Армянский драм", "051"),
        new CurrencyInfo(Currency.Aud, "AUD", "Австралийский доллар", "036"),
        new CurrencyInfo(Currency.Azn, "AZN", "Азербайджанский манат", "944"),
        new CurrencyInfo(Currency.Bgn, "BGN", "Болгарский лев", "975"),
        new CurrencyInfo(Currency.Brl, "BRL", "Бразильский реал", "986"),
        new CurrencyInfo(Currency.Byn, "BYN", "Белорусский рубль", "933"),
        new CurrencyInfo(Currency.Byr, "BYR", "Белорусский рубль(устарело)", "933"),
        new CurrencyInfo(Currency.Cad, "CAD", "Канадский доллар", "124"),
        new CurrencyInfo(Currency.Chf, "CHF", "Швейцарский франк", "756"),
        new CurrencyInfo(Currency.Cny, "CNY", "Китайский Юань", "156"),
        new CurrencyInfo(Currency.Czk, "CZK", "Чешская Крона", "203"),
        new CurrencyInfo(Currency.Dkk, "DKK", "Датская Крона", "208"),
        new CurrencyInfo(Currency.Eek, "EEK", "Эстонская крона", "233"),
        new CurrencyInfo(Currency.Egp, "EGP", "Египетский фунт", "818"),
        new CurrencyInfo(Currency.Eur, "EUR", "Евро", "978"),
        new CurrencyInfo(Currency.Gbp, "GBP", "Британский фунт", "826"),
        new CurrencyInfo(Currency.Gbr, "GBR", "Английский фунт", "826"),
        new CurrencyInfo(Currency.Gel, "GEL", "Грузинский лари", "981"),
        new CurrencyInfo(Currency.Hkd, "HKD", "Гонконгский доллар", "344"),
        new CurrencyInfo(Currency.Huf, "HUF", "Венгерский Форинт", "348"),
        new CurrencyInfo(Currency.Idr, "IDR", "Индонезийская рупия", "360"),
        new CurrencyInfo(Currency.Ils, "ILS", "Шекель", "376"),
        new CurrencyInfo(Currency.Inr, "INR", "Индийская Рупия", "356"),
        new CurrencyInfo(Currency.Jpy, "JPY", "Японская йена", "392"),
        new CurrencyInfo(Currency.Kgs, "KGS", "Киргизский сом", "417"),
        new CurrencyInfo(Currency.Krw, "KRW", "Корейская вона", "410"),
        new CurrencyInfo(Currency.Kzt, "KZT", "Казахстанский тенге", "398"),
        new CurrencyInfo(Currency.Ltl, "LTL", "Литовский Лит", "440"),
        new CurrencyInfo(Currency.Lvl, "LVL", "Латвийский ЛАТ", "428"),
        new CurrencyInfo(Currency.Mdl, "MDL", "Молдавский Лей", "498"),
        new CurrencyInfo(Currency.Nok, "NOK", "Норвежская крона", "578"),
        new CurrencyInfo(Currency.Nzd, "NZD", "Новозеландский доллар", "554"),
        new CurrencyInfo(Currency.Pln, "PLN", "Польский Злотый", "985"),
        new CurrencyInfo(Currency.Qar, "QAR", "Катарский риал", "634"),
        new CurrencyInfo(Currency.Ron, "RON", "Румынский лей", "946"),
        new CurrencyInfo(Currency.Rsd, "RSD", "Сербский динар", "941"),
        new CurrencyInfo(Currency.Rub, "RUR", "Рубли", "643"),
        new CurrencyInfo(Currency.Sek, "SEK", "Шведская крона", "752"),
        new CurrencyInfo(Currency.Sgd, "SGD", "Сингапурский доллар", "702"),
        new CurrencyInfo(Currency.Thb, "THB", "Таиландский бат", "764"),
        new CurrencyInfo(Currency.Tjs, "TJS", "Таджикский сомони", "972"),
        new CurrencyInfo(Currency.Tmt, "TMT", "Туркменский манат", "934"),
        new CurrencyInfo(Currency.Try, "TRY", "Турецкая лира", "949"),
        new CurrencyInfo(Currency.Uah, "UAH", "Гривна", "980"),
        new CurrencyInfo(Currency.Usd, "USD", "Долары США", "840"),
        new CurrencyInfo(Currency.Uzs, "UZS", "Узбекский сум", "860"),
        new CurrencyInfo(Currency.Vnd, "VND", "Вьетнамский донг", "704"),
        new CurrencyInfo(Currency.Xdr, "XDR", "Специальные права заимствования (External Data Representation)", "960"),
        new CurrencyInfo(Currency.Zar, "ZAR", "Южноафриканский рэнд", "710")
    }.ToDictionary(r => r.Id);

    private static readonly Dictionary<string, CurrencyInfo> CurrenciesMetazon = Currencies.Where(c => !string.IsNullOrEmpty(c.Value.AlphaCode3))
        .ToDictionary(
            (Func<KeyValuePair<Currency, CurrencyInfo>, string>)(x => x.Value.AlphaCode3!),
            (Func<KeyValuePair<Currency, CurrencyInfo>, CurrencyInfo>)(x => x.Value));

    public static CurrencyInfo Get(Currency currency)
    {
        return Currencies[currency];
    }

    public static IReadOnlyCollection<CurrencyInfo> GetAll()
    {
        return Currencies.Values.ToArray<CurrencyInfo>();
    }

    public static CurrencyInfo? SearchByAlphaCode3(string? currency)
    {
        return string.IsNullOrEmpty(currency) || !CurrenciesMetazon.TryGetValue(currency, out var currencyInfo) ? null : currencyInfo;
    }
}
