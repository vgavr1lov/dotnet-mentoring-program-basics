using System.Xml.Serialization;

namespace XML_serialization
{
   public class Employee
   {
      [XmlElement(ElementName = "Name")]
      public string? EmployeeName { get; set; }
   }
}
