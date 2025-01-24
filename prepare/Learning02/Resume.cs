using System;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    // Constructor to initialize the Resume object
    public Resume(string name)
    {
        _name = name;
    }

    // Method to display resume details
    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (var job in _jobs)
        {
            job.DisplayJob();
        }
    }
}
