using System;
using System.Collections.Generic;

namespace EventManagement
{
    // Base class for Event
    public abstract class Event
    {
        // Properties common to all events
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }

        // Constructor to initialize event with common attributes
        public Event(string eventName, DateTime eventDate, string location)
        {
            EventName = eventName;
            EventDate = eventDate;
            Location = location;
        }

        // Abstract method for displaying specific event details (each subclass will implement this)
        public abstract void DisplayEventDetails();
    }

    // Subclass for Lecture event
    public class Lecture : Event
    {
        public string Speaker { get; set; }

        // Constructor calls base class constructor
        public Lecture(string eventName, DateTime eventDate, string location, string speaker)
            : base(eventName, eventDate, location)
        {
            Speaker = speaker;
        }

        // Override to display lecture-specific details
        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Lecture: {EventName}");
            Console.WriteLine($"Date: {EventDate.ToShortDateString()}");
            Console.WriteLine($"Location: {Location}");
            Console.WriteLine($"Speaker: {Speaker}\n");
        }
    }

    // Subclass for Reception event
    public class Reception : Event
    {
        public int GuestCount { get; set; }

        // Constructor calls base class constructor
        public Reception(string eventName, DateTime eventDate, string location, int guestCount)
            : base(eventName, eventDate, location)
        {
            GuestCount = guestCount;
        }

        // Override to display reception-specific details
        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Reception: {EventName}");
            Console.WriteLine($"Date: {EventDate.ToShortDateString()}");
            Console.WriteLine($"Location: {Location}");
            Console.WriteLine($"Guest Count: {GuestCount}\n");
        }
    }

    // Subclass for Outdoor Gathering event
    public class OutdoorGathering : Event
    {
        public bool IsWeatherDependent { get; set; }

        // Constructor calls base class constructor
        public OutdoorGathering(string eventName, DateTime eventDate, string location, bool isWeatherDependent)
            : base(eventName, eventDate, location)
        {
            IsWeatherDependent = isWeatherDependent;
        }

        // Override to display outdoor gathering-specific details
        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Outdoor Gathering: {EventName}");
            Console.WriteLine($"Date: {EventDate.ToShortDateString()}");
            Console.WriteLine($"Location: {Location}");
            Console.WriteLine($"Weather Dependent: {(IsWeatherDependent ? "Yes" : "No")}\n");
        }
    }

    class Program
    {
        // Lists to store different event types
        static List<Event> events = new List<Event>();

        static void Main(string[] args)
        {
            bool continueRunning = true;

            // Loop to keep the program running until the user chooses to exit
            while (continueRunning)
            {
                Console.WriteLine("Event Management System");
                Console.WriteLine("1. Add Lecture Event");
                Console.WriteLine("2. Add Reception Event");
                Console.WriteLine("3. Add Outdoor Gathering Event");
                Console.WriteLine("4. View All Events");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                // Handling the user's menu selection
                switch (choice)
                {
                    case "1":
                        AddLectureEvent();
                        break;
                    case "2":
                        AddReceptionEvent();
                        break;
                    case "3":
                        AddOutdoorGatheringEvent();
                        break;
                    case "4":
                        ViewAllEvents();
                        break;
                    case "5":
                        continueRunning = false; // Exit the loop
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        // Add a lecture event, prompting the user for details
        static void AddLectureEvent()
        {
            Console.WriteLine("\nEnter details for a lecture event:");
            Console.Write("Event Name: ");
            string name = Console.ReadLine();
            Console.Write("Event Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Location: ");
            string location = Console.ReadLine();
            Console.Write("Speaker: ");
            string speaker = Console.ReadLine();

            // Add the new lecture event to the list
            events.Add(new Lecture(name, date, location, speaker));
            Console.WriteLine("Lecture event added successfully!\n");
        }

        // Add a reception event, prompting the user for details
        static void AddReceptionEvent()
        {
            Console.WriteLine("\nEnter details for a reception event:");
            Console.Write("Event Name: ");
            string name = Console.ReadLine();
            Console.Write("Event Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Location: ");
            string location = Console.ReadLine();
            Console.Write("Number of Guests: ");
            int guestCount = int.Parse(Console.ReadLine());

            // Add the new reception event to the list
            events.Add(new Reception(name, date, location, guestCount));
            Console.WriteLine("Reception event added successfully!\n");
        }

        // Add an outdoor gathering event, prompting the user for details
        static void AddOutdoorGatheringEvent()
        {
            Console.WriteLine("\nEnter details for an outdoor gathering event:");
            Console.Write("Event Name: ");
            string name = Console.ReadLine();
            Console.Write("Event Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Location: ");
            string location = Console.ReadLine();
            Console.Write("Is the event weather-dependent? (yes/no): ");
            bool isWeatherDependent = Console.ReadLine().ToLower() == "yes";

            // Add the new outdoor gathering event to the list
            events.Add(new OutdoorGathering(name, date, location, isWeatherDependent));
            Console.WriteLine("Outdoor gathering event added successfully!\n");
        }

        // Display details of all events added so far
        static void ViewAllEvents()
        {
            Console.WriteLine("\nAll Events:");

            if (events.Count == 0)
            {
                Console.WriteLine("No events recorded yet.\n");
                return;
            }

            // Display each event's details
            foreach (var eventItem in events)
            {
                eventItem.DisplayEventDetails();
            }
        }
    }
}
