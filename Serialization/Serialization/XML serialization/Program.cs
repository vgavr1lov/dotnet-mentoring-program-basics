using System.Xml.Serialization;

namespace XML_serialization
{
   public class Program
   {
      private const string XmlSerializationFileName = "DepartmentData.xml";
      static void Main(string[] args)
      {
         var department = new Department();
         department.DepartmentName = "Accounting";
         department.Employees = new List<Employee>
         {
            new Employee {EmployeeName = "Marina Ivanova" },
            new Employee {EmployeeName = "Marina Sergeeva"},
            new Employee {EmployeeName = "Natalia Petrova"}
         };

         SerializeDepartment(department);
         Console.WriteLine(department.DepartmentName);
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
         var xmlSerializer = new XmlSerializer(typeof(Department));
         var streamWriter = new StreamWriter(XmlSerializationFileName);
         xmlSerializer.Serialize(streamWriter, department);
         streamWriter.Close();
      }

      private static Department? DeserializeDepartment()
      {
         var xmlSerializer = new XmlSerializer(typeof(Department));
         using var myFileStream = new FileStream(XmlSerializationFileName, FileMode.Open);
         var deserializedDepartmentData = (Department?)xmlSerializer.Deserialize(myFileStream);
         return deserializedDepartmentData;
      }
   }
}
