using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Booleans;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Booleans.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.References;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.References.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Strings;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Strings.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsStatusesParameters.Relations.ByStatusType;

internal static class DocumentsStatusesParametersByStatusTypeProvider
{
    private static readonly StringDocumentStatusParameter ApprovalGraphTag =
        StringDocumentStatusParameterFactory.CreateFrom(DocumentStatusParameterKind.ApprovalGraphTag);

    private static readonly BooleanDocumentStatusParameter ApprovalExitApprovedWithRemarkIsOff =
        BooleanDocumentStatusParameterFactory.CreateFrom(DocumentStatusParameterKind.ApprovalExitApprovedWithRemarkIsOff);

    private static readonly ReferenceAttributeDocumentStatusParameter StageOwner =
        ReferenceAttributeDocumentStatusParameterFactory.CreateFrom(
            DocumentStatusParameterKind.StageOwner,
            DocumentAttributeReferenceTypes.Employees,
            [],
            false);

    private static readonly ReferenceAttributeDocumentStatusParameter SetCurrentUserToAttribute =
        ReferenceAttributeDocumentStatusParameterFactory.CreateFrom(
            DocumentStatusParameterKind.SetCurrentUserToAttribute,
            DocumentAttributeReferenceTypes.Employees,
            [],
            false);

    private static readonly BooleanDocumentStatusParameter IsBacklog =
        BooleanDocumentStatusParameterFactory.CreateFrom(DocumentStatusParameterKind.IsBacklog);

    private static readonly DocumentStatusDocumentStatusParameter BusinessErrorHandlingStatus =
        DocumentStatusDocumentStatusParameterFactory.CreateFrom(DocumentStatusParameterKind.BusinessErrorHandlingStatus);

    private static readonly DocumentStatusDocumentStatusParameter UnifiedNextAutoStatus =
        DocumentStatusDocumentStatusParameterFactory.CreateFrom(DocumentStatusParameterKind.UnifiedNextAutoStatus);

    private static readonly ReferenceAttributeDocumentStatusParameter Watchers =
        ReferenceAttributeDocumentStatusParameterFactory.CreateFrom(
            DocumentStatusParameterKind.Watchers,
            DocumentAttributeReferenceTypes.Employees,
            [],
            true);

    internal static readonly Dictionary<DocumentStatusType, DocumentStatusParameter[]> ParametersByStatusType =
        new Dictionary<DocumentStatusType, DocumentStatusParameter[]>
        {
            {
                DocumentStatusType.Initial, [
                    SetCurrentUserToAttribute,
                    UnifiedNextAutoStatus
                ]
            },
            {
                DocumentStatusType.Approval, [
                    ApprovalGraphTag,
                    ApprovalExitApprovedWithRemarkIsOff,
                    StageOwner,
                    SetCurrentUserToAttribute,
                    IsBacklog,
                    Watchers,
                    UnifiedNextAutoStatus
                ]
            },
            {
                DocumentStatusType.Signing, [
                    StageOwner,
                    SetCurrentUserToAttribute,
                    UnifiedNextAutoStatus
                ]
            },
            {
                DocumentStatusType.Backlog, [
                    ApprovalGraphTag,
                    StageOwner,
                    SetCurrentUserToAttribute,
                    IsBacklog,
                    BusinessErrorHandlingStatus,
                    Watchers,
                    UnifiedNextAutoStatus
                ]
            },
            {
                DocumentStatusType.Simple, [
                    ApprovalGraphTag,
                    StageOwner,
                    SetCurrentUserToAttribute,
                    IsBacklog,
                    BusinessErrorHandlingStatus,
                    Watchers,
                    UnifiedNextAutoStatus
                ]
            },
            {
                DocumentStatusType.Completed, [
                    BusinessErrorHandlingStatus,
                    UnifiedNextAutoStatus
                ]
            },
            {
                DocumentStatusType.Cancelled, [
                    BusinessErrorHandlingStatus,
                    UnifiedNextAutoStatus
                ]
            }
        };
}
