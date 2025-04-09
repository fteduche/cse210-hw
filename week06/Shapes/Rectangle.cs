public class Rectangle : Shape
{
    private double _length;
    private double _width;

    /// <summary>
    /// Initializes a new instance of the Rectangle class.
    /// </summary>
    /// <param name="color">The color of the rectangle.</param>
    /// <param name="length">The length of the rectangle.</param>
    /// <param name="width">The width of the rectangle.</param>
    public Rectangle(string color, double length, double width) : base(color)
    {
        if (length < 0)
        {
            throw new ArgumentException("Length cannot be negative.", nameof(length));
        }
        if (width < 0)
        {
            throw new ArgumentException("Width cannot be negative.", nameof(width));
        }
        _length = length;
        _width = width;
    }

    /// <summary>
    /// Gets the area of the rectangle.
    /// </summary>
    /// <returns>The area of the rectangle.</returns>
    public override double GetArea()
    {
        return _length * _width;
    }
}
