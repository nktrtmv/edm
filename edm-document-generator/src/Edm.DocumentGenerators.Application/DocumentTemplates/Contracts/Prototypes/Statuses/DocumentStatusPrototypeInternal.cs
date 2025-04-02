using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Types;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Statuses;

public sealed record DocumentStatusPrototypeInternal(
    string Id,
    DocumentStatusTypeInternal Type,
    DocumentStatusParameterInternal[] Parameters,
    string SystemName,
    string DisplayName);
