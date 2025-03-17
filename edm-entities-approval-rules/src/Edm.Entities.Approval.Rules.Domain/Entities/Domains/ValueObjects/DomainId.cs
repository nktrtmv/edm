namespace Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;

public readonly record struct DomainId
{
    public const string ContractsDomain = "8a3d776c-906a-4de2-9c20-1df638f1545b";

    public DomainId()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private DomainId(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static DomainId Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            throw new ApplicationException("DomainId name can't be empty");
        }

        return new DomainId(s);
    }
}
