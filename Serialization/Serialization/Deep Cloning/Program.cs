namespace Deep_Cloning
{
   public class Program
   {
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

         //var department2 = (Department)department.Clone();
         var department2 = (Department?)department.DeepCloning();


         department.DepartmentName = "IT";
         department.Employees.Clear();
         department.Employees.Add(new Employee { EmployeeName = "Ivan Ivanov" } );
         department.Employees.Add(new Employee { EmployeeName = "Anton Antonov" });
         department.Employees.Add(new Employee { EmployeeName = "Artem Artemov" });



         Console.WriteLine(department?.DepartmentName);
         foreach (var employee in department!.Employees)
         {
            Console.WriteLine(employee.EmployeeName);
         }

         Console.WriteLine(department2?.DepartmentName);
         foreach (var employee in department2!.Employees!)
         {
            Console.WriteLine(employee.EmployeeName);
         }

      }
   }
}
