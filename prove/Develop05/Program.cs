using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }
    public DateTime LastCompletedDate { get; set; }

    // Constructor for the base goal class
    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsComplete = false;
        LastCompletedDate = DateTime.MinValue;
    }

    // Abstract method to record progress for the goal
    public abstract void RecordGoal();

    // Method to check if goal was completed today, and apply penalty if not
    protected bool IsGoalCompletedToday()
    {
        return LastCompletedDate.Date == DateTime.Today.Date;
    }

    // Abstract method to display goal details (added for displaying information)
    public abstract void DisplayGoal();
}

public class SimpleGoal : Goal
{
    // Constructor for SimpleGoal that calls the base class constructor
    public SimpleGoal(string name, int points) : base(name, points) { }

    // Override to mark the goal as complete
    public override void RecordGoal()
    {
        Console.WriteLine($"Have you completed the goal: {Name}? (yes/no): ");
        string input = Console.ReadLine();

        if (input.ToLower() == "yes")
        {
            IsComplete = true;
            Console.WriteLine($"You completed the goal: {Name} and earned {Points} points.");
        }
        else
        {
            Points -= 50;  // Deduct points if goal wasn't completed
            Console.WriteLine($"You did not complete the goal: {Name} today. {50} points deducted.");
        }

        LastCompletedDate = DateTime.Today;  // Update last completed date to today
    }

    // Override to display SimpleGoal details
    public override void DisplayGoal()
    {
        string completionStatus = IsComplete ? "Completed" : "Not Completed";
        Console.WriteLine($"{Name} - {completionStatus}, Points: {Points}");
    }
}

public class EternalGoal : Goal
{
    private int gainedPoints;

    // Constructor for EternalGoal that calls the base class constructor
    public EternalGoal(string name, int points) : base(name, points)
    {
        gainedPoints = 0;
    }

    // Override to add gained points every time the goal is recorded
    public override void RecordGoal()
    {
        Console.WriteLine($"Have you completed the eternal goal: {Name} today? (yes/no): ");
        string input = Console.ReadLine();

        if (input.ToLower() == "yes")
        {
            gainedPoints += 100;  // Add 100 points every time the goal is recorded
            Points += 100;  // Add the gained points to the total points
            Console.WriteLine($"You gained 100 points for your eternal goal: {Name}. Total points: {Points}");
        }
        else
        {
            Points -= 50;  // Deduct points if goal wasn't completed
            Console.WriteLine($"You did not complete the eternal goal: {Name} today. {50} points deducted.");
        }

        LastCompletedDate = DateTime.Today;  // Update last completed date to today
    }

    // Override to display EternalGoal details
    public override void DisplayGoal()
    {
        string completionStatus = IsGoalCompletedToday() ? "Completed Today" : "Not Completed Today";
        Console.WriteLine($"{Name} - {completionStatus}, Points: {Points}");
    }
}

public class ChecklistGoal : Goal
{
    private int timesCompleted;
    private int targetCompletion;

    // Constructor for ChecklistGoal
    public ChecklistGoal(string name, int points, int target) : base(name, points)
    {
        targetCompletion = target;
        timesCompleted = 0;
    }

    // Override to record progress for the checklist goal
    public override void RecordGoal()
    {
        Console.WriteLine($"Have you completed this checklist goal: {Name}? (yes/no): ");
        string input = Console.ReadLine();

        if (input.ToLower() == "yes")
        {
            timesCompleted++;
            Points += 50;  // Add 50 points each time the goal is recorded
            Console.WriteLine($"You completed {timesCompleted}/{targetCompletion} for goal: {Name}. Total points: {Points}");

            if (timesCompleted >= targetCompletion)
            {
                Points += 500;  // Bonus points when goal is fully completed
                Console.WriteLine($"Congratulations! You completed the goal: {Name} and earned bonus points! Total points: {Points}");
            }
        }
        else
        {
            Points -= 50;  // Deduct points if the goal wasn't completed
            Console.WriteLine($"You did not complete the goal: {Name} today. {50} points deducted.");
        }

        LastCompletedDate = DateTime.Today;  // Update last completed date to today
    }

    // Override to display ChecklistGoal details
    public override void DisplayGoal()
    {
        string completionStatus = (timesCompleted >= targetCompletion) ? "Completed" : $"Completed {timesCompleted}/{targetCompletion}";
        Console.WriteLine($"{Name} - {completionStatus}, Points: {Points}");
    }
}

// Program class to manage the goals
public class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int totalPoints = 0;

    public static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.WriteLine("Total Points: " + totalPoints);
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Add new goal");
            Console.WriteLine("2. Record progress");
            Console.WriteLine("3. View all goals");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddGoal();
                    break;
                case "2":
                    RecordProgress();
                    break;
                case "3":
                    ViewGoals();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    // Add a new goal
    private static void AddGoal()
    {
        Console.Clear();
        Console.WriteLine("Enter the name of the new goal:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the type of goal (Simple, Eternal, Checklist):");
        string type = Console.ReadLine();

        if (type.ToLower() == "simple")
        {
            Console.WriteLine("Enter the points for this goal:");
            int points = int.Parse(Console.ReadLine());
            goals.Add(new SimpleGoal(name, points));
        }
        else if (type.ToLower() == "eternal")
        {
            Console.WriteLine("Enter the points for this eternal goal:");
            int points = int.Parse(Console.ReadLine());
            goals.Add(new EternalGoal(name, points));
        }
        else if (type.ToLower() == "checklist")
        {
            Console.WriteLine("Enter the points for this checklist goal:");
            int points = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of times this goal needs to be completed:");
            int target = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, points, target));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    // Record progress for a goal
    private static void RecordProgress()
    {
        Console.Clear();
        Console.WriteLine("Select the goal number to record progress for:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].RecordGoal();
            totalPoints += goals[goalIndex].Points;  // Update the total points
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    // View all goals
    private static void ViewGoals()
    {
        Console.Clear();
        Console.WriteLine("Your goals:");

        foreach (var goal in goals)
        {
            goal.DisplayGoal();
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
