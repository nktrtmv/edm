namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.ApprovalData;

public readonly record struct DocumentAttributeApprovalDataInternal(
    int MetadataId,
    bool IsParticipant);
