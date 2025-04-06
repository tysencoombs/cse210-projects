using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    // Base class for Exercise
    public abstract class Exercise
    {
        // Properties for storing date and duration of the exercise
        public DateTime Date { get; set; }
        public double Duration { get; set; } // Duration in minutes

        // Constructor to initialize the exercise with date and duration
        public Exercise(DateTime date, double duration)
        {
            Date = date;
            Duration = duration;
        }

        // Abstract method to calculate calories burned, each exercise type will implement this differently
        public abstract double CalculateCaloriesBurned();

        // Display exercise details: date, duration, and calories burned
        public void DisplayExerciseDetails()
        {
            Console.WriteLine($"Date: {Date.ToShortDateString()}");
            Console.WriteLine($"Duration: {Duration} minutes");
            Console.WriteLine($"Calories Burned: {CalculateCaloriesBurned()} kcal");
        }
    }

    // Subclass for Running Exercise
    public class Running : Exercise
    {
        // Constructor calls base class constructor
        public Running(DateTime date, double duration) : base(date, duration) { }

        // Override the base method to calculate calories burned specifically for running
        public override double CalculateCaloriesBurned()
        {
            return Duration * 10; // 10 calories burned per minute of running
        }
    }

    // Subclass for Cycling Exercise
    public class Cycling : Exercise
    {
        // Constructor calls base class constructor
        public Cycling(DateTime date, double duration) : base(date, duration) { }

        // Override the base method to calculate calories burned specifically for cycling
        public override double CalculateCaloriesBurned()
        {
            return Duration * 8; // 8 calories burned per minute of cycling
        }
    }

    // Subclass for Swimming Exercise
    public class Swimming : Exercise
    {
        // Constructor calls base class constructor
        public Swimming(DateTime date, double duration) : base(date, duration) { }

        // Override the base method to calculate calories burned specifically for swimming
        public override double CalculateCaloriesBurned()
        {
            return Duration * 12; // 12 calories burned per minute of swimming
        }
    }

    class Program
    {
        // Lists to store exercises of each type
        static List<Exercise> runningExercises = new List<Exercise>();
        static List<Exercise> cyclingExercises = new List<Exercise>();
        static List<Exercise> swimmingExercises = new List<Exercise>();

        static void Main(string[] args)
        {
            bool continueRunning = true;

            // Loop until the user chooses to exit
            while (continueRunning)
            {
                Console.WriteLine("Exercise Tracking System");
                Console.WriteLine("1. Add Running Exercise");
                Console.WriteLine("2. Add Cycling Exercise");
                Console.WriteLine("3. Add Swimming Exercise");
                Console.WriteLine("4. View Running Exercises");
                Console.WriteLine("5. View Cycling Exercises");
                Console.WriteLine("6. View Swimming Exercises");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                // Handle the user's choice
                switch (choice)
                {
                    case "1":
                        AddRunningExercise();
                        break;
                    case "2":
                        AddCyclingExercise();
                        break;
                    case "3":
                        AddSwimmingExercise();
                        break;
                    case "4":
                        ViewExercises(runningExercises, "Running");
                        break;
                    case "5":
                        ViewExercises(cyclingExercises, "Cycling");
                        break;
                    case "6":
                        ViewExercises(swimmingExercises, "Swimming");
                        break;
                    case "7":
                        continueRunning = false; // Exit the loop
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        // Add a running exercise, prompting the user for details
        static void AddRunningExercise()
        {
            Console.WriteLine("\nEnter the details for a running exercise:");
            Console.Write("Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine()); // Parse date input
            Console.Write("Duration (in minutes): ");
            double duration = double.Parse(Console.ReadLine()); // Parse duration input

            // Add the new running exercise to the list
            runningExercises.Add(new Running(date, duration));
            Console.WriteLine("Running exercise added successfully!\n");
        }

        // Add a cycling exercise, prompting the user for details
        static void AddCyclingExercise()
        {
            Console.WriteLine("\nEnter the details for a cycling exercise:");
            Console.Write("Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine()); // Parse date input
            Console.Write("Duration (in minutes): ");
            double duration = double.Parse(Console.ReadLine()); // Parse duration input

            // Add the new cycling exercise to the list
            cyclingExercises.Add(new Cycling(date, duration));
            Console.WriteLine("Cycling exercise added successfully!\n");
        }

        // Add a swimming exercise, prompting the user for details
        static void AddSwimmingExercise()
        {
            Console.WriteLine("\nEnter the details for a swimming exercise:");
            Console.Write("Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine()); // Parse date input
            Console.Write("Duration (in minutes): ");
            double duration = double.Parse(Console.ReadLine()); // Parse duration input

            // Add the new swimming exercise to the list
            swimmingExercises.Add(new Swimming(date, duration));
            Console.WriteLine("Swimming exercise added successfully!\n");
        }

        // View a list of exercises, displaying details for each one
        static void ViewExercises(List<Exercise> exercises, string exerciseType)
        {
            Console.WriteLine($"\n{exerciseType} Exercises:");

            if (exercises.Count == 0)
            {
                Console.WriteLine("No exercises recorded yet.\n");
                return;
            }

            // Display each exercise's details
            foreach (var exercise in exercises)
            {
                exercise.DisplayExerciseDetails();
                Console.WriteLine();
            }
        }
    }
}
