public class Square : Shape
{
    private double _side;

    /// <summary>
    /// Initializes a new instance of the Square class.
    /// </summary>
    /// <param name="color">The color of the square.</param>
    /// <param name="side">The side length of the square.</param>
    public Square(string color, double side) : base(color)
    {
        if (side < 0)
        {
            throw new ArgumentException("Side length cannot be negative.", nameof(side));
        }
        _side = side;
    }

    /// <summary>
    /// Gets the area of the square.
    /// </summary>
    /// <returns>The area of the square.</returns>
    public override double GetArea()
    {
        return _side * _side;
    }
}