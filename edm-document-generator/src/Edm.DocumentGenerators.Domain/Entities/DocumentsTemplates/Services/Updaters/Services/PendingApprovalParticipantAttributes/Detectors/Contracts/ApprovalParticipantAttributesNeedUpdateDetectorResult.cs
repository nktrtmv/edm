﻿using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Detectors.Contracts;

internal sealed record ApprovalParticipantAttributesNeedUpdateDetectorResult(bool NeedUpdate, DocumentAttribute[] AttributesToUpdate);
