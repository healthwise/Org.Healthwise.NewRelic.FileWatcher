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
            IList<object> files = (IList<object>) properties["files"];

            if (string.IsNullOrEmpty(name) || files == null || files.Count == 0)
            {
                throw new ArgumentNullException("'name', and 'files' cannot be null or empty.  Do you have a 'config/plugin.json' file?");
            }

            IList<FileItem> fileItems = new List<FileItem>();
            IList<string> displayItems = new List<string>();
            foreach (var f in files)
            {
                IDictionary<string, object> fileObjItem = (IDictionary<string, object>)f;
                if (!fileObjItem.ContainsKey("displayName") || !fileObjItem.ContainsKey("path"))
                {
                    throw new ArgumentNullException("'displayName', and 'path' properties cannot be null or empty on the files array.");
                }

                var displayName = (string)fileObjItem["displayName"];

                if (displayItems.Contains(displayName))
                {
                    throw new ArgumentNullException("'displayName' has be be unique.");
                }

                displayItems.Add(displayName);

                fileItems.Add(new FileItem
                {
                    DisplayName = displayName,
                    Path = (string)fileObjItem["path"]
                });
            }


            return new PluginAgent(name, fileItems);
        }
    }
}