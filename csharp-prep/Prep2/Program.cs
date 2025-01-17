using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for the user input
        Console.Write("What is your grade percentage: ");
        string answer = Console.ReadLine();

        // Parse the input to an integer
        int percent = int.Parse(answer);

        string letter = "";
        string sign = "";
        
        // Determine the letter grade based on the grade percentage
        if (percent >= 90)
        {
            letter = "A";
            if (percent < 100) // A+ is not allowed
            {
                if (percent % 10 >= 7)
                {
                    sign = "+";
                }
                else if (percent % 10 < 3)
                {
                    sign = "-";
                }
            }
        }
        else if (percent >= 80)
        {
            letter = "B";
            if (percent % 10 >= 7)
            {
                sign = "+";
            }
            else if (percent % 10 < 3)
            {
                sign = "-";
            }
        }
        else if (percent >= 70)
        {
            letter = "C";
            if (percent % 10 >= 7)
            {
                sign = "+";
            }
            else if (percent % 10 < 3)
            {
                sign = "-";
            }
        }
        else if (percent >= 60)
        {
            letter = "D";
            if (percent % 10 >= 7)
            {
                sign = "+";
            }
            else if (percent % 10 < 3)
            {
                sign = "-";
            }
        }
        else
        {
            letter = "F";
        }

        // Handle special case for A+ and F+ or F- 
        if (letter == "A" && sign == "+")
        {
            sign = ""; 

        if (letter == "F")
        {
            sign = ""; 
        }

        // Print the letter grade with its sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (percent >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass. Better luck next time!");
        }
    }
}
}