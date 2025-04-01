﻿using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Contexts;

public sealed record DocumentTemplateUpdatingContext(DocumentAttribute[] ApprovalParticipantAttributes);
