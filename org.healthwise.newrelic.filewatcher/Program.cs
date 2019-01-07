using System;
using System.IO;
using NewRelic.Platform.Sdk;

namespace org.healthwise.newrelic.filewatcher
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                //Validate config files
                CheckConfigFile();

                //Start New Relic Plugin
                Runner runner = new Runner();
                runner.Add(new PluginAgentFactory());
                runner.SetupAndRun();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured, unable to continue.\nMessage: {0}", e.Message);
                return -1;
            }

            return 0;
        }

        private static bool CheckConfigFile()
        {
            Console.WriteLine("Checking if config file exists");

            if (File.Exists("config/plugin.json"))
            {
                Console.WriteLine("plugin.json file exists");
            }
            else
            {
                throw new FileNotFoundException("plugin.json file not found");
            }

            return true;
        }
    }
}
