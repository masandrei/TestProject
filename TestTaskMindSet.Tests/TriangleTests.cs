using TestTaskMindSet.Shapes;
using NUnit.Framework;

namespace TestTaskMindSet.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void CreateTriangle_NegativeSides_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(-1, -3, -3));
        }
        [Test]
        public void CreateTriangle_DoesNotSatisfyTriangleInequality_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1,2,3));
        }
        [Test]
        public void CreateTriangle_ValidArguments_CreatesTriangle()
        {
            Triangle test = new Triangle(1,3,3);
            Assert.NotNull(test);
        }
        [TestCase(5, 12, 13, 30)]
        [TestCase(5, 5, 8, 12)]
        [TestCase(30000, 40000, 50000, 600000000)]
        [TestCase(1, 1, 1, 0.433)]
        public void GetTriangleArea_Equal(double a, double b, double c, double expectedResult)
        {
            // Arrange
            Triangle test = new Triangle(a, b, c);
            // Act
            double calculatedArea = test.CalculateArea();
            // Assert
            Assert.That(calculatedArea, Is.EqualTo(expectedResult).Within(0.001));
        }
        [TestCase(5,12,13, true)]
        [TestCase(1.5,2,2.5, true)]
        [TestCase(1,3,3, false)]
        public void IsTriangleRight_Equal(double a, double b, double c,bool expectedResult)
        {
            // Arrange
            Triangle test = new Triangle(a,b,c);
            // Act
            bool isTriangleRight = test.IsRightTriangle();
            // Assert
            Assert.That(isTriangleRight, Is.EqualTo(expectedResult));
        }
    }
}