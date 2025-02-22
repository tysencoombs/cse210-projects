public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor to initialize both base class and specific attributes
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to get writing assignment information
    public string GetWritingInformation()
    {
        string studentName = GetStudentName();
        return $"{_title} by {_studentName}";
    }
}
