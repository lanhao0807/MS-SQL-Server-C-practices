namespace app3
{
    public class Instructor : Person
    {
        public string Department { get; private set; }
        public DateTime JoinDate { get; private set; }

        public Instructor(string firstName, string lastName, DateTime birthdate, string department, DateTime joinDate)
            : base(firstName, lastName, birthdate)
        {
            Department = department;
            JoinDate = joinDate;
        }

        public override int CalculateAge()
        {
            throw new NotImplementedException();
        }

        public override decimal CalculateSalary()
        {
            // mocked salary info
            decimal baseSalary = 50000;
            decimal bonus = baseSalary * 0.1m;
            decimal salary = baseSalary + bonus;
            return Math.Max(salary, 0);
        }

        public override string GetAddresses()
        {
            throw new NotImplementedException();
        }

        public void SpecialInstructorMethod()
        {
            throw new NotImplementedException();
        }
    }
}
