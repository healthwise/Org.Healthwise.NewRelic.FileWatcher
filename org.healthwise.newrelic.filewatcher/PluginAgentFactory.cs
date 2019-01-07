using System;
using System.Collections.Generic;
using NewRelic.Platform.Sdk;

namespace org.healthwise.newrelic.filewatcher
{
    public class PluginAgentFactory : AgentFactory
    {
        public override Agent CreateAgentWithConfiguration(IDictionary<string, object> properties)
        {
            string name = (string) properties["name"];
            string path = (string) properties["path"];
                
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("'name', and 'path' cannot be null or empty.  Do you have a 'config/plugin.json' file?");
            }

            return new PluginAgent(name, path);
        }
    }
}