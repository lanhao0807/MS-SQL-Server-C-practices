namespace app3
{
    public class Student : Person
    {
        public string StudentId { get; private set; }

        public Student(string firstName, string lastName, DateTime birthdate, string studentId)
            : base(firstName, lastName, birthdate)
        {
            StudentId = studentId;
        }

        public override int CalculateAge()
        {
            throw new NotImplementedException();
        }

        public override decimal CalculateSalary()
        {   
            // students have no salary
            return 0;
        }

        public override string GetAddresses()
        {
            throw new NotImplementedException();
        }

        public void SpecialStudentMethod()
        {
            throw new NotImplementedException();
        }
    }
}
