using System.Runtime.Serialization.Formatters.Binary;

namespace Binary_serialization
{
   public class Program
   {
      private const string BinarySerializationFileName = "DepartmenData.dat";
      static void Main(string[] args)
      {
         var department = new Department();
         department.DepartmentName = "IT";
         department.Employees = new List<Employee>
         {
            new Employee {EmployeeName = "Ivan Ivanov" },
            new Employee {EmployeeName = "Anton Antonov"},
            new Employee {EmployeeName = "Artem Artemov"}
         };

         SerializeDepartment(department);
         Console.WriteLine(department?.DepartmentName);
         foreach (var employee in department!.Employees!)
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
         var stream = File.Open(BinarySerializationFileName,
            FileMode.Create);
#pragma warning disable SYSLIB0011 
         var formatter = new BinaryFormatter();
         formatter.Serialize(stream, department);
#pragma warning restore SYSLIB0011
         stream.Close();
      }

      private static Department DeserializeDepartment()
      {
         var stream = File.Open(BinarySerializationFileName,
            FileMode.Open);
#pragma warning disable SYSLIB0011 
         var formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011

         var deserializedDepartmentData = (Department)formatter.Deserialize(stream);
         stream.Close();

         return deserializedDepartmentData;
      }
   }
}
