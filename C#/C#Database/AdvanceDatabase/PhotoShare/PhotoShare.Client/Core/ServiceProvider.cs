using Microsoft.Extensions.DependencyInjection;
using PhotoShare.Data;

namespace PhotoShare.Client.Core
{
    public class ServiceProvider
    {
	    private ServiceCollection serviceCollection;

	    public  ServiceProvider()
	    {
			this.serviceCollection = new ServiceCollection();
		    ConfigureServiceCollection();
	    }
		

	    public ServiceCollection ConfigureServiceCollection()
	    {
			this.serviceCollection.AddDbContext<PhotoShareContext>();

		    //serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
		    //serviceCollection.AddTransient<IUserService, UserService>();
		    //serviceCollection.AddTransient<IPostService, PostService>();
		    //serviceCollection.AddTransient<ICategoryService, CategoryService>();
		    //serviceCollection.AddTransient<IReplyService, ReplyService>();

			this.serviceCollection.BuildServiceProvider();
		    return serviceCollection;
	    }
	}
}
