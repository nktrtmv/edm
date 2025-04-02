using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Attachments;

public sealed record DocumentAttachmentAttributeInternal(string[] DefaultValues, DocumentAttributeDataInternal Data) : DocumentAttributeInternal(Data);
