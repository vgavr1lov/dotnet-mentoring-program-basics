using System.Xml.Serialization;

namespace Deep_Cloning
{
   [Serializable]
   public class Department: ICloneable
   {
      public string? DepartmentName { get; set; }
      public List<Employee>? Employees { get; set; }
      public object Clone()
      {
         return MemberwiseClone();
      }
      public object? DeepCloning()
      {
         var stream = new MemoryStream();
         var streamWriter = new StreamWriter(stream);
         var xmlSerializer = new XmlSerializer(typeof(Department));
         xmlSerializer.Serialize(stream, this);
         stream.Position = 0;
         return xmlSerializer.Deserialize(stream);
      }
   }
}
