using Moq;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace solid_principles_in_c_sharp.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void Register_ValidEmail_SendsEmail()
        {
            // Arrange
            var email = "user@example.com";
            var password = "password123";

            var emailServiceMock = new Mock<EmailService>(MockBehavior.Strict, new SmtpClient(), Mock.Of<ILogger>());
            emailServiceMock.Setup(es => es.ValidateEmail(email)).Returns(true);
            emailServiceMock.Setup(es => es.SendEmail(It.IsAny<MailMessage>())).Returns(true);

            var loggerMock = new Mock<ILogger>();

            var userService = new UserService(emailServiceMock.Object, loggerMock.Object);

            // Act
            userService.Register(email, password);

            // Assert
            emailServiceMock.Verify(es => es.ValidateEmail(email), Times.Once);
            emailServiceMock.Verify(es => es.SendEmail(It.Is<MailMessage>(m => m.To.ToString() == email && m.Subject == "Hi. How are you!")), Times.Once);
        }

        [Fact]
        public void Register_InvalidEmail_ThrowsValidationException()
        {
            // Arrange
            var email = "invalid-email";
            var password = "password123";

            var emailServiceMock = new Mock<EmailService>(MockBehavior.Strict, new SmtpClient(), Mock.Of<ILogger>());
            emailServiceMock.Setup(es => es.ValidateEmail(email)).Returns(false);

            var loggerMock = new Mock<ILogger>();

            var userService = new UserService(emailServiceMock.Object, loggerMock.Object);

            // Act & Assert
            var exception = Assert.Throws<ValidationException>(() => userService.Register(email, password));
            Assert.Equal("Email is not an email", exception.Message);

            emailServiceMock.Verify(es => es.ValidateEmail(email), Times.Once);
            emailServiceMock.Verify(es => es.SendEmail(It.IsAny<MailMessage>()), Times.Never);
        }
    }
}
