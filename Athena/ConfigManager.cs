using System.Collections.Generic;
using Athena.Attributes;
using Athena.Exceptions;
using System.Reflection;
using System.Linq;
using System.IO;
using System;

namespace Athena {

  public static class ConfigManager {

    private static readonly string DEFAULT_CONFIG_NAME = "config.ini";

    public static void LoadAllConfigs() {
      foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
        foreach (Type type in assembly.GetTypes()) {
          ConfigAttribute configAttribute = type.GetCustomAttribute<ConfigAttribute>();
          if (configAttribute != null) {
            Load(type, configAttribute);
          }
        }
      }
    }

    private static void Load(Type configType, ConfigAttribute configAttribute) {
      string fileName = configAttribute.FileName ?? DEFAULT_CONFIG_NAME;
      string resourceName = GetManifestResourceName(configType, fileName);
      if (resourceName == null) {
        throw new MissingConfigFileException(fileName);
      }
      Dictionary<string, string> configEntries = ReadConfigFile(configType, resourceName);
      foreach (PropertyInfo propertyInfo in configType.GetProperties(BindingFlags.Public | BindingFlags.Static)) {
        if (configEntries.TryGetValue(propertyInfo.Name, out string value)) {
          propertyInfo.SetValue(null, Convert.ChangeType(value, propertyInfo.PropertyType));
        }
      }
    }

    private static string GetManifestResourceName(Type configType, string fileName) {
      string[] fileNameParts = fileName.Split('.');
      if (fileNameParts.Length != 2 || fileNameParts.Last() != "ini") {
        throw new InvalidConfigFileNameException(fileName);
      }
      foreach (string resourceName in configType.Assembly.GetManifestResourceNames()) {
        string[] parts = resourceName.Split('.');
        if (parts[parts.Length - 2] == fileNameParts.First() && parts.Last() == "ini") {
          return resourceName;
        }
      }
      return null;
    }

    private static Dictionary<string, string> ReadConfigFile(Type configType, string name) {
      Dictionary<string, string> configEntries = new Dictionary<string, string>();
      using (Stream stream = configType.Assembly.GetManifestResourceStream(name)) {
        using (StreamReader streamReader = new StreamReader(stream)) {
          string line;
          while ((line = streamReader.ReadLine()) != null) {
            string[] keyValue = line.Split('=');
            if (keyValue.Length != 2) {
              throw new InvalidConfigEntryException(line);
            } else {
              configEntries.Add(keyValue[0], keyValue[1]);
            }
          }
        }
      }
      return configEntries;
    }
  }
}
