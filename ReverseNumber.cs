
namespace app3
{
    public class ReverseNumber
    {
        public static void run(string[] args)
        {
            int[] numbers = GenerateNumbers(10);
            Reverse(numbers);
            PrintCollection(numbers);
        }

        static int[] GenerateNumbers(int length)
        {
            int[] numbers = new int[length];
            for (int i = 0; i < length; i++)
            {
                numbers[i] = i + 1; 
            }
            return numbers;
        }

        static void Reverse(int[] array)
        {
            int start = 0;
            int end = array.Length - 1;

            while (start < end)
            {
                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;

                start++;
                end--;
            }
        }

        static void PrintCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
