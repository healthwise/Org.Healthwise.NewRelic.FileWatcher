using System;
using System.Collections.Generic;
using NewRelic.Platform.Sdk;
using NewRelic.Platform.Sdk.Utils;

namespace org.healthwise.newrelic.filewatcher
{
    class PluginAgent : Agent
    {
        private readonly string _name;
        private readonly Logger _log = Logger.GetLogger(typeof(PluginAgent).Name);
        private readonly FileWatcher _fileWatcher;


        public PluginAgent(string name, IList<FileItem> files)
        {
            _name = name;
            _fileWatcher = new FileWatcher(files);
        }

        public override void PollCycle()
        {
            try
            {
                var fileStatus = _fileWatcher.GetFileStatus();
                foreach (var displayName in fileStatus.Keys)
                {
                    float fileExists = fileStatus[displayName] ? 1 : 0;
                    _log.Info("Reporting Metric plugin/files/{0} {1}", displayName, fileExists);
                    ReportMetric("plugin/files/" + displayName, "value", fileExists);
                }

            }
            catch (Exception ex)
            {
                _log.Error("An Error Occured: '{0}'", ex.Message);
                _log.Error("Stacktrace: '{0}'", ex.StackTrace);
            }
        }

        public override string GetAgentName()
        {
            return this._name;
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