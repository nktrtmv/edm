using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Numbering.Segments.Formats;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Numbering;

internal static class DocumentNumberingValidator
{
    internal static void Validate(DocumentNumbering numbering)
    {
        Array.ForEach(numbering.Segments, DocumentNumberingSegmentValidator.ValidateFormat);
    }
}
