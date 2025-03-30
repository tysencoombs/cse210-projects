public class MathAssignment : Assignment
{
    private string _section;
    private string _problems;

    // Constructor to initialize both base class and specific attributes
    public MathAssignment(string studentName, string topic, string section, string problems)
        : base(studentName, topic)
    {
        _section = section;
        _problems = problems;
    }

    // Method to display homework list
    public string GetHomeworkList()
    {
        return $"Section {_section} Problems {_problems}";
    }
}
