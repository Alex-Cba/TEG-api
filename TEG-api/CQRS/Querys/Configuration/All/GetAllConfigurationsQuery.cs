using MediatR;

namespace TEG_api.CQRS.Querys.Configuration.All
{
    public class GetAllConfigurationsQuery : IRequest<ListConfigurations>
    {
    }
}
