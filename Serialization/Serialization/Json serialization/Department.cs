using System.Text.Json.Serialization;

namespace Json_serialization
{
   public class Department
   {
      [JsonPropertyOrder(-1)]
      [JsonPropertyName("Department")]
      public string? DepartmentName { get; set; }
      [JsonPropertyOrder(-2)]
      [JsonPropertyName("Employees")]
      public List<Employee>? Employees;
   }
}
