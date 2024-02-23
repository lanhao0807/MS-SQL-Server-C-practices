namespace app3
{
    public interface ICourseService
    {
        List<Student> GetEnrolledStudents();
        void EnrollStudent(Student student);
        void AssignInstructor(Instructor instructor);
        void DisplayCourseDetails();
    }
}
