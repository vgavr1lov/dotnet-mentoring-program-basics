
namespace CabinetLibrary
{
   public interface IStorageHandler
   {
      //dynamic? ReadLibraryDocumentByDocumentNumber(string documentNumber);
      ILibraryDocument? ReadLibraryDocumentByDocumentNumber(string documentNumber);
      void SaveLibraryDocument(ILibraryDocument storedLibraryDocument, Type type, string documentNumber);

      string[]? GetAllLibraryDocuments();
   }
}