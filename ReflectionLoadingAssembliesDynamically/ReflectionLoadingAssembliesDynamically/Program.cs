using ReflectionLoadingAssembliesDynamically.Models;
using ReflectionLoadingAssembliesDynamically.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
        builder.Services.AddControllers();

        // Load plugins from the "Plugins" folder
        var pluginFolder = Path.Combine(builder.Environment.ContentRootPath, "Plugins");
        var plugins = PluginManager.LoadPlugins(pluginFolder);

        // Register plugins in the DI container
        foreach (var plugin in plugins)
        {
            builder.Services.AddSingleton(typeof(IPlugin), plugin);
        }

        var app = builder.Build();

        // Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}