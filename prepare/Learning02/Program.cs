using System;

class Program
{
    static void Main(string[] args)
    {
        // Create Job instances
        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        Job job2 = new Job("Manager", "Apple", 2022, 2023);

        // Create a Resume instance
        Resume myResume = new Resume("Allison Rose");

        // Add jobs to resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display resume details
        myResume.DisplayResume();
    }
}
