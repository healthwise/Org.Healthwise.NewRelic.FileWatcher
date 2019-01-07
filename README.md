# Org.Healthwise.NewRelic.FileWatcher
New Relic Plugin for Monitoring File System

# Metrics
This plugin will query the existence of file(s) on a file system.

# Requirements
1. .Net 4.5

# Configuration

```
{
  "agents": [
    {
      "name": "A File",
      "path": "C:\\Path\\To\\A\\File.txt"
    },
    {
      "name": "Another File",
      "path": "C:\\Path\\To\\Another\\File.txt"
    }
  ]
}
```

### Configuration Elements
```
    name: "{String}"
```
   * Represents the name of the file watcher agent being deployed

```
    "path": "{String}:
```
   * Absolute path to the file being watched.

# Installation
1. Download release and unzip on machine to handle monitoring.
2. Edit Config Files
    rename newrelic.template.json to newrelic.json
    Rename plugin.template.json to plugin.json
    Update settings in both config files for your environment
3. Run plugin.exe from Command line

Use NPI to install the plugin to register as a service

1. Run Command as admin: npi install org.healthwise.newrelic.filewatcher
2. Follow on screen prompts
