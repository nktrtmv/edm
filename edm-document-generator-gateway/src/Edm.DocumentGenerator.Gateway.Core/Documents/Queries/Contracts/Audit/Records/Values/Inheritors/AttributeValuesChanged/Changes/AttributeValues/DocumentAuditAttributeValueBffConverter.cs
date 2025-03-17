using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Attachments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Booleans;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.Dates;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Numbers;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Strings;
using
    Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.Tuples;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.Tuples
    .InnerValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues;

internal static class DocumentAuditAttributeValueBffConverter
{
    internal static DocumentAuditAttributeValueBff ToBff(DocumentAttributeValueDto attributeValue, DocumentConversionContext context)
    {
        var frontMetadata = context.AttributesFrontMetadata[attributeValue.AttributeId];

        DocumentAuditAttributeValueBff result = attributeValue.ValueCase switch
        {
            DocumentAttributeValueDto.ValueOneofCase.AsAttachment =>
                ToAttachment(attributeValue.AttributeId, attributeValue.AsAttachment, frontMetadata, context),

            DocumentAttributeValueDto.ValueOneofCase.AsBoolean =>
                ToBoolean(attributeValue.AttributeId, attributeValue.AsBoolean, frontMetadata),

            DocumentAttributeValueDto.ValueOneofCase.AsDate =>
                ToDate(attributeValue.AttributeId, attributeValue.AsDate, frontMetadata),

            DocumentAttributeValueDto.ValueOneofCase.AsNumber =>
                ToNumber(attributeValue.AttributeId, attributeValue.AsNumber, frontMetadata),

            DocumentAttributeValueDto.ValueOneofCase.AsReference =>
                ToReference(attributeValue.AttributeId, attributeValue.AsReference, frontMetadata, context),

            DocumentAttributeValueDto.ValueOneofCase.AsString =>
                ToString(attributeValue.AttributeId, attributeValue.AsString, frontMetadata),

            DocumentAttributeValueDto.ValueOneofCase.AsTuple =>
                ToTuple(attributeValue.AttributeId, attributeValue.AsTuple, frontMetadata, context),

            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }

    private static DocumentAttachmentAuditAttributeValueBff ToAttachment(
        string attributeId,
        AttachmentDocumentAttributeValueDto attributeValue,
        string frontMetadata,
        DocumentConversionContext context)
    {
        var value = attributeValue
            .Values
            .Select(Guid.Parse)
            .ToArray();

        var result = new DocumentAttachmentAuditAttributeValueBff
        {
            AttributeId = attributeId,
            Value = value,
            FrontMetadata = frontMetadata
        };

        return result;
    }

    private static DocumentBooleanAuditAttributeValueBff ToBoolean(string attributeId, BooleanDocumentAttributeValueDto attributeValue, string frontMetadata)
    {
        var value = attributeValue.Values.ToArray();

        var result = new DocumentBooleanAuditAttributeValueBff
        {
            AttributeId = attributeId,
            Value = value,
            FrontMetadata = frontMetadata
        };

        return result;
    }

    private static DocumentDateAuditAttributeValueBff ToDate(string attributeId, DateDocumentAttributeValueDto attributeValue, string frontMetadata)
    {
        var value = attributeValue.Values.Select(x => x.ToDateTime()).ToArray();

        var result = new DocumentDateAuditAttributeValueBff
        {
            AttributeId = attributeId,
            Value = value,
            FrontMetadata = frontMetadata
        };

        return result;
    }

    private static DocumentNumberAuditAttributeValueBff ToNumber(string attributeId, NumberDocumentAttributeValueDto attributeValue, string frontMetadata)
    {
        var value = attributeValue.Values.ToArray();

        var result = new DocumentNumberAuditAttributeValueBff
        {
            AttributeId = attributeId,
            Value = value,
            FrontMetadata = frontMetadata
        };

        return result;
    }

    private static DocumentReferenceAuditAttributeValueBff ToReference(
        string attributeId,
        ReferenceDocumentAttributeValueDto attributeValue,
        string frontMetadata,
        DocumentConversionContext context)
    {
        var value = attributeValue.Values.Select(ReferenceTypeValueBff.CreateNotEnriched).ToArray();

        var result = new DocumentReferenceAuditAttributeValueBff
        {
            AttributeId = attributeId,
            Value = value,
            FrontMetadata = frontMetadata
        };

        context.Enricher.Add(result);

        return result;
    }

    private static DocumentStringAuditAttributeValueBff ToString(string attributeId, StringDocumentAttributeValueDto attributeValue, string frontMetadata)
    {
        string[] value = attributeValue.Values.ToArray();

        var results = new DocumentStringAuditAttributeValueBff
        {
            AttributeId = attributeId,
            Value = value,
            FrontMetadata = frontMetadata
        };

        return results;
    }

    private static DocumentTupleAuditAttributeValueBff ToTuple(
        string attributeId,
        TupleDocumentAttributeValueDto attributeValue,
        string frontMetadata,
        DocumentConversionContext context)
    {
        var value = attributeValue.Values.Select(x => ToTupleValue(x, context)).ToArray();

        var result = new DocumentTupleAuditAttributeValueBff
        {
            AttributeId = attributeId,
            Value = value,
            FrontMetadata = frontMetadata
        };

        return result;
    }

    private static DocumentTupleAuditAttributeValueInnerValueBff ToTupleValue(TupleInnerValueDocumentAttributeValueDto value, DocumentConversionContext context)
    {
        var innerValues = value.InnerValues.Select(x => ToBff(x, context)).ToArray();

        var result = new DocumentTupleAuditAttributeValueInnerValueBff
        {
            InnerValues = innerValues
        };

        return result;
    }
}
