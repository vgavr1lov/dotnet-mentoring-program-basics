using IConfigurationProviderLibrary;

namespace ReflectionHomeTask.Providers;
public class FileConfigurationProvider : IConfigurationProvider
{
   private const string filePath = "Settings.txt";

   public string LoadSettings(string settingName)
   {
      try
      {
         var result = ReadSetting(settingName);
         return result;
      }
      catch (IOException)
      {
         return null;
      }
   }

   private string ReadSetting(string key)
   {
      try
      {
         string result = File.ReadLines(filePath).First(line => line.StartsWith(key))?.Split('=')[1] ?? throw new IOException("Settings Not Found.");
         return result;
      }
      catch (IOException)
      {
         throw;
      }
   }

   public void SaveSettings(string settingName, string value)
   {
      var lines = File.ReadAllLines(filePath).ToList();
      var index = lines.FindIndex(line => line.StartsWith(settingName));
      if (index >= 0)
      {
         lines[index] = $"{settingName}={value}";
      }
      else
      {
         lines.Add($"{settingName}={value}");
      }
      File.WriteAllLines(filePath, lines);
   }

}
