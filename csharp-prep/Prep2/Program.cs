using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for the user's grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        
        // Convert the input to an integer
        int grade;
        
        // Try parsing the input
        if (int.TryParse(input, out grade))
        {
            string letterGrade = ""; // To store the letter grade
            string sign = ""; // To store the grade sign (e.g., "+", "-", or empty)
            
            // Determine the letter grade based on the grade percentage
            if (grade >= 90)
            {
                letterGrade = "A";
                if (grade % 10 >= 7)
                {
                    sign = "+";
                }
                else if (grade % 10 < 3)
                {
                    sign = "-";
                }
            }
            else if (grade >= 80)
            {
                letterGrade = "B";
                if (grade % 10 >= 7)
                {
                    sign = "+";
                }
                else if (grade % 10 < 3)
                {
                    sign = "-";
                }
            }
            else if (grade >= 70)
            {
                letterGrade = "C";
                if (grade % 10 >= 7)
                {
                    sign = "+";
                }
                else if (grade % 10 < 3)
                {
                    sign = "-";
                }
            }
            else if (grade >= 60)
            {
                letterGrade = "D";
                if (grade % 10 >= 7)
                {
                    sign = "+";
                }
                else if (grade % 10 < 3)
                {
                    sign = "-";
                }
            }
            else
            {
                letterGrade = "F";
            }

            // Handle special case for A+ (not allowed) and F+ or F- (not allowed)
            if (letterGrade == "A" && sign == "+")
            {
                sign = ""; // A+ is not valid
            }

            if (letterGrade == "F")
            {
                sign = ""; // F+ or F- is not valid
            }

            // Print the letter grade with its sign
            Console.WriteLine($"Your grade is: {letterGrade}{sign}");

            // Check if the user passed or failed
            if (grade >= 70)
            {
                Console.WriteLine("Congratulations, you passed the course!");
            }
            else
            {
                Console.WriteLine("Sorry, you did not pass. Better luck next time!");
            }
        }
        else
        {
            // Handle invalid input
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}