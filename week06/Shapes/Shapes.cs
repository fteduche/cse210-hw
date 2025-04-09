public abstract class Shape
{
    /// <summary>
    /// Gets or sets the color of the shape.
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// Initializes a new instance of the Shape class.
    /// </summary>
    /// <param name="color">The color of the shape.</param>
    protected Shape(string color)
    {
        Color = color;
    }

    /// <summary>
    /// Gets the area of the shape.
    /// </summary>
    /// <returns>The area of the shape.</returns>
    public abstract double GetArea();

    /// <summary>
    /// Returns a string representation of the shape.
    /// </summary>
    /// <returns>A string representation of the shape.</returns>
    public override string ToString()
    {
        return $"Color: {Color}, Area: {GetArea()}";
    }
}
