using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Strings.Factories;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions.Single;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Services;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Ids;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.PassApplicantFullNames;

internal sealed class PassApplicantFullNameSearchDocumentAttributesValuesCollector()
    : SingleAttributesValuesCollector(SearchDocumentRegistryRoleId.PassApplicantFullNames)
{
    private const string EmployeeApplicantAttributeSystemName = "employee-applicant";

    private const string ExternalApplicantFirstNameAttributeSystemName = "external-applicant-first-name";
    private const string ExternalApplicantLastNameAttributeSystemName = "external-applicant-last-name";
    private const string ExternalApplicantMiddleNameAttributeSystemName = "external-applicant-middle-name";

    protected override Task<SearchDocumentAttributeValueInternal?> Collect(
        SearchDocumentUpdaterContext context,
        SearchDocumentRegistryRoleInternal registryRole,
        CancellationToken cancellationToken)
    {
        var applicantFullName = FetchEmployeeApplicantId(context) ?? FetchExternalApplicantFullName(context);

        var result = SearchDocumentStringAttributeValueInternalFactory.CreateFrom(registryRole, applicantFullName);

        return Task.FromResult<SearchDocumentAttributeValueInternal?>(result);
    }

    private string? FetchEmployeeApplicantId(SearchDocumentUpdaterContext context)
    {
        var applicantEmployeeId =
            DocumentAttributeValuesFetcher.FetchSingleOrDefaultAttributeValueBySystemName<string>(context.Document, EmployeeApplicantAttributeSystemName);

        return applicantEmployeeId;
    }

    private static string FetchExternalApplicantFullName(SearchDocumentUpdaterContext context)
    {
        var applicantFirstName =
            DocumentAttributeValuesFetcher.FetchSingleOrDefaultAttributeValueBySystemName<string>(context.Document, ExternalApplicantFirstNameAttributeSystemName);

        var applicantLastName =
            DocumentAttributeValuesFetcher.FetchSingleOrDefaultAttributeValueBySystemName<string>(context.Document, ExternalApplicantLastNameAttributeSystemName);

        var applicantMiddleName =
            DocumentAttributeValuesFetcher.FetchSingleOrDefaultAttributeValueBySystemName<string>(context.Document, ExternalApplicantMiddleNameAttributeSystemName);

        IEnumerable<string> applicantFullName = new[] { applicantLastName, applicantFirstName, applicantMiddleName }
            .Where(n => !string.IsNullOrWhiteSpace(n))!;

        var result = string.Join(' ', applicantFullName);

        return result;
    }
}
