# athena

Athena is a simple configuration manager for C#.

To use, create a configuration class with public static properties and add the Config attribute.

Each public static property will be set to the value specified in the config file read.

The default file it will look for is 'config.ini'. Otherwise a file name can be specified in the config attribute.

Here is an example server config.

```csharp
[Config]
public static class ServerConfig {

  public static short Port { get; set; }
}
```
And the corresponding config.ini

```
Port=8080
```
If you wanted the file to be custom.ini, then specify the file name. Config files must end with 'ini'.

```csharp
[Config(FileName = "custom.ini")]
```
