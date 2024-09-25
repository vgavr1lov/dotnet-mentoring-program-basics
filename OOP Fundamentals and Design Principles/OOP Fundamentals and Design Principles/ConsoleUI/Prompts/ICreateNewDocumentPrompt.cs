using CabinetLibrary;

namespace ConsoleUI
{
   public interface ICreateNewDocumentPrompt
   {
      ILibraryDocument PopulateData();

      Type GetLibraryDocumentType();
   }
}