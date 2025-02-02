using System;

public class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Start();
    }

    private Journal journal;
    private Prompt prompt;

    public Program()
    {
        journal = new Journal();
        prompt = new Prompt();
    }

    // Main program flow: show menu and handle user input.
    public void Start()
    {
        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Display main menu to the user
    public void DisplayMenu()
    {
        Console.WriteLine("\nJournal Menu:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display journal entries");
        Console.WriteLine("3. Save journal to file");
        Console.WriteLine("4. Load journal from file");
        Console.WriteLine("5. Exit");
        Console.Write("Please choose an option: ");
    }

    // Prompt the user for input, create a new entry, and add it to the journal
    public void WriteNewEntry()
    {
        string randomPrompt = prompt.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {randomPrompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry(randomPrompt, response);
        journal.AddEntry(newEntry);

        Console.WriteLine("New entry added successfully!");
    }

    // Display all journal entries
    public void DisplayJournal()
    {
        if (journal.GetEntries().Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
        }
        else
        {
            journal.DisplayEntries();
        }
    }

    // Prompt the user for a filename and save the journal entries to that file
    public void SaveJournal()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine($"Journal saved to {filename}.");
    }

    // Prompt the user for a filename and load the journal entries from that file
    public void LoadJournal()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine($"Journal loaded from {filename}.");
    }
}

// Class to represent a journal entry
public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    // Constructor to initialize a new entry with the current date, prompt, and response
    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        Response = response;
    }

    // Display the entry details (date, prompt, and response)
    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}\n");
    }
}

// Class to manage the journal (store entries and save/load from files)
public class Journal
{
    private List<Entry> entries;

    // Constructor initializes the list of entries
    public Journal()
    {
        entries = new List<Entry>();
    }

    // Add a new entry to the journal
    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    // Return the list of journal entries
    public List<Entry> GetEntries()
    {
        return entries;
    }

    // Display all journal entries
    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            entry.DisplayEntry();
        }
    }

    // Save the journal entries to a file with a given filename
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    // Load journal entries from a file with a given filename
    public void LoadFromFile(string filename)
    {
        entries.Clear(); // Clear existing entries before loading new ones
        foreach (var line in File.ReadLines(filename))
        {
            var parts = line.Split('|');
            var entry = new Entry(parts[1], parts[2])
            {
                Date = parts[0]
            };
            entries.Add(entry);
        }
    }
}

// Class to manage prompts for the journal
public class Prompt
{
    private List<string> prompts;

    // Constructor initializes the list of journal prompts
    public Prompt()
    {
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "How did I grow spiritually today?",
            "How did I help someone today?",
            "What did I do today that I’m proud of?"
        };
    }

    // Return a random prompt from the list
    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return prompts[rand.Next(prompts.Count)];
    }
}
