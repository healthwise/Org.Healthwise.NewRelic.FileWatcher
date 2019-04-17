using System;
using System.Collections.Generic;
using NewRelic.Platform.Sdk;
using NewRelic.Platform.Sdk.Utils;

namespace org.healthwise.newrelic.filewatcher
{
    class PluginAgent : Agent
    {
        private readonly string _name;
        private readonly string _path;
        private readonly string _hostname;
        private readonly Logger _log = Logger.GetLogger(typeof(PluginAgent).Name);


        public PluginAgent(string name, string path)
        {
            _name = name;
            _path = path;

            _hostname = System.Environment.MachineName;
        }

        public override void PollCycle()
        {
            try
            {
                float fileExists = System.IO.File.Exists(_path) ? 1 : 0;
                _log.Info("Reporting Metric plugin/file", fileExists);
                ReportMetric("plugin/file", "value", fileExists);
            }
            catch (Exception ex)
            {
                _log.Error("An Error Occured: '{0}'", ex.Message);
                _log.Error("Stacktrace: '{0}'", ex.StackTrace);
            }
        }

        public override string GetAgentName()
        {
            return $"{this._name} - {this._hostname}";
        }

        public override string Guid
        {
            get { return "org.healthwise.newrelic.filewatcher"; }
        }

        public override string Version
        {
            get { return typeof(PluginAgent).Assembly.GetName().Version.ToString(); }
        }
    }
}