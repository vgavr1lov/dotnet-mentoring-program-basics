using System.Text.Json;

namespace Json_serialization
{
   public class Program
   {
      private const string JsonSerializationFileName = "DepartmentData.json";
      private static JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
      { 
         WriteIndented = true,
         IncludeFields = true
      };
      static void Main(string[] args)
      {
         var department = new Department();
         department.DepartmentName = "HR";
         department.Employees = new List<Employee>
         {
            new Employee {EmployeeName = "Elena Ivanova" },
            new Employee {EmployeeName = "Galina Antonova"},
            new Employee {EmployeeName = "Tatiana Artemova"}
         };

         SerializeDepartment(department);
         Console.WriteLine(department?.DepartmentName);
         foreach (var employee in department!.Employees)
         {
            Console.WriteLine(employee.EmployeeName);
         }

         department = null;
         if (department == null)
            Console.WriteLine("Department is null");

         department = DeserializeDepartment();
         Console.WriteLine(department?.DepartmentName);  
         foreach (var employee in department!.Employees!)
         {
            Console.WriteLine(employee.EmployeeName);
         }

      }
      private static void SerializeDepartment(Department department)
      {
         var jsonString = JsonSerializer.Serialize(department, jsonSerializerOptions);
         File.WriteAllText(JsonSerializationFileName, jsonString);
      }

      private static Department? DeserializeDepartment()
      {
         var jsonString = File.ReadAllText(JsonSerializationFileName);
         return JsonSerializer.Deserialize<Department>(jsonString, jsonSerializerOptions);
      }
   }
}
