namespace app3
{
    public class Fibonacci
    {
        public static void run(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                int fibonacciNumber = CalculateFibonacci(i);
                Console.Write(fibonacciNumber + " ");
            }
        }
        public static int CalculateFibonacci(int n)
        {
            if (n <= 1)
                return n;
            else
                return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        }
    }
}
