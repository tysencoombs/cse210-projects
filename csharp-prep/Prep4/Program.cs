using System;

class Program
{
    static void Main(string[] args)
    {
        // List to store user input numbers
        List<int> numbers = new List<int>();
        int userInput;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());
            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        } while (userInput != 0);

        // Calculate sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        double average = sum / (double)numbers.Count;

        // Find the maximum number
        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Find the smallest positive number (closest to zero)
        int smallestPositive = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num > 0 && num < smallestPositive)
            {
                smallestPositive = num;
            }
        }

        // Display the smallest positive number (if any)
        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers.");
        }

        // Sort the list and display it
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}