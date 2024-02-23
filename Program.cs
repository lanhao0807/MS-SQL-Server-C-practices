namespace app3
{
    class Program
    {
        static void Main()
        {
            //  1
            // ReverseNumber.run(null);

            //  2
            // Fibonacci.run(null);

            Color redColor = new Color(255, 0, 0);
            Color blueColor = new Color(0, 0, 255);
            Ball ball1 = new Ball(10, redColor);
            Ball ball2 = new Ball(15, blueColor);

            ball1.Throw();
            ball1.Throw();
            ball2.Throw();
            ball2.Throw();
            ball2.Throw();
            ball1.Pop();
            ball2.Pop();
            ball1.Throw();
            ball2.Throw();

            Console.WriteLine($"Ball 1 throw count: {ball1.GetThrowCount()}");
            Console.WriteLine($"Ball 2 throw count: {ball2.GetThrowCount()}");

        }
    }
}

