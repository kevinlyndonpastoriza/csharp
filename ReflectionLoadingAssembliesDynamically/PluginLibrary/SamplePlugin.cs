using ReflectionLoadingAssembliesDynamically.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginLibrary
{
    public class SamplePlugin : IPlugin
    {
        public string Name => "Sample Plugin";

        public void Execute()
        {
            Console.WriteLine("Sample Plugin is executing!");
        }
    
    }
}
