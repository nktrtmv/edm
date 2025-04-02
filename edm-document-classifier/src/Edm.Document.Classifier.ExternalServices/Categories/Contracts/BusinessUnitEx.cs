using Edm.Document.Classifier.Domain;

namespace Edm.Document.Classifier.ExternalServices.Categories.Contracts;

public sealed class BusinessUnitEx : ITypedReference
{
    public BusinessUnitEx(long id, string name, string macroBusinessUnitName)
    {
        Id = id;
        Name = name;
        MacroBusinessUnitName = macroBusinessUnitName;
    }

    public long Id { get; }
    public string Name { get; }
    public string MacroBusinessUnitName { get; }
}
