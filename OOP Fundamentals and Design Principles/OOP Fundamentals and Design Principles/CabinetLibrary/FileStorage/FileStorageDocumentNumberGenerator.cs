namespace CabinetLibrary
{
   public class FileStorageDocumentNumberGenerator : IStorageDocumentNumberGenerator
   {
      private const string InitialDocumentNumber = "1";
      public string GenerateDocumentNumber()
      {
         var fileMask = DetermineFileMask();
         var files = Directory.GetFiles(FileStorageHandler.FileStorageFolder, fileMask, SearchOption.TopDirectoryOnly);
         if (files == null)
            return InitialDocumentNumber;

         var highestDocumentnumber = DetermineHighestDocumentNumbers(files);
         if (highestDocumentnumber == null)
            throw new ArgumentNullException("The system was not able to generate Document Number!");

         var parsedHighestDocumentnumber = int.Parse(highestDocumentnumber);

         return $"{parsedHighestDocumentnumber + 1}";
      }

      private string DetermineFileMask()
      {
         return $"*{FileStorageHandler.FileMask}*{FileStorageHandler.FileExtension}";
      }

      private string? DetermineHighestDocumentNumbers(string[] files)
      {
         return files.Select(f => Path.GetFileNameWithoutExtension(f).Split("#")[1]).ToArray().Max();
      }
   }
}
