public class Circle : Shape
{
    private double _radius;

    /// <summary>
    /// Initializes a new instance of the Circle class.
    /// </summary>
    /// <param name="color">The color of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    public Circle(string color, double radius) : base(color)
    {
        if (radius < 0)
        {
            throw new ArgumentException("Radius cannot be negative.", nameof(radius));
        }
        _radius = radius;
    }

    /// <summary>
    /// Gets the area of the circle.
    /// </summary>
    /// <returns>The area of the circle.</returns>
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}
