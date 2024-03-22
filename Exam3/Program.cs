using System;
using System.Security.Cryptography.X509Certificates;

namespace firstTaskProgram

{

public class firstTaskProgram

{
    public static double Square(double number)

    {
        return number * number;
    }

    public static double converter(double inches)

    {
        return inches * 25.4;
    }

    public static double SquareRoot(double number)

    {
        return Math.Sqrt(number);
    }

    public static double Cube(double number)

    {
        return number * number * number;
    }

    public static double CircleArea(double radius)

    {
        return Math.PI * Square(radius);
    }

    public static string Greet(string name)

    {
        return "Hello, " + name + "!";
    }

       public static void firstTaskMain(string[] args)
    {
        // Example usage for testing
        double number = 5;
        Console.WriteLine("Square of " + number + ": " + Square(number));

        double inches = 2;
        Console.WriteLine("Length of " + inches + " inches in mm: " + converter(inches));

        double numberForSquareRoot = 16;
        Console.WriteLine("Square root of " + numberForSquareRoot + ": " + SquareRoot(numberForSquareRoot));

        double numberForCube = 3;
        Console.WriteLine("Cube of " + numberForCube + ": " + Cube(numberForCube));

        double radius = 4;
        Console.WriteLine("Area of a circle with radius " + radius + ": " + CircleArea(radius));

        string name = "Ole";
        Console.WriteLine(Greet(name));
    }

}

}