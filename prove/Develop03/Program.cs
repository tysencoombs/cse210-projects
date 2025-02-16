// Program.cs
using System;

// CREATIVITY
// I added a scripture library for it to choose from 
// each time the program is ran.

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Scripture Memorizer!");
            ScriptureLibrary library = new ScriptureLibrary();
            bool quit = false;

            while (!quit)
            {
                // Get a random scripture from the library
                Scripture scripture = library.GetRandomScripture();

                // Display the full scripture to the user initially
                scripture.DisplayScripture();

                // Keep asking user to hide a word or quit until the scripture is fully hidden
                while (!scripture.AllWordsHidden())
                {
                    Console.WriteLine("\nPress Enter to hide a random word, or type 'quit' to exit.");
                    string input = Console.ReadLine().ToLower();

                    if (input == "quit")
                    {
                        quit = true;
                        break;  // Exit the outer while loop
                    }
                    else
                    {
                        // Hide a random word in the scripture
                        scripture.HideRandomWord();

                        // Display the scripture with some words hidden
                        scripture.DisplayScripture();
                    }
                }

                // If the scripture is completely memorized (all words hidden), congratulate the user
                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("\nCongratulations! You've hidden all the words and memorized the scripture!");
                }
            }

            Console.WriteLine("Thank you for using the Scripture Memorizer! Goodbye!");
        }
    }
}
