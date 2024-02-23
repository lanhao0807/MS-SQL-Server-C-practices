namespace app3
{
    public interface IStudentService : IPersonService
    {
        void EnrollInCourse(string course, char grade);
        decimal CalculateGPA();
        void DisplayEnrolledCourses();
    }
}
