using System.Reflection;
using IConfigurationProviderLibrary;

namespace ReflectionHomeTask;
public class ConfigurationComponentBase
{
   [ConfigurationItem(ConfigurationProvider.ConfigurationManagerConfigurationProvider, nameof(CommonConfigParameter1)), ConfigurationItem(ConfigurationProvider.FileConfigurationProvider, nameof(CommonConfigParameter1))]
   public static int CommonConfigParameter1 { get; set; }

   [ConfigurationItem(ConfigurationProvider.ConfigurationManagerConfigurationProvider, nameof(CommonConfigParameter2)), ConfigurationItem(ConfigurationProvider.FileConfigurationProvider, nameof(CommonConfigParameter2))]
   public static float CommonConfigParameter2 { get; set; }

   [ConfigurationItem(ConfigurationProvider.ConfigurationManagerConfigurationProvider, nameof(SpecificConfigParameter1))]
   public static string SpecificConfigParameter1 { get; set; }

   [ConfigurationItem(ConfigurationProvider.FileConfigurationProvider, nameof(SpecificConfigParameter2))]
   public static TimeSpan SpecificConfigParameter2 { get; set; }

   public static void SaveSettings(string settingname, string providerType)
   {

   }

   public IEnumerable<Tuple<string, string>> LoadSettings(ConfigurationProvider provider)
   {
      var configurationProviderList = GetConfigurationProviders();

      var properties = GetType().GetProperties();
      foreach (var property in properties)
      {
         var attributes = property.GetCustomAttributes<ConfigurationItemAttribute>().ToArray();
         foreach (var attribute in attributes)
         {
            int providerIndex = configurationProviderList
            .FindIndex(p => p.GetType().Name.Contains(attribute._providerType.ToString()) && attribute._providerType == provider);

            if (providerIndex >= 0)
            {
               var configValue = configurationProviderList[providerIndex].LoadSettings(attribute._settingName);
               if (!string.IsNullOrEmpty(configValue))
               {
                  var value = ParseSettingValueIntoTargetType(configValue, property.PropertyType);
                  property.SetValue(null, value);

                  yield return new(property.Name, property.GetValue(null).ToString());
               }
            }
         }
      }
   }

   public IEnumerable<Tuple<string, string>> ViewSettings(ConfigurationProvider provider)
   {
      var properties = GetType().GetProperties()
          .Where(p => p.GetCustomAttributes<ConfigurationItemAttribute>()
          .Any(attr => attr._providerType == provider));

      foreach (var property in properties)
      {
       //  var value = ParseSettingValueIntoTargetType(property.GetValue(null), property.PropertyType);
         yield return new(property.Name, property.GetValue(null)?.ToString());
      }
   }

   public void SaveSettings(ConfigurationProvider provider)
   {
      var properties = GetType().GetProperties()
          .Where(p => p.GetCustomAttributes<ConfigurationItemAttribute>()
          .Any(attr => attr._providerType == provider));

      var configurationProvider = GetConfigurationProviders()
                     .First(p => p.GetType().Name.Contains(provider.ToString()));

      foreach (var property in properties)
      {
         configurationProvider.SaveSettings(property.Name, property.GetValue(null).ToString());

      }
   }

   //private List<IConfigurationProvider> GetConfigurationProviders()
   //{
   //   var configurationProviderList = new List<IConfigurationProvider>();

   //   var types = Assembly.GetExecutingAssembly().GetTypes();
   //   foreach (var type in types)
   //   {
   //      if (type.GetInterfaces().Contains((typeof(IConfigurationProvider))))
   //      {
   //         var configurationProvider = Activator.CreateInstance(type) as IConfigurationProvider;
   //         configurationProviderList.Add(configurationProvider);
   //      }
   //   }

   //   return configurationProviderList;
   //}

   private List<IConfigurationProvider> GetConfigurationProviders()
   {
      const string pluginsDirectory = @".\Plugins\";
      const string pluginsFileMask = "*.dll";

      var isDirectoryExists = Directory.Exists(pluginsDirectory);
      var configurationProviderList = new List<IConfigurationProvider>();

      foreach (var file in Directory.GetFiles(pluginsDirectory, pluginsFileMask))
      {
         var pluginTypes = Assembly.LoadFrom(file);
         foreach (var pluginType in pluginTypes.GetTypes())
         {
            if (pluginType.GetInterfaces().Contains((typeof(IConfigurationProvider))))
            {
               var configurationProvider = Activator.CreateInstance(pluginType) as IConfigurationProvider;
               configurationProviderList.Add(configurationProvider);
            }
         }
      }

      return configurationProviderList;
   }
   private object ParseSettingValueIntoTargetType(object value, Type type)
   {
      try
      {
         if (type == typeof(TimeSpan))
         {
            return TimeSpan.Parse(value.ToString());
         }
         return Convert.ChangeType(value, type);
      }
      catch (Exception)
      {
         throw;
      }
   }

   public void UpdatePropertyValue(string propertyName, string newValue)
   {
      var property = GetType().GetProperty(propertyName);
      var parsedValue = ParseSettingValueIntoTargetType(newValue, property.PropertyType);
      property.SetValue(null, parsedValue);
   }


}
