namespace ReflectionHomeTask;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class ConfigurationItemAttribute : Attribute
{
   public ConfigurationProvider _providerType;

   public string _settingName;
   public ConfigurationItemAttribute(ConfigurationProvider providerType, string settingName)
   {
      _providerType = providerType;
      _settingName = settingName;
   }
}
