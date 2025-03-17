using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Parameters;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering.Segments;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype;

public sealed class DocumentPrototypeBff
{
    public required DocumentAttributeBff[] Attributes { get; init; }

    public required DocumentStatusTransitionPrototypeBff[] StatusesTransitions { get; init; }

    public DocumentNotificationBff[] Notifications { get; init; } = Array.Empty<DocumentNotificationBff>();

    public DocumentNumberingBff Numbering { get; init; } = new DocumentNumberingBff { Segments = Array.Empty<DocumentNumberingSegmentBff>() };

    public required string FrontMetadata { get; init; }

    public DocumentValidatorBff[] Validators { get; init; } = Array.Empty<DocumentValidatorBff>();

    public required DocumentParametersBff Parameters { get; init; }
}
