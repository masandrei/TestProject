namespace TestTaskMindSet.Shapes;

public class Circle : IShape
{
    private double _radius;
    public Circle(double radius)
    {
        if(radius <= 0)
        {
            throw new ArgumentException("Circle radius has to be greater than zero");
        }
        _radius = radius;
    }
    public double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }
}
