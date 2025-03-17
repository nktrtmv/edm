using Edm.DocumentGenerators.GenericSubdomain.Domain.ApplicationEvents;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors.Contexts;

public sealed record ApplicationEventProcessContext<T>(T Host, ApplicationEvent ApplicationEvent);
