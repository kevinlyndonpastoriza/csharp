using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReflectionLoadingAssembliesDynamically.Models;

namespace ReflectionLoadingAssembliesDynamically.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class PluginController : ControllerBase
    {
        private readonly IEnumerable<IPlugin> _plugins;

        public PluginController(IEnumerable<IPlugin> plugins)
        {
            _plugins = plugins;
        }

        [HttpGet]
        public IActionResult ExecutePlugins() 
        {
            foreach (var plugin in _plugins)
            {
                plugin.Execute();
            }

            return Ok("Plugins Executed successfully.");
        }   
    }
}
