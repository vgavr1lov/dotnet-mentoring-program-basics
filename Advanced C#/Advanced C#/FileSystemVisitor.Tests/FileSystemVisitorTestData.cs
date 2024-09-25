using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemTraverse.Tests
{
   using System.Collections;
   using System.Collections.Generic;

   public class TraverseDirectoriesTestData : IEnumerable<object[]>
   {
      public IEnumerator<object[]> GetEnumerator()
      {
         yield return new object[] { "any", "subfolder", new string[] { @"C:\Users\", @"C:\Users\User1", @"C:\Users\User2", @"C:\Users\User2\subfolder1", @"C:\Users\User2\subfolder2" }, new string[] { @"C:\Users\User2\subfolder1", @"C:\Users\User2\subfolder2" } };
         yield return new object[] { "any", "2", new string[] { @"C:\Users\", @"C:\Users\User1", @"C:\Users\User2", @"C:\Users\User2\subfolder1", @"C:\Users\User2\subfolder2" }, new string[] { @"C:\Users\User2", @"C:\Users\User2\subfolder1", @"C:\Users\User2\subfolder2" } };
         yield return new object[] { "any", "", new string[] { @"C:\Users\", @"C:\Users\User1", @"C:\Users\User2", @"C:\Users\User2\subfolder1", @"C:\Users\User2\subfolder2" }, new string[] { @"C:\Users\", @"C:\Users\User1", @"C:\Users\User2", @"C:\Users\User2\subfolder1", @"C:\Users\User2\subfolder2" } };
      }

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   }

   public class TraverseFilesTestData : IEnumerable<object[]>
   {
      public IEnumerator<object[]> GetEnumerator()
      {
         yield return new object[] { "any", ".xlsx", new string[] { @"C:\Users\User1\subfolder1\Old Library.dll", @"C:\Users\User2\subfolder1\New Text.txt", @"C:\Users\User2\subfolder2\New library.dll" }, new string[] { } };
         yield return new object[] { "any", ".dll", new string[] { @"C:\Users\User1\subfolder1\Old Library.dll", @"C:\Users\User2\subfolder1\New Text.txt", @"C:\Users\User2\subfolder2\New library.dll" }, new string[] { @"C:\Users\User1\subfolder1\Old Library.dll", @"C:\Users\User2\subfolder2\New library.dll" } };
         yield return new object[] { "any", "", new string[] { @"C:\Users\User1\subfolder1\Old Library.dll", @"C:\Users\User2\subfolder1\New Text.txt", @"C:\Users\User2\subfolder2\New library.dll" }, new string[] { @"C:\Users\User1\subfolder1\Old Library.dll", @"C:\Users\User2\subfolder1\New Text.txt", @"C:\Users\User2\subfolder2\New library.dll" } };
      }

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   }
}
