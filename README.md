# athena

Athena is a simple configuration manager for C#.

To use, create a configuration class with public static properties and add the Configuration attribute.

Each public static property will be set to the value specified in the config file read.

The default file it will look for is 'config.ini'. Otherwise a file name can be specified in the configuration attribute.

Here is an example server config.

```csharp
[Configuration]
public static class ServerConfig {

  public static short Port { get; set; }
}
```
And the corresponding config.ini

```
Port=8080
```
If you wanted a specific file name, then specify the file name in the configuration attribute constructor. Config file names must end with 'ini'.

```csharp
[Configuration(FileName = "custom.ini")]
```
Finally to load the configuration classes with values, call the LoadAllConfigs method in ConfigurationManager.
```csharp
public static void Main() {
  ConfigurationManager.LoadAllConfigs();
}
```
