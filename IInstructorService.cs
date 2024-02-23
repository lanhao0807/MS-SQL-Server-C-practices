namespace app3
{
    public interface IInstructorService : IPersonService
    {
        string Department { get; }
        int CalculateExperienceYears(DateTime joinDate);
        decimal CalculateInstructorSalary();
        void AssignDepartment(string department);
    }
}
