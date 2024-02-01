using MediatR;

namespace TEG_api.CQRS.Querys.All.GetAllConfigurations
{
    public class GetAllConfigurationsQuery : IRequest<ListConfigurations>
    {
    }
}
