using Moq;
using Microsoft.Extensions.Logging;

namespace solid_principles_in_c_sharp.Tests
{
    public class OpenClosedUnitTests
    {
        [Fact]
        public void Rectangle_Area_CalculatesCorrectly()
        {
            // Arrange
            var rectangle = new Rectangle { Height = 5, Width = 4 };

            // Act
            var area = rectangle.Area();

            // Assert
            Assert.Equal(20, area);
        }

        [Fact]
        public void Circle_Area_CalculatesCorrectly()
        {
            // Arrange
            var circle = new Circle { Radius = 3 };

            // Act
            var area = circle.Area();

            // Assert
            Assert.Equal(Math.PI * 9, area, 5);
        }
    }

    public class AreaCalculatorTests
    {
        [Fact]
        public void TotalArea_CalculatesCorrectly()
        {
            // Arrange
            var shapes = new Shape[]
            {
                new Rectangle { Height = 5, Width = 4 },
                new Circle { Radius = 3 }
            };

            var loggerMock = new Mock<ILogger>();

            var areaCalculator = new AreaCalculator(loggerMock.Object);

            // Act
            var totalArea = areaCalculator.TotalArea(shapes);

            // Assert
            Assert.Equal(20 + Math.PI * 9, totalArea, 5);
        }
    }
}

