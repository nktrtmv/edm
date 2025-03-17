using System.Text.Json.Serialization;

using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;

namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

[JsonDerivedType(typeof(StringTypeSettings))]
[JsonDerivedType(typeof(DateTypeSettings))]
[JsonDerivedType(typeof(ReferenceTypeSettings))]
[JsonDerivedType(typeof(NumberTypeSettings))]
[JsonDerivedType(typeof(BooleanTypeSettings))]
[JsonDerivedType(typeof(AttachmentTypeSettings))]
public abstract record TypeSettings;

public sealed record StringTypeSettings : TypeSettings;

public sealed record AttachmentTypeSettings : TypeSettings;

public sealed record BooleanTypeSettings : TypeSettings;

public sealed record DateTypeSettings : TypeSettings
{
    public DateRegistryRoleDisplayType Value { get; private init; }

    public static DateTypeSettings Parse(DateRegistryRoleDisplayType displayType)
    {
        if (displayType == DateRegistryRoleDisplayType.None)
        {
            throw new ApplicationException("DateRegistryRoleDisplayType value can't be none");
        }

        return new DateTypeSettings
        {
            Value = displayType
        };
    }
}

public sealed record ReferenceTypeSettings : TypeSettings
{
    private ReferenceTypeSettings()
    {
    }

    public DocumentReferenceTypeId Value { get; private init; }
    public ReferenceRegistryRoleDisplayType DisplayType { get; private init; }

    public static ReferenceTypeSettings Parse(DocumentReferenceTypeId referenceTypeId, ReferenceRegistryRoleDisplayType displayType)
    {
        if (referenceTypeId == DocumentReferenceTypeId.None)
        {
            throw new ApplicationException("DocumentReferenceTypeId value can't be none");
        }

        if (displayType == ReferenceRegistryRoleDisplayType.None)
        {
            throw new ApplicationException("ReferenceRegistryRoleDisplayType value can't be none");
        }

        return new ReferenceTypeSettings
        {
            Value = referenceTypeId,
            DisplayType = displayType
        };
    }
}

public sealed record NumberTypeSettings(int Precision) : TypeSettings;
