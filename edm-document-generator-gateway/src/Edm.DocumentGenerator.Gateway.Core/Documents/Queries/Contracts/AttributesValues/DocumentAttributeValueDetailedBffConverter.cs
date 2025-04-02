using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Attachments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Booleans;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Dates;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Numbers;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Strings;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Tuples;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Tuples.InnerValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;

internal static class DocumentAttributeValueDetailedBffConverter
{
    public static DocumentAttributeValueDetailedBff ToBff(
        DocumentAttributeValueDetailedDto attributeValue,
        DocumentConversionContext context,
        DomainRoles domainRoles)
    {
        var attribute = DocumentAttributeBffFromDtoConverter.FromDto(attributeValue.Attribute, domainRoles);

        var result = attributeValue.ValueCase switch
        {
            DocumentAttributeValueDetailedDto.ValueOneofCase.AsAttachment =>
                ToAttachment(attribute, attributeValue.AsAttachment, context),

            DocumentAttributeValueDetailedDto.ValueOneofCase.AsBoolean =>
                ToBoolean(attribute, attributeValue.AsBoolean),

            DocumentAttributeValueDetailedDto.ValueOneofCase.AsDate =>
                ToDate(attribute, attributeValue.AsDate),

            DocumentAttributeValueDetailedDto.ValueOneofCase.AsNumber =>
                ToNumber(attribute, attributeValue.AsNumber),

            DocumentAttributeValueDetailedDto.ValueOneofCase.AsReference =>
                ToReference(attribute, attributeValue.AsReference, context),

            DocumentAttributeValueDetailedDto.ValueOneofCase.AsString =>
                ToString(attribute, attributeValue.AsString),

            DocumentAttributeValueDetailedDto.ValueOneofCase.AsTuple =>
                ToTuple(attribute, attributeValue.AsTuple, context, domainRoles),

            _ => throw new ArgumentTypeOutOfRangeException(attributeValue.ValueCase)
        };

        // result.Attribute.Permissions = [];

        return result;
    }

    private static DocumentAttributeValueDetailedBff ToAttachment(
        DocumentAttributeBff attribute,
        DocumentAttachmentAttributeValueDetailedDto attributeValue,
        DocumentConversionContext context)
    {
        var values = attributeValue.Values.Select(Guid.Parse).ToArray();

        var result = new DocumentAttachmentAttributeValueDetailedBff
        {
            Attribute = attribute,
            Values = values
        };

        return result;
    }

    private static DocumentAttributeValueDetailedBff ToBoolean(
        DocumentAttributeBff attribute,
        DocumentBooleanAttributeValueDetailedDto attributeValue)
    {
        var values = attributeValue.Values.ToArray();

        var result = new DocumentBooleanAttributeValueDetailedBff
        {
            Attribute = attribute,
            Values = values
        };

        return result;
    }

    private static DocumentAttributeValueDetailedBff ToDate(
        DocumentAttributeBff attribute,
        DocumentDateAttributeValueDetailedDto attributeValue)
    {
        var values = attributeValue.Values.Select(t => t.ToDateTime()).ToArray();

        var result = new DocumentDateAttributeValueDetailedBff
        {
            Attribute = attribute,
            Values = values
        };

        return result;
    }

    private static DocumentAttributeValueDetailedBff ToNumber(
        DocumentAttributeBff attribute,
        DocumentNumberAttributeValueDetailedDto attributeValue)
    {
        var values = attributeValue.Values.ToArray();

        var result = new DocumentNumberAttributeValueDetailedBff
        {
            Attribute = attribute,
            Values = values
        };

        return result;
    }

    private static DocumentAttributeValueDetailedBff ToReference(
        DocumentAttributeBff attribute,
        DocumentReferenceAttributeValueDetailedDto attributeValue,
        DocumentConversionContext context)
    {
        var values = attributeValue.Values.Select(ReferenceTypeValueBff.CreateNotEnriched).ToArray();

        var result = new DocumentReferenceAttributeValueDetailedBff
        {
            Attribute = attribute,
            Values = values
        };

        context.Enricher.Add(result);

        return result;
    }

    private static DocumentAttributeValueDetailedBff ToString(
        DocumentAttributeBff attribute,
        DocumentStringAttributeValueDetailedDto attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new DocumentStringAttributeValueDetailedBff
        {
            Attribute = attribute,
            Values = values
        };

        return result;
    }

    private static DocumentAttributeValueDetailedBff ToTuple(
        DocumentAttributeBff attribute,
        DocumentTupleAttributeValueDetailedDto attributeValue,
        DocumentConversionContext context,
        DomainRoles domainRoles)
    {
        var values = attributeValue.Values
            .Select(x => ToTupleValue(x, context, domainRoles))
            .ToArray();

        var result = new DocumentTupleAttributeValueDetailedBff
        {
            Attribute = attribute,
            Values = values
        };

        return result;
    }

    private static DocumentTupleAttributeValueInnerValueDetailedBff ToTupleValue(
        DocumentTupleAttributeValueInnerValueDetailedDto value,
        DocumentConversionContext context,
        DomainRoles domainRoles)
    {
        var innerValues = value.InnerValues.Select(x => ToBff(x, context, domainRoles)).ToArray();

        var result = new DocumentTupleAttributeValueInnerValueDetailedBff
        {
            InnerValues = innerValues
        };

        return result;
    }
}
