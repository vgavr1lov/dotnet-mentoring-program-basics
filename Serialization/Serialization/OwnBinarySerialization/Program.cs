using System.Runtime.Serialization.Formatters.Binary;

namespace OwnBinarySerialization
{
   public class Program
   {
      private const string BinarySerializationFileName = "PersonData.dat";
      static void Main(string[] args)
      {
         var person = new Person("Peter", 0);
         Serialize(person);
         person = null;
         person = Deserialize();

         Console.WriteLine(person.Name);
         Console.WriteLine(person.Id);

         var personList = new List<Person>() {
            new Person("Artem", 1),
            new Person("Natalia", 2),
            new Person("Marina", 3)
         };

         SerializePersonList(personList);
         personList = null;
         personList = DeserializePersonList();
         foreach (var p in personList)
         {
            Console.WriteLine(p.Name);
            Console.WriteLine(p.Id);
         }

      }

      private static void Serialize(Person person)
      {
         var stream = File.Open(BinarySerializationFileName,
            FileMode.Create);
#pragma warning disable SYSLIB0011 
         var formatter = new BinaryFormatter();
         formatter.Serialize(stream, person);
#pragma warning restore SYSLIB0011
         stream.Close();
      }

      private static Person Deserialize()
      {
         var stream = File.Open(BinarySerializationFileName, FileMode.Open);
#pragma warning disable SYSLIB0011 
         var formatter = new BinaryFormatter();
         var deserializedPersonData = (Person)formatter.Deserialize(stream);
#pragma warning restore SYSLIB0011

         stream.Close();
         return deserializedPersonData;
      }

      private static void SerializePersonList(List<Person> personList)
      {
         var stream = File.Open(BinarySerializationFileName,
            FileMode.Create);
#pragma warning disable SYSLIB0011 
         var formatter = new BinaryFormatter();
         formatter.Serialize(stream, personList);
#pragma warning restore SYSLIB0011
         stream.Close();
      }

      private static List<Person> DeserializePersonList()
      {
         var stream = File.Open(BinarySerializationFileName, FileMode.Open);
#pragma warning disable SYSLIB0011 
         var formatter = new BinaryFormatter();
         var deserializedPersonData = (List<Person>)formatter.Deserialize(stream);
#pragma warning restore SYSLIB0011

         stream.Close();
         return deserializedPersonData;
      }
   }


}
