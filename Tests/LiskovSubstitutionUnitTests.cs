using Moq;
using Xunit;
using System.Collections.Generic;

namespace solid_principles_in_c_sharp.Tests
{
    public class LiskovSubstitutionUnitTests
    {
        [Fact]
        public void GetTextFromFiles_ReturnsConcatenatedText()
        {
            // Arrange
            var readableFileMock1 = new Mock<IReadableSqlFile>();
            readableFileMock1.Setup(rf => rf.LoadText()).Returns("File1Content");

            var readableFileMock2 = new Mock<IReadableSqlFile>();
            readableFileMock2.Setup(rf => rf.LoadText()).Returns("File2Content");

            var readableFiles = new List<IReadableSqlFile> { readableFileMock1.Object, readableFileMock2.Object };

            var sqlFileManager = new SqlFileManager();

            // Act
            var result = sqlFileManager.GetTextFromFiles(readableFiles);

            // Assert
            Assert.Equal("File1ContentFile2Content", result);
        }

        [Fact]
        public void SaveTextIntoFiles_CallsSaveTextOnAllFiles()
        {
            // Arrange
            var writableFileMock1 = new Mock<IWritableSqlFile>();
            writableFileMock1.Setup(wf => wf.SaveText());

            var writableFileMock2 = new Mock<IWritableSqlFile>();
            writableFileMock2.Setup(wf => wf.SaveText());

            var writableFiles = new List<IWritableSqlFile> { writableFileMock1.Object, writableFileMock2.Object };

            var sqlFileManager = new SqlFileManager();

            // Act
            sqlFileManager.SaveTextIntoFiles(writableFiles);

            // Assert
            writableFileMock1.Verify(wf => wf.SaveText(), Times.Once);
            writableFileMock2.Verify(wf => wf.SaveText(), Times.Once);
        }
    }
}

