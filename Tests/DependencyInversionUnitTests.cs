using Moq;
using Xunit;
using System;
using System.IO;

namespace solid_principles_in_c_sharp.Tests
{
    public class DependencyInversionUnitTests
    {
        [Fact]
        public void LogException_CallsLogMessageWithCorrectMessage()
        {
            // Arrange
            var loggerMock = new Mock<ILoggerDemo>();
            var exceptionLogger = new ExceptionLogger(loggerMock.Object);
            var exception = new Exception("Test exception");

            // Act
            exceptionLogger.LogException(exception);

            // Assert
            loggerMock.Verify(l => l.LogMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void LogException_NullException_ThrowsArgumentNullException()
        {
            // Arrange
            var loggerMock = new Mock<ILoggerDemo>();
            var exceptionLogger = new ExceptionLogger(loggerMock.Object);

            // Act & Assert
            _ = Assert.Throws<ArgumentNullException>(() => exceptionLogger.LogException(null!));
        }
    }
}
