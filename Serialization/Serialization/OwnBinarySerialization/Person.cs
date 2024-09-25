using System.Runtime.Serialization;

namespace OwnBinarySerialization
{
   [Serializable]
   public class Person: ISerializable
   {
      private const string  NameKey = "PersonName";
      private const string IdKey = "PersonId";
      public string? Name { get; }
      public int? Id { get; }

      public Person(string name, int id)
      {
         Name = name;
         Id = id;
      }
      public void GetObjectData(SerializationInfo info, StreamingContext context)
      {
         info.AddValue(NameKey, Name);
         info.AddValue(IdKey, Id);
      }

      public Person(SerializationInfo info, StreamingContext context)
      {
         Name = (string?)info.GetValue(NameKey, typeof(string));
         Id = (int?)info.GetValue(IdKey, typeof(int));
      }

   }
}
