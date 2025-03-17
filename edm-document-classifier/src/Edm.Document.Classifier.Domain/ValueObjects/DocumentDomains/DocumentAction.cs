namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public enum DocumentAction
{
    None = 0,
    UpdateDocumentsStatuses = 1,
    UpdateDocumentsClerks = 2,
    ExportDocumentToExcel = 3,
    ExportDocumentsSlas = 4,
    ExportPassesForms = 5,
    ExportPassesExcel = 6
}
