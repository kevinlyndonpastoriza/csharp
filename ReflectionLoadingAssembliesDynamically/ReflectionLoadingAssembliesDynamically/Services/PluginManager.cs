using ReflectionLoadingAssembliesDynamically.Models;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Loader;

namespace ReflectionLoadingAssembliesDynamically.Services
{
    public class PluginManager
    {
        public static IEnumerable<IPlugin> LoadPlugins(string pluginFolder)
        {
            List<IPlugin> plugins = new List<IPlugin>();

            if (!Directory.Exists(pluginFolder))
            {
                Directory.CreateDirectory(pluginFolder);
                return plugins;
            }

            // Get all .dll files in the plugin folder
            var pluginFiles = Directory.GetFiles(pluginFolder, "*.dll");

            foreach (var pluginFile in pluginFiles)
            {
                // Load the assembly
                var assemblyLoadContext = new AssemblyLoadContext(Path.GetFileNameWithoutExtension(pluginFile));
                var assembly = assemblyLoadContext.LoadFromAssemblyPath(Path.GetFullPath(pluginFile));

                // Find All types that implement IPlugin
                var pluginTypes = assembly.GetTypes()
                    .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                foreach (var type in pluginTypes)
                {
                    //Create an instance of the plugin
                    if (Activator.CreateInstance(type) is IPlugin plugin)
                    {
                        plugins.Add(plugin);
                        Console.WriteLine($"Loaded plugin: {plugin.Name}");
                    }
                }
            }

            return plugins;
        }

    }
}
