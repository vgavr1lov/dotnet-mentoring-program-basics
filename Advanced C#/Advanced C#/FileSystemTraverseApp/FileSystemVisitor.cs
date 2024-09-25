namespace FileSystemTraverseApp
{
   public class FileSystemVisitor : IDisposable
   {
      private readonly string _path;
      private readonly string _fileMask = "*";
      private readonly Func<string, bool>? _filterAlgorithm;
      private readonly IDirectoryService _directoryService;


      public event EventHandler? OnSearchStart;
      public event EventHandler? OnSearchFinish;
      public event EventHandler<string>? OnFileFound;
      public event EventHandler<string>? OnDirectoryFound;
      public event EventHandler<FilteredFoundEventArgs>? OnFilteredFileFound;
      public event EventHandler<FilteredFoundEventArgs>? OnFilteredDirectoryFound;


      public FileSystemVisitor(string path)
      {
         _path = path;
         _directoryService = GetDirectoryService();
      }

      public FileSystemVisitor(string path, IDirectoryService directoryService)
      {
         _path = path;
         _directoryService = directoryService;
      }

      public FileSystemVisitor(string path, string fileMask)
      {
         _path = path;
         _fileMask = fileMask;
         _directoryService = GetDirectoryService();
      }

      public FileSystemVisitor(string path, Func<string, bool> filterAlgorithm)
      {
         _path = path;
         _filterAlgorithm = filterAlgorithm;
         _directoryService = GetDirectoryService();
      }

      private IDirectoryService GetDirectoryService()
      {
         return new DirectoryService(_path, _fileMask);
      }
      public IEnumerable<string> Traverse()
      {
         OnSearchStart?.Invoke(this, EventArgs.Empty);

         var directories = _directoryService.GetDirectories();
         var files = _directoryService.GetFiles();

         foreach (var directory in TraverseDirectories(directories, _filterAlgorithm))
         {
            yield return directory;
         }

         foreach (var file in TraverseFiles(files, _filterAlgorithm))
         {
            yield return file;
         }

         OnSearchFinish?.Invoke(this, EventArgs.Empty);
      }

      public IEnumerable<string> TraverseDirectories(string[]? directories, Func<string, bool> filterAlgorithm)
      {
         if (directories == null)
         {
            yield break;
         }

         foreach (var directory in directories)
         {
            OnDirectoryFound?.Invoke(this, directory);
            if (filterAlgorithm == null || filterAlgorithm(directory))
            {
               OnFilteredDirectoryFound?.Invoke(this, new FilteredFoundEventArgs(directory, false));
               yield return directory;
            }
            else
            {
               OnFilteredDirectoryFound?.Invoke(this, new FilteredFoundEventArgs(directory, true));
            }
         }
      }

      public IEnumerable<string> TraverseFiles(string[]? files, Func<string, bool> filterAlgorithm)
      {

         if (files == null)
         {
            yield break;
         }

         foreach (var file in files)
         {
            OnFileFound?.Invoke(this, file);
            if (filterAlgorithm == null || filterAlgorithm(file))
            {
               OnFilteredDirectoryFound?.Invoke(this, new FilteredFoundEventArgs(file, false));
               yield return file;
            }
            else
            {
               OnFilteredDirectoryFound?.Invoke(this, new FilteredFoundEventArgs(file, true));
            }
         }
      }

      public void Dispose()
      {
         OnSearchStart = null;
         OnSearchFinish = null;
         OnDirectoryFound = null;
         OnFileFound = null;
         OnFilteredDirectoryFound = null;
         OnFilteredFileFound = null;
      }

      public class FilteredFoundEventArgs : EventArgs
      {
         public string? Item { get; set; }
         public bool IsExcluded { get; set; }
         public FilteredFoundEventArgs(string? item, bool isExcluded)
         {
            Item = item;
            IsExcluded = isExcluded;
         }
      }
   }
}
