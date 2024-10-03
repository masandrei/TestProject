namespace TestTaskMindSet.Shapes;

public class Circle : IShape
{
    private double _radius;
    public Circle(double radius)
    {
        if(radius <= 0)
        {
            throw new ArgumentException("Радиус круга должен быть больше нуля");
        }
        _radius = radius;
    }
    public double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }
}
