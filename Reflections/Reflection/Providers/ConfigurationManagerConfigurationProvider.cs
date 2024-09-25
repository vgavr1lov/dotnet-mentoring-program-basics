using IConfigurationProviderLibrary;
using System.Configuration;

namespace ReflectionHomeTask.Providers;
public class ConfigurationManagerConfigurationProvider : IConfigurationProvider
{
   public string LoadSettings(string settingName)
   {
      try
      {
         var result = ReadSetting(settingName);
         return result;
      }
      catch (ConfigurationErrorsException)
      {
         return null;
      }
   }

   public void SaveSettings(string settingName, string value)
   {
      try
      {
         var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
         var settings = configFile.AppSettings.Settings;
         if (settings[settingName] == null)
         {
            settings.Add(settingName, value);
         }
         else
         {
            settings[settingName].Value = value;
         }
         configFile.Save(ConfigurationSaveMode.Modified);
         ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
      }
      catch (ConfigurationErrorsException)
      {
         throw;
         // "Error writing app settings"
      }
   }


   private string ReadSetting(string key)
   {
      try
      {
         var appSettings = ConfigurationManager.AppSettings;
         string result = appSettings[key] ?? throw new ConfigurationErrorsException("Settings Not Found.");
         return result;
      }
      catch (ConfigurationErrorsException)
      {
         throw;
      }
   }
}
