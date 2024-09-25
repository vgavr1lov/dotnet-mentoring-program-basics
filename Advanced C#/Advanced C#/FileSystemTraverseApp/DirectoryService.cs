using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemTraverseApp
{
   public class DirectoryService : IDirectoryService
   {
      private readonly string _path;
      private readonly string _fileMask;

      private static readonly SearchOption _searchOption = SearchOption.AllDirectories;
      public DirectoryService(string path, string fileMask)
      {
         _path = path;
         _fileMask = fileMask;
      }


      public string[] GetFiles()
      {
         return Directory.GetFiles(_path, _fileMask, _searchOption);
      }

      public string[] GetDirectories()
      {
         return Directory.GetDirectories(_path, _fileMask, _searchOption);
      }
   }
}
