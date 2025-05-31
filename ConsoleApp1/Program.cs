using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the first number: ");
        string input1 = Console.ReadLine();

        Console.Write("Enter the second number: ");
        string input2 = Console.ReadLine();

        DivideStrings(input1, input2);
    }

    static void DivideStrings(string num1, string num2)
    {
        try
        {
            int number1 = Convert.ToInt32(num1);
            int number2 = Convert.ToInt32(num2);

            int result = number1 / number2;

            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: One or both inputs were not valid numbers.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: One or both numbers are too large.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
