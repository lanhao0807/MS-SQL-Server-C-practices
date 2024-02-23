namespace app3
{
    public interface IPersonService
    {
        int CalculateAge(DateTime birthdate);
        decimal CalculateSalary();
        string GetAddresses();
    }
}
