// 1. What type would you choose for the following “numbers”?
    // A person’s telephone number
        // string
    // A person’s height
        // float
    // A person’s age
        // byte 
    // A person’s gender (Male, Female, Prefer Not To Answer)
        // string
    // A person’s salary
        // float
    // A book’s ISBN
        // string
    // A book’s price
        // float
    // A book’s shipping weight
        // float
    // A country’s population
        // int
    // The number of stars in the universe
        // long
    // The number of employees in each of the small or medium businesses in the
    // United Kingdom (up to about 50,000 employees per business
        // ushort  

// 2. What are the difference between value type and reference type variables? What is
// boxing and unboxing?
    // value type store the actually data of a variable and other varibale gets a copy
        // int a = 5  ==> int b = a

    // reference type stores the address of a where the data is stored.
        // int[] arr1 = {1,2,3}  ==> int[] arr2 = arr1

    // boxing converts value type tp object type
        // int a = 5, object obj = a

    // unboxing converts object type back to value type
        // int num = (int)obj

// 3. What is meant by the terms managed resource and unmanaged resource in .NET
    // A managed resource is a resource that is under the control of the .NET runtime's garbage collector such as array, class instances
    // An unmanaged resource is a resource that is not automatically managed by the garbage collector. such as file handler, db connection
    
// 4. Whats the purpose of Garbage Collector in .NET?
    // it automatically reclaims memory that is no longer in use by the program, preventing memory leaks and improving the overall efficiency and reliability of .NET

// Console.WriteLine("what's going on");
// Console.WriteLine("playing with console app");
// Console.WriteLine("your hack name is " + Console.ReadLine());
// Console.WriteLine("what's your address");
// string address = Console.ReadLine();
// Console.WriteLine("your address is " + address);

using System;
namespace CenturyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // UnderstandingTypes();
            // centuriesConverter(1);
            // for ( ; true; ) ;
            // fizzBuzz();

            // int max = 500;
            // for (byte i = 0; i < max; i++) // byte 
            // {
            //     WriteLine(i); // Console.WriteLine(i)
            // }

            // for (byte i = 0; i < max; i++)
            // {
            //     if (i == byte.MaxValue)
            //     {
            //         Console.WriteLine("iterator i reaches its data type maximum.");
            //         break;
            //     }
            //     Console.WriteLine(i);
            // }

            // GuessNumberGame();
            // print_a_pryamid();
            // cal_days();

            // DateTime currentTime = DateTime.Now;
            // GreetUser(currentTime);

            // count24();
        }

        static void UnderstandingTypes()
        {
            string[] types = { "sbyte", "byte", "short", "ushort", "int", "uint", "long", "ulong", "float", "double", "decimal" };

            Tuple<object, object>[] typeRanges = {
                Tuple.Create((object)sbyte.MinValue, (object)sbyte.MaxValue),
                Tuple.Create((object)byte.MinValue, (object)byte.MaxValue),
                Tuple.Create((object)short.MinValue, (object)short.MaxValue),
                Tuple.Create((object)ushort.MinValue, (object)ushort.MaxValue),
                Tuple.Create((object)int.MinValue, (object)int.MaxValue),
                Tuple.Create((object)uint.MinValue, (object)uint.MaxValue),
                Tuple.Create((object)long.MinValue, (object)long.MaxValue),
                Tuple.Create((object)ulong.MinValue, (object)ulong.MaxValue),
                Tuple.Create((object)float.MinValue, (object)float.MaxValue),
                Tuple.Create((object)double.MinValue, (object)double.MaxValue),
                Tuple.Create((object)decimal.MinValue, (object)decimal.MaxValue)
            };

            Console.WriteLine("{0,-20} {1,20} {2,20}\n", "Type", "Min Range", "Max Range");

            for (int counter = 0; counter < types.Length; counter++)
            {
                var typeRange = typeRanges[counter];
                Console.WriteLine("{0,-20} {1,20:N1} {2,20:N1}", types[counter], typeRange.Item1, typeRange.Item2);
            }
        }
        static void centuriesConverter(int centuries)
        {
            long years = centuries * 100;
            long days = years * 36524; // Account for leap years
            long hours = days * 24;
            long minutes = hours * 60;
            long seconds = minutes * 60;
            long milliseconds = seconds * 1000;
            long microseconds = milliseconds * 1000;
            long nanoseconds = microseconds * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days");
            Console.WriteLine($"= {hours} hours = {minutes} minutes = {seconds} seconds");
            Console.WriteLine($"= {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");

        }
        static void fizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

        }

        static void GuessNumberGame()
        {
            int correctNumber = new Random().Next(3) + 1;
            Console.WriteLine("Guess the number between 1 and 3:");

            int guessedNumber = int.Parse(Console.ReadLine());
            if (guessedNumber < 1 || guessedNumber > 3)
            {
                Console.WriteLine("Your guess is outside the valid range.");
            }
            else
            {
                if (guessedNumber < correctNumber)
                {
                    Console.WriteLine("Your guess is too low.");
                }
                else if (guessedNumber > correctNumber)
                {
                    Console.WriteLine("Your guess is too high.");
                }
                else
                {
                    Console.WriteLine("Congratulations! You guessed the correct number.");
                }
            }
        }

        static void print_a_pryamid()
        {
            for(int i=0; i<5; i++)
            {
                for(int j=4; j>i; j--)
                {
                    Console.Write(" ");
                }
                
                for(int k = 0; k<1 + 2*i; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        static void cal_days()
        {
            DateTime birthDate = DateTime.Parse("1990-01-01");
            int ageInDays = (DateTime.Today - birthDate).Days;
            Console.WriteLine($"Person's age in days: {ageInDays}");
            int daysToNextAnniversary = 10000 - (ageInDays % 10000);
            DateTime nextAnniversaryDate = DateTime.Today.AddDays(daysToNextAnniversary);

            Console.WriteLine($"Next 10,000-day anniversary: {nextAnniversaryDate:yyyy-MM-dd}");
        }

        static void GreetUser(DateTime currentTime)
        {
            int currentHour = currentTime.Hour;

            if (currentHour >= 5 && currentHour < 12)
            {
                Console.WriteLine("Good Morning");
            }
            if (currentHour >= 12 && currentHour < 17)
            {
                Console.WriteLine("Good Afternoon");
            }
            if (currentHour >= 17 && currentHour < 20)
            {
                Console.WriteLine("Good Evening");
            }
            if (currentHour >= 20 || currentHour < 5)
            {
                Console.WriteLine("Good Night");
            }
        }

        static void count24()
        {
            for (int i = 1; i <= 4; i++)
            {
                Console.Write($"Counting by {i}s: ");
                for (int j = 0; j <= 24; j += i)
                {
                    Console.Write($"{j},");
                }
                Console.WriteLine();
            }
        }
    }
}

// 1. What happens when you divide an int variable by 0?
    // System.DivideByZeroException

// 2. What happens when you divide a double variable by 0?
    // positive or negative infinity

// 3. What happens when you overflow an int variable, that is, set it to a value beyond its range?
    // System.OverflowException

// 4. What is the difference between x = y++; and x = ++y;?
    // x = y then y = y + 1   ||  y = y + 1 then x = y

// 5. What is the difference between break, continue, and return when used inside a loop statement?
    // break teminates the current loop scope, continue proceed to the next iteration, return halt the program(all loop) and give out result.

// 6. What are the three parts of a for statement and which of them are required?
    // for (int i = 0; i < 10; i++)
    // Initialization: int i = 0
    // Condition: i < 10
    // Iteration: i++

// 7. What is the difference between the = and == operators?
    // = stands for assignment and == stands for comparation

// 8. Does the following statement compile? for ( ; true; ) ;
    // yes, infinite loop that does nothing

// 9. What does the underscore _ represent in a switch expression?
    // the default option

// 10. What interface must an object implement to be enumerated over by using the foreach statement?
    // IEnumerable or IEnumerable<T>
    