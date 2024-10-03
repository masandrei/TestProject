namespace TestTaskMindSet.Shapes;

public class Triangle : IShape
{
    private double _a;
    private double _b;
    private double _c;
    public Triangle(double a, double b, double c)
    {
        if((a <= 0 || b <= 0 || c <= 0) ||
            a + b <= c || a + c <= b || b + c <= a)
        {
            throw new ArgumentException();
        }
        _a = a;
        _b = b;
        _c = c;
    }
    public double CalculateArea()
    {
        double halfPerimeter = (_a + _b + _c) / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - _a) * (halfPerimeter - _b) * (halfPerimeter - _c));
    }
    public bool IsRightTriangle()
    {
        double aSquared = Math.Pow(_a, 2);
        double bSquared = Math.Pow(_b, 2);
        double cSquared = Math.Pow(_c, 2);
        return aSquared == bSquared + cSquared ||
               cSquared == aSquared + bSquared ||
               bSquared == cSquared + aSquared;
    }
}
