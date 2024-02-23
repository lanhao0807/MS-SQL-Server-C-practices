namespace app3
{
    public interface IDepartmentService
    {
        Instructor HeadInstructor { get; set; }
        decimal Budget { get; set; }
        void AddCourse(string course);
        void DisplayOfferedCourses();
    }
}
