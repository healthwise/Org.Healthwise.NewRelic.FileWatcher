using System.Collections.Generic;
using System.Linq;
using NewRelic.Platform.Sdk.Utils;

namespace org.healthwise.newrelic.filewatcher
{
    public class FileWatcher
    {
        private readonly IList<FileItem> _fileItems;
        private readonly Logger _log = Logger.GetLogger(typeof(PluginAgent).Name);

        public FileWatcher(IList<FileItem> fileItems)
        {
            _fileItems = fileItems;
        }

        public IDictionary<string, bool> GetFileStatus()
        {
            return _fileItems.Select(f => new {f.DisplayName, Exists = System.IO.File.Exists(f.Path)})
                .ToDictionary(k => k.DisplayName, v => v.Exists);
        }

    }
}