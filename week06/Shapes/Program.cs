class Program
{
    static void Main()
    {
        // Create a list of shapes
        List<Shape> shapes = new List<Shape>();

        // Add shapes to the list
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        // Iterate through the list and display areas
        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.ToString());
        }
    }
}

