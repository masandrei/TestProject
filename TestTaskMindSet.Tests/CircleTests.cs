using TestTaskMindSet.Shapes;

namespace TestTaskMindSet.Tests;
[TestFixture]
public class CircleTests
{
    [Test]
    public void CreateCircle_NegativeRadius_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Circle(-1));
    }
    [Test]
    public void CreateCircle_PositiveRadius_CreatesCircle()
    {
        Circle test = new Circle(1);

        Assert.NotNull(test);
    }
    [TestCase(2)]
    [TestCase(1.5)]
    [TestCase(100_000)]
    public void CalculateCircleArea_EqualTo(double radius)
    {
        // Arrange
        Circle test = new Circle(radius);
        double expectedCircleArea = Math.PI * radius * radius;
        //Act
        double obtainedCircleArea = test.CalculateArea();
        // Assert
        Assert.That(obtainedCircleArea, Is.EqualTo(expectedCircleArea).Within(0.001));
    }
}
