using StartUp.Server.Routing.Contracts;

namespace StartUp.Application.Contracts
{
    public interface IApplication
    {
	    void Start(IAppRouteConfig routeConfig);
    }
}
