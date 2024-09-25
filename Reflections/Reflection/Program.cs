namespace ReflectionHomeTask;
public class Program
{
   static bool isProviderChosen = false;
   static ConfigurationProvider chosenProvider;
   static void Main(string[] args)
   {
      while (true)
      {
         if (!isProviderChosen)
         {
            chosenProvider = ChooseProvider();
         }

         ChooseOption(chosenProvider);
         Console.ReadLine();
      }
   }

   private static ConfigurationProvider ChooseProvider()
   {
      Console.Clear();

      Console.WriteLine("Choose Config Provider:");
      foreach (var provider in Enum.GetValues(typeof(ConfigurationProvider)))
      {
         Console.WriteLine($"Enter {(int)provider} - {provider}");
      }

      while (true)
      {
         var choosenProvider = Console.ReadLine();

         if (int.TryParse(choosenProvider, out int parsedProvider) && Enum.IsDefined(typeof(ConfigurationProvider), parsedProvider))
         {
            isProviderChosen = true;
            return (ConfigurationProvider)parsedProvider;
         }
         else
         {
            Console.WriteLine("Incorrect input: please repeat.");
         }
      }
   }

   private static void ChooseOption(ConfigurationProvider chosenProvider)
   {
      Console.Clear();
      Console.WriteLine($"Selected provider {chosenProvider}");
      Console.WriteLine();
      Console.WriteLine("Enter 1 - View Settings");
      Console.WriteLine("Enter 2 - Load Settings");
      Console.WriteLine("Enter 3 - Modify Settings");
      Console.WriteLine("Enter 4 - Save Settings");
      Console.WriteLine("Enter 5 - Reselect Provider");

      try
      {
         var command = int.Parse(Console.ReadLine());
         var configurationComponentBase = new ConfigurationComponentBase();

         switch (command)
         {
            case 1:
               Console.Clear();
               foreach (var property in configurationComponentBase.ViewSettings(chosenProvider))
               {
                  Console.WriteLine(property.Item1);
                  Console.WriteLine(property.Item2);
               }
               break;
            case 2:
               Console.Clear();
               foreach (var property in configurationComponentBase.LoadSettings(chosenProvider))
               {
                  Console.WriteLine(property.Item1);
                  Console.WriteLine(property.Item2);
               }
               break;
            case 3:
               Console.Clear();
               Console.WriteLine("Modify Settings:");
               var properties = configurationComponentBase.ViewSettings(chosenProvider).ToArray();
               for (int i = 0; i < properties.Length; i++)
               {
                  Console.WriteLine($"Enter {i} - {properties[i]}");
               }
               while (true)
               {
                  var choosenProperty = int.Parse(Console.ReadLine());

                  if (choosenProperty >= 0 && choosenProperty < properties.Length)
                  {
                     Console.Clear();
                     Console.WriteLine($"Property {properties[choosenProperty].Item1}");
                     Console.WriteLine($"Old value: {properties[choosenProperty].Item2}");
                     Console.Write($"Enter new value: ");
                     var newPropertyValue = Console.ReadLine();
                     configurationComponentBase.UpdatePropertyValue(properties[choosenProperty].Item1, newPropertyValue);
                     break;
                  }
                  else
                  {
                     Console.WriteLine("Incorrect input: please repeat.");
                  }
               }
               break;
            case 4:
               Console.Clear();
               configurationComponentBase.SaveSettings(chosenProvider);
               Console.WriteLine("Settings saved!");
               break;
            case 5:
               isProviderChosen = false;
               return;

         }
      }
      catch (InvalidCastException ex)
      {
         Console.WriteLine($"Setting were not loaded: {ex.Message}");
      }
      catch (Exception)
      {
         Console.WriteLine("Incorrect input!");
      }
   }


}
