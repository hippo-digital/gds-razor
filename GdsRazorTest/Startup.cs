using GdsRazorTest.Tests.Internal;

namespace GdsRazorTest;

public interface IModelProvider
{
    public (string, object?) GetModel();
}


public class Startup
{
    private class ModelProvider : IModelProvider
    {
        public (string, object?) GetModel() => GdsCollection.Model;
    }

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        Env = env;
    }

    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Env { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddResponseCaching();
        services.AddAuthorization();
        services.AddServerSideBlazor();

        services.AddSingleton<IModelProvider>(new ModelProvider());

        services.AddControllersWithViews().AddRazorRuntimeCompilation();
    }
    
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCookiePolicy();
        app.UseForwardedHeaders();
        app.UseDeveloperExceptionPage();

        app.UseStatusCodePagesWithReExecute("/error/{0}");
        app.UseHttpsRedirection();
        app.UseResponseCaching();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
