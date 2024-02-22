// 1. When to use String vs. StringBuilder in C# ?
//     String is immutatble but StringBuilder is mutable, use StringBuilder when we need to edit the string.
// 2. What is the base class for all arrays in C#?
//     System.array
// 3. How do you sort an array in C#?
//     Array.sort()
// 4. What property of an array object can be used to get the total number of elements in an array?
//     Array.Length
// 5. Can you store multiple data types in System.Array?
//     YES
// 6. What’s the difference between the System.Array.CopyTo() and System.Array.Clone()?
//     Array.CopyTo() is used to copy the elements from one array to another existing array.
//     Array.Clone() is used to create a shallow copy of the array  (return a new array).

using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {   //  1
        // int[] originalArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // int[] copiedArray = CopyArray(originalArray);
        // PrintArray("Original Array:", originalArray);
        // PrintArray("Copied Array:", copiedArray);

        //  2
        // List<string> itemList = new List<string>();
        // ManageList(itemList);

        //  3
        // PrintArray(FindPrimesInRange(2, 20));

        //  4
        // Question4Rotation();

        //  5
        // int[] arr = {1,2,3,3,3,2,2,4,4,4,4,5};
        // PrintArray(FindLongestSequence(arr));

        // 6
        // int[] arr = {1,2,3,3,3,2,2,4,4,4,4,5};
        // FindMostFrequentNumber(arr);

        //  7
        // string s = "HaoLan16";
        // Console.WriteLine(ReverseStringUsingCharArray(s));
        // ReverseStringUsingForLoop(s);       

        //  8
        // string inputSentence1 = "C# is not C++, and PHP is not Delphi!";
        // string inputSentence2 = "The quick brown fox jumps over the lazy dog /Yes! Really!!!/.";
        // Console.WriteLine(ReverseWordsInSentence(inputSentence1));
        // Console.WriteLine(ReverseWordsInSentence(inputSentence2));

        //  9
        // string input1 = "Hi,exe? ABBA! Hog fully a string: ExE. Bob";
        // PrintCollection(ExtractPalindromes(input1));

        //  10
        // string url1 = "https://www.apple.com/iphone";
        // string url2 = "ftp://www.example.com/employee";
        // string url3 = "https://google.com";
        // string url4 = "www.apple.com";
        
        // ParseUrl(url1);
        // ParseUrl(url2);
        // ParseUrl(url3);
        // ParseUrl(url4);
        


    }

    static int[] CopyArray(int[] originalArray)
    {
        int[] copiedArray = new int[originalArray.Length];

        for (int i = 0; i < originalArray.Length; i++)
        {
            copiedArray[i] = originalArray[i];
        }

        return copiedArray;
    }

    static void ManageList(List<string> itemList)
    {
        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
            string userInput = Console.ReadLine();
            ProcessUserInput(userInput, itemList);
            Console.WriteLine("Current List:");
            PrintCollection(itemList);
        }
    }

    static void ProcessUserInput(string userInput, List<string> itemList)
    {
        if (userInput.StartsWith("+"))
        {            
            string newItem = userInput.Substring(1).Trim();
            itemList.Add(newItem);
        }
        else if (userInput == "--")
        {
            itemList.Clear();
            Console.WriteLine("list clear");
        }
        else if (userInput.StartsWith("-"))
        {
            string itemToRemove = userInput.Substring(1).Trim();
            itemList.Remove(itemToRemove);
        }
        else
        {
            Console.WriteLine("Invalid command. Please use '+', '-', or '--'.");
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

    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();
        for(int i = startNum; i < endNum; i++)
        {
            if(IsPrime(i))
            {
                primes.Add(i);
            }
        }
        return primes.ToArray();
    }
    static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    static void Question4Rotation()
    {
        Console.WriteLine("Enter the array of integers separated by space:");
        int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        Console.WriteLine("Enter the number of rotations (k):");
        int k = int.Parse(Console.ReadLine());

        int[] sum = RotateAndSum(array, k);

        Console.WriteLine("Sum after each rotation:");
        PrintCollection(sum);
    }
    static int[] RotateAndSum(int[] array, int k)
    {
        int n = array.Length;
        int[] sum = new int[n];

        for (int r = 1; r <= k; r++)
        {
            int[] rotatedArray = new int[n];
            Array.Copy(array, n - r, rotatedArray, 0, r);
            Array.Copy(array, 0, rotatedArray, r, n - r);

            for (int i = 0; i < n; i++)
            {
                sum[i] += rotatedArray[i];
            }

            Console.Write($"rotated{r}[] = ");
            PrintCollection(rotatedArray);
        }

        return sum;
    }

    static int[] FindLongestSequence(int[] array)
    {
        int longestLength = 0;
        int currentLength = 1;
        int longestStartIndex = 0;
        int currentStartIndex = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i - 1])
            {
                currentLength++;
                if (currentLength > longestLength)
                {
                    longestLength = currentLength;
                    longestStartIndex = currentStartIndex;
                }
            }
            else
            {
                currentLength = 1;
                currentStartIndex = i;
            }
        }
        int[] longestSequence = array.Skip(longestStartIndex).Take(longestLength).ToArray();
        return longestSequence;
    }

    static int FindMostFrequentNumber(int[] sequence)
    {
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

        foreach (int number in sequence)
        {
            if (frequencyMap.ContainsKey(number))
            {
                frequencyMap[number]++;
            }
            else
            {
                frequencyMap[number] = 1;
            }
        }
        int mostFrequentNumber = 0;
        int maxOccurrence = 0;

        foreach (var entry in frequencyMap)
        {
            if (entry.Value > maxOccurrence)
            {
                mostFrequentNumber = entry.Key;
                maxOccurrence = entry.Value;
            }
        }
        Console.WriteLine($"The number {mostFrequentNumber} is the most frequent (occurs {maxOccurrence} times)");
        return mostFrequentNumber;
    }

    static string ReverseStringUsingCharArray(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static string ReverseStringUsingForLoop(string input)
    {
        char[] charArray = input.ToCharArray();
        for (int i = charArray.Length - 1; i >= 0; i--)
        {
            Console.Write(charArray[i]);
        }
        Console.WriteLine();
        return input;
    }

    static string ReverseWordsInSentence(string sentence)
    {
        string pattern = @"([.,:;=()&\[\]""'\s\\/!?]+)";
        string[] parts = Regex.Split(sentence, pattern);
        List<string> words = new List<string>();

        for (int i = 0; i < parts.Length; i++)
        {
            if (!string.IsNullOrEmpty(parts[i]) && char.IsLetter(parts[i][0]))
            {
                words.Add(parts[i]);
            }
        }

        int wordIndex = words.Count - 1;
        for (int i = 0; i < parts.Length; i++)
        {
            if (!string.IsNullOrEmpty(parts[i]) && char.IsLetter(parts[i][0]))
            {
                parts[i] = words[wordIndex--];
            }
        }

        string reversedSentence = string.Concat(parts);
        return reversedSentence;
    }
    static List<string> ExtractPalindromes(string text)
    {
        string pattern = @"\b(?<word>[^\W_]+)\b";
        var matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        HashSet<string> uniquePalindromes = new HashSet<string>();

        foreach (Match match in matches)
        {
            string word = match.Groups["word"].Value;
            if (IsPalindrome(word))
            {
                uniquePalindromes.Add(word);
            }
        }

        List<string> sortedPalindromes = uniquePalindromes.OrderBy(p => p).ToList();
        return sortedPalindromes;
    }

    static bool IsPalindrome(string word)
    {
        return word == new string(word.Reverse().ToArray());
    }

    static void ParseUrl(string url)
    {
        UriBuilder uriBuilder = new UriBuilder(url);

        string protocol = uriBuilder.Scheme != Uri.UriSchemeHttp ? uriBuilder.Scheme : "";
        string server = uriBuilder.Host;
        string resource = uriBuilder.Path.TrimStart('/');

        Console.WriteLine($"[{nameof(protocol)}] = \"{protocol}\"");
        Console.WriteLine($"[{nameof(server)}] = \"{server}\"");
        Console.WriteLine($"[{nameof(resource)}] = \"{resource}\"");
        Console.WriteLine();
    }
}
