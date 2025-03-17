using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Parameters;

internal static class DocumentNotificationParameterBffConverter
{
    public static DocumentNotificationParameterBff ToBff(DocumentNotificationParameterDto parameter)
    {
        var templateParameter = new DocumentNotificationTemplateParameterSlimBff
        {
            Id = parameter.TemplateParameterId
        };

        var result = new DocumentNotificationParameterBff
        {
            TemplateParameter = templateParameter,
            ValueAttributeId = parameter.ValueAttributeId
        };

        return result;
    }

    public static DocumentNotificationParameterDto ToDto(DocumentNotificationParameterBff parameter)
    {
        var result = new DocumentNotificationParameterDto
        {
            TemplateParameterId = parameter.TemplateParameter.Id,
            ValueAttributeId = parameter.ValueAttributeId
        };

        return result;
    }
}
