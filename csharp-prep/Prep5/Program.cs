using System;

class Program
{
    // Function to display the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to prompt the user for their name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    // Function to prompt the user for their favorite number and return it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine());
        return favoriteNumber;
    }

    // Function to square a number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }

    // Main function to call the above functions and display the result
    static void Main()
    {
        DisplayWelcome(); // Display the welcome message
        
        string name = PromptUserName(); // Get the user's name
        int favoriteNumber = PromptUserNumber(); // Get the user's favorite number

        int squaredNumber = SquareNumber(favoriteNumber); // Square the favorite number

        DisplayResult(name, squaredNumber); // Display the final result
    }
}
