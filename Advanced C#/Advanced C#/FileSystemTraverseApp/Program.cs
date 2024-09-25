using System;
using static FileSystemTraverseApp.FileSystemVisitor;

namespace FileSystemTraverseApp
{
   internal class Program
   {
      const string homeDirectory = @"C:\Users\Valentin_Gavrilov\Desktop\Training\.NET Mentoring Program Basics\Advanced C#\FileSystemTraverseApp";
      static void Main(string[] args)
      {
         var fileSystemVisitor = new FileSystemVisitor(homeDirectory);

         PrintFilteredItems(fileSystemVisitor.Traverse());
         Console.WriteLine("Apply a filter:");

         while (true)
         {
            var command = Console.ReadLine();
            if (command != null)
            {
               if (command.Contains("*")) // Search using filter mask
               {
                  Console.Clear();
                  Console.WriteLine($"Filter Mask: {command}");
                  var fileSystemVisitorWithFilterMask = new FileSystemVisitor(homeDirectory, command);
                  PrintFilteredItems(fileSystemVisitorWithFilterMask.Traverse());
               }
               else // Search using filter algorithm
               {
                  Console.Clear();
                  Console.WriteLine($"Filter is applied: {command}");

                  var fileSystemVisitorWithFilter = new FileSystemVisitor(homeDirectory, item => item.Contains(command, StringComparison.CurrentCultureIgnoreCase));
                  SubscribeToEvents(fileSystemVisitorWithFilter);
                  PrintFilteredItems(fileSystemVisitorWithFilter.Traverse());
               }
            }
            else
            {
               OutputInvalidCommand();
            }
         }
      }

      private static void PrintFilteredItems(IEnumerable<string> filteredItems)
      {
         foreach (var item in filteredItems)
         {
            Console.WriteLine(item);
         }
      }

      private static void SubscribeToEvents(FileSystemVisitor fileSystemVisitor)
      {
         fileSystemVisitor.OnSearchStart += FileSystemVisitor_OnSearchStart;
         fileSystemVisitor.OnSearchFinish += FileSystemVisitor_OnSearchFinish;
         fileSystemVisitor.OnDirectoryFound += FileSystemVisitor_OnDirectoryFound;
         fileSystemVisitor.OnFileFound += FileSystemVisitor_OnFileFound;
         fileSystemVisitor.OnFilteredDirectoryFound += FileSystemVisitor_OnFilteredDirectoryFound;
         fileSystemVisitor.OnFilteredFileFound += FileSystemVisitor_OnFilteredFileFound;
      }
      private static void OutputInvalidCommand()
      {
         Console.WriteLine("Invalid input");
      }

      private static void FileSystemVisitor_OnSearchFinish(object? sender, EventArgs e)
      {
         Console.WriteLine($"-->The search is finished at {DateTime.Now.TimeOfDay}<--");
      }

      private static void FileSystemVisitor_OnSearchStart(object? sender, EventArgs e)
      {
         Console.WriteLine($"-->The search is started at {DateTime.Now.TimeOfDay}<--");
      }

      private static void FileSystemVisitor_OnDirectoryFound(object? sender, string directory)
      {
         Console.WriteLine($"-->Directory found: {directory}<--");
      }

      private static void FileSystemVisitor_OnFileFound(object? sender, string file)
      {
         Console.WriteLine($"-->File found: {file}<--");
      }

      private static void FileSystemVisitor_OnFilteredDirectoryFound(object? sender, FilteredFoundEventArgs e)
      {
         if (!e.IsExcluded)
         {
            Console.WriteLine($"-->Filtered directory: {e.Item}<--");
         }
         else
         {
            Console.WriteLine($"-->Excluded directory: {e.Item}<--");
         }
      }

      private static void FileSystemVisitor_OnFilteredFileFound(object? sender, FilteredFoundEventArgs e)
      {
         if (!e.IsExcluded)
         {
            Console.WriteLine($"-->Filtered file: {e.Item}<--");
         }
         else
         {
            Console.WriteLine($"-->Excluded file: {e.Item}<--");
         }
      }
   }
}
