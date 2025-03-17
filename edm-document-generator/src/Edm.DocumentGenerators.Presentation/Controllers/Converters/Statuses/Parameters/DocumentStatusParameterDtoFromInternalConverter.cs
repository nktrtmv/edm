using System.Collections.Frozen;

using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses.Parameters.Kinds;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses.Parameters;

internal static class DocumentStatusParameterDtoFromInternalConverter
{
    private const string? IntegrationsGroupName = "Интеграции";
    private const string? ApprovalParametersGroupName = "Настройки согласования";

    private static readonly FrozenDictionary<DocumentStatusParameterKindDto, ParameterMetaInfo> _kindDisplay =
        new Dictionary<DocumentStatusParameterKindDto, ParameterMetaInfo>
        {
            [DocumentStatusParameterKindDto.Watchers] = new ParameterMetaInfo(
                "Наблюдатели",
                "Используется для указания наблюдателей на этапе. На данный момент работает только в согласовании - наблюдатели получают уведомления об изменениях в согласовании (изменение согласующих, согласование, отмена и т.п.)"),
            [DocumentStatusParameterKindDto.UnifiedNextAutoStatus] = new ParameterMetaInfo(
                "Статус для автоматического выхода",
                "Используется при необходимости автоматически выйти из текущего этапа на указанный"),
            [DocumentStatusParameterKindDto.BusinessErrorHandlingStatus] = new ParameterMetaInfo(
                "Статус обработки бизнес-ошибок",
                "Используется при интеграциях. Позволяет задать в какой статус будет сдвинут документ при возвращенной ошибке из мастер системы",
                IntegrationsGroupName),
            [DocumentStatusParameterKindDto.StageOwner] = new ParameterMetaInfo(
                "Ответственный за этап",
                "Ответственный за этап для SLA или интеграции с мастер-системой аренды"),
            [DocumentStatusParameterKindDto.IsBacklog] = new ParameterMetaInfo(
                "Ожидание обработки",
                "Помечает статус как этап 'Ожидает обработки'"),
            [DocumentStatusParameterKindDto.ApprovalGraphTag] = new ParameterMetaInfo(
                "Тег матрицы",
                "Указывается тег маршрута, который будет использоваться в согласовании (при отсутствии параметра подставляется маршрут с пустым тегом)",
                ApprovalParametersGroupName),
            [DocumentStatusParameterKindDto.SetCurrentUserToAttribute] = new ParameterMetaInfo(
                "Установить пользователя в атрибут",
                "Устанавливает в атрибут пользователя, который был инициатором перехода на текущий этап"),
            [DocumentStatusParameterKindDto.ApprovalExitApprovedWithRemarkIsOff] = new ParameterMetaInfo(
                "Отключить согласование с замечаниями",
                Group: ApprovalParametersGroupName)
        }.ToFrozenDictionary();

    internal static DocumentStatusParameterDto FromInternal(DocumentStatusParameterInternal parameter)
    {
        DocumentStatusParameterDto? result = parameter switch
        {
            BooleanDocumentStatusParameterInternal p => ToBoolean(p),
            StringDocumentStatusParameterInternal p => ToString(p),
            ReferenceAttributeDocumentStatusParameterInternal p => ToReferenceAttribute(p),
            DocumentStatusDocumentStatusParameterInternal p => ToDocumentStatus(p),
            _ => throw new ArgumentTypeOutOfRangeException(parameter)
        };
        DocumentStatusParameterKindDto kind = DocumentStatusParameterKindDtoConverter.FromInternal(parameter.Kind);

        result.Kind = kind;
        result.Display = _kindDisplay[kind].Display;
        result.Description = _kindDisplay[kind].Description;
        result.Group = _kindDisplay[kind].Group;

        return result;
    }

    private static DocumentStatusParameterDto ToBoolean(BooleanDocumentStatusParameterInternal parameter)
    {
        var asBoolean = new BooleanDocumentStatusParameterDto
        {
            Value = parameter.Value
        };

        var result = new DocumentStatusParameterDto
        {
            AsBoolean = asBoolean
        };

        return result;
    }

    private static DocumentStatusParameterDto ToString(StringDocumentStatusParameterInternal parameter)
    {
        var asString = new StringDocumentStatusParameterDto
        {
            Value = parameter.Value
        };

        var result = new DocumentStatusParameterDto
        {
            AsString = asString
        };

        return result;
    }

    private static DocumentStatusParameterDto ToReferenceAttribute(ReferenceAttributeDocumentStatusParameterInternal parameter)
    {
        var referenceType = MetadataConverterTo.ToString(parameter.ReferenceType);

        string[] values = parameter.Values.Select(IdConverterTo.ToString).ToArray();

        var asReferenceAttribute = new ReferenceAttributeDocumentStatusParameterDto
        {
            ReferenceType = referenceType,
            Values = { values },
            IsArray = parameter.IsArray
        };

        var result = new DocumentStatusParameterDto
        {
            AsReferenceAttribute = asReferenceAttribute
        };

        return result;
    }

    private static DocumentStatusParameterDto ToDocumentStatus(DocumentStatusDocumentStatusParameterInternal parameter)
    {
        string? value = NullableConverter.Convert(parameter.Value, IdConverterTo.ToString);

        var asDocumentStatus = new DocumentStatusDocumentStatusParameterDto
        {
            Value = value
        };

        var result = new DocumentStatusParameterDto
        {
            AsDocumentStatus = asDocumentStatus
        };

        return result;
    }

    private sealed record ParameterMetaInfo(string Display, string? Description = null, string? Group = null);
}
