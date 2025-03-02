using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        // Main menu loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity"); // Added Gratitude Activity option
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Start();
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Start();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Start();
                    break;
                case "4":
                    GratitudeActivity gratitude = new GratitudeActivity(); // Create Gratitude Activity instance
                    gratitude.Start(); // Start Gratitude Activity
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please select again.");
                    break;
            }
        }
    }
}

abstract class MindfulnessActivity
{
    private string _activityName;
    private string _description;
    private int _duration;

    // Properties
    protected string ActivityName { get => _activityName; }
    protected string Description { get => _description; }
    protected int Duration { get => _duration; set => _duration = value; }

    // Constructor
    public MindfulnessActivity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    // Method to pause with animation
    protected void PauseWithAnimation()
    {
        int countdownTime = 3; // Duration of countdown animation
        for (int i = countdownTime; i > 0; i--)
        {
            Console.Write($"\rStarting in {i}...");
            Thread.Sleep(1000); // Wait for 1 second
        }
        Console.WriteLine("\nLet's begin!");
        Thread.Sleep(1000); // Brief pause before starting the activity
    }

    // Abstract methods to be implemented by derived classes
    public abstract void Start();
    public abstract void End();
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Start()
    {
        // Prompt for duration
        Console.Clear();
        Console.WriteLine(ActivityName);
        Console.WriteLine(Description);
        Console.Write("How long would you like to do this activity? (in seconds): ");
        Duration = int.Parse(Console.ReadLine());
        PauseWithAnimation();

        // Breathing cycle
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(4000); // Breathe in for 4 seconds
            Console.WriteLine("Breathe out...");
            Thread.Sleep(4000); // Breathe out for 4 seconds
        }

        End();
    }

    public override void End()
    {
        Console.WriteLine("Good job! You've completed the Breathing Activity.");
        PauseWithAnimation();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void Start()
    {
        // Prompt for duration
        Console.Clear();
        Console.WriteLine(ActivityName);
        Console.WriteLine(Description);
        Console.Write("How long would you like to do this activity? (in seconds): ");
        Duration = int.Parse(Console.ReadLine());
        PauseWithAnimation();

        // Random prompt
        Random rand = new Random();
        string selectedPrompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(selectedPrompt);

        // Ask questions
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            string selectedQuestion = questions[rand.Next(questions.Count)];
            Console.WriteLine(selectedQuestion);
            Thread.Sleep(3000); // Pause for a few seconds before the next question
        }

        End();
    }

    public override void End()
    {
        Console.WriteLine("Good job! You've completed the Reflection Activity.");
        PauseWithAnimation();
    }
}

class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Start()
    {
        // Prompt for duration
        Console.Clear();
        Console.WriteLine(ActivityName);
        Console.WriteLine(Description);
        Console.Write("How long would you like to do this activity? (in seconds): ");
        Duration = int.Parse(Console.ReadLine());
        PauseWithAnimation();

        // Random prompt
        Random rand = new Random();
        string selectedPrompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(selectedPrompt);

        // Prompt user to list items
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        List<string> userList = new List<string>();
        while (DateTime.Now < endTime)
        {
            Console.Write("Please list an item: ");
            string item = Console.ReadLine();
            userList.Add(item);
        }

        // Show the user's list
        Console.WriteLine($"You listed {userList.Count} items!");
        End();
    }

    public override void End()
    {
        Console.WriteLine("Good job! You've completed the Listing Activity.");
        PauseWithAnimation();
    }
}

// Exceeding Requirements
// For creativity, the user as asked for input on what they are grateful for as an activity. 
class GratitudeActivity : MindfulnessActivity
{
    public GratitudeActivity() : base("Gratitude Activity", "This activity will help you focus on the things you're grateful for. Take time to list things that bring you happiness and peace.")
    {
    }

    public override void Start()
    {
        // Prompt for duration
        Console.Clear();
        Console.WriteLine(ActivityName);
        Console.WriteLine(Description);
        Console.Write("How long would you like to do this activity? (in seconds): ");
        Duration = int.Parse(Console.ReadLine());
        PauseWithAnimation();

        // Gratitude listing
        List<string> userGratitudes = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("What are you grateful for right now? ");
            string gratitude = Console.ReadLine();
            userGratitudes.Add(gratitude);
        }

        // Display list of gratitudes
        Console.WriteLine("\nGreat job! Here are the things you are grateful for:");
        foreach (string gratitude in userGratitudes)
        {
            Console.WriteLine($"- {gratitude}");
        }

        End();
    }

    public override void End()
    {
        Console.WriteLine("Good job! You've completed the Gratitude Activity.");
        PauseWithAnimation();
    }
}
