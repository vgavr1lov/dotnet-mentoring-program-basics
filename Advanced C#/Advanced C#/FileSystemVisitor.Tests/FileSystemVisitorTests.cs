using Autofac.Extras.Moq;
using FileSystemTraverseApp;
using Xunit;

namespace FileSystemTraverse.Tests
{
   public class FileSystemVisitorTests
   {

      [Theory]
      [ClassData(typeof(TraverseDirectoriesTestData))]
      public void TraverseDirectories_ReturnsFilteredDirectoriesWhenFilterAlgorithmIsProvided(string homeDirectory, string command, string[] directories, string[] result)
      {
         // Arrange
         Func<string, bool> filterAlgorithm = item => item.Contains(command, StringComparison.CurrentCultureIgnoreCase);
         var fileSystemVisitorWithFilter = new FileSystemVisitor(homeDirectory, filterAlgorithm);

         // Act
         var actual = fileSystemVisitorWithFilter.TraverseDirectories(directories, filterAlgorithm);

         // Assert
         Assert.Equal(actual, result);
      }

      [Theory]
      [ClassData(typeof(TraverseFilesTestData))]
      public void TraverseFiles_ReturnsFilteredFilesWhenFilterAlgorithmIsProvided(string homeDirectory, string command, string[] files, string[] result)
      {
         // Arrange
         Func<string, bool> filterAlgorithm = item => item.Contains(command, StringComparison.CurrentCultureIgnoreCase);
         var fileSystemVisitorWithFilter = new FileSystemVisitor(homeDirectory, filterAlgorithm);

         // Act
         var actual = fileSystemVisitorWithFilter.TraverseDirectories(files, filterAlgorithm);

         // Assert
         Assert.Equal(actual, result);
      }

      [Fact]
      public void GetDirectories_ValidityCall()
      {
         using (var mock = AutoMock.GetLoose())
         {
            // Arrange
            var sampleDirectories = GetSampleDirectories();
            mock.Mock<IDirectoryService>()
                .Setup(x => x.GetDirectories())
                .Returns(sampleDirectories);

            var fileSystemVisitor = new FileSystemVisitor("dummyPath", mock.Mock<IDirectoryService>().Object);

            // Act
            var actualDirectories = fileSystemVisitor.Traverse().ToArray(); 

            // Assert
            Assert.NotNull(actualDirectories);
            Assert.Equal(sampleDirectories.Length, actualDirectories.Length);
            Assert.Equal(sampleDirectories, actualDirectories);
         }
      }

      [Fact]
      public void GetFiles_ValidityCall()
      {
         using (var mock = AutoMock.GetLoose())
         {
            // Arrange
            var sampleFiles = GetSampleFiles();
            mock.Mock<IDirectoryService>()
                .Setup(x => x.GetFiles())
                .Returns(sampleFiles);

            var fileSystemVisitor = new FileSystemVisitor("dummyPath", mock.Mock<IDirectoryService>().Object);

            // Act
            var actualFiles = fileSystemVisitor.Traverse().ToArray();

            // Assert
            Assert.NotNull(actualFiles);
            Assert.Equal(sampleFiles.Length, actualFiles.Length);
            Assert.Equal(sampleFiles, actualFiles);
         }
      }

      private string[] GetSampleDirectories()
      {
         var files = new string[]
         {
            @"C:\Users\User1\subfolder1\",
            @"C:\Users\User1\subfolder2\",
            @"C:\Users\User2\subfolder1\",
            @"C:\Users\User2\subfolder2\",
         };

         return files;
      }

      private string[] GetSampleFiles()
      {
         var files = new string[]
         {
            @"C:\Users\User1\subfolder1\Old Library.dll",
            @"C:\Users\User2\subfolder1\Old Text.txt",
            @"C:\Users\User2\subfolder2\New library.dll",
            @"C:\Users\User2\subfolder1\New Text.txt",
         };

         return files;
      }
   }
}
