using System;

class Program
{
    static void Main(string[] args)
    {
         // Create fractions using different constructors
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(3, 4);

        // Display fraction strings
        Console.WriteLine(fraction1.GetFractionString());  // Output: 1/1
        Console.WriteLine(fraction2.GetFractionString());  // Output: 5/1
        Console.WriteLine(fraction3.GetFractionString());  // Output: 3/4

        // Display decimal values
        Console.WriteLine(fraction1.GetDecimalValue());  // Output: 1
        Console.WriteLine(fraction2.GetDecimalValue());  // Output: 5
        Console.WriteLine(fraction3.GetDecimalValue());  // Output: 0.75

        // Use getters and setters
        fraction1.SetNumerator(2);
        fraction1.SetDenominator(3);
        Console.WriteLine(fraction1.GetFractionString());  // Output: 2/3
        Console.WriteLine(fraction1.GetDecimalValue());  // Output: 0.666666666666667

    }
}