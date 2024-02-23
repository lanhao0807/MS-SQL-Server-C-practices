namespace app3
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private DateTime Birthdate { get; set; }

        public Person(string firstName, string lastName, DateTime birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }

        public virtual int CalculateAge()
        {
            throw new NotImplementedException();
        }

        public virtual decimal CalculateSalary()
        {
            // a person might/might not have salary
            return 0;
        }

        public virtual string GetAddresses()
        {
            throw new NotImplementedException();
        }
    }
}
