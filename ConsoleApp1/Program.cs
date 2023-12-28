using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            /*var x1 = removeDuplicateString("ararabe");
            var x2 = removeDuplicateString("frfrancefrfr");
            Console.WriteLine(x1);
            Console.WriteLine(x2);*/
            //var response = CheckAnagrams("comira", "aRImoc");
            // Console.WriteLine(response);
            /*var response = ReverseUsingIterationRecursion("abcdef");
            Console.WriteLine(response);*/
            /*  var response = CountingNumberOfWordsInString("Le visage et le corps sont les témoins de notre histoire, portant les marques des douleurs et des joies que nous avons vécues");
              Console.WriteLine(response);*/
            /*  var response = CheckPalindrome("Roma", "AMOR");
              Console.WriteLine(response);*/

            /*  var response = HighestOccuredCharInString("diactionnairea");
              Console.WriteLine(response);*/
           /* var response = IsStringUnique("abcdefghe");
            Console.WriteLine(response);*/
            /*Console.WriteLine(FirstNotRepeatingCharacter("aaabbffffforrrx"));
            Console.WriteLine(FirstNotRepeatingCharacter2("aaabbffffforrrx"));*/
            int[] ints = { -4, -2, -1,1 ,3, 8 };
            Console.WriteLine(ClosestNumberToZero(ints));
        }
        static string removeDuplicateString(string input)
        {
            string result = string.Empty;
            foreach (char c in input)
            {
                if (result.IndexOf(c) == -1)
                {
                    result += c;
                }
            }
            return result;
        }
        static bool CheckAnagrams(string value1,string value2)
        {
            var tab = value1.ToLower().ToCharArray();
            var tab2 = value2.ToLower().ToCharArray();
            Array.Sort(tab);
            Array.Sort(tab2);
            string sortedString1 = new string(tab);
            string sortedString2 = new string(tab2);
            return sortedString1.Equals(sortedString2);
        }
        static string ReverseUsingIterationRecursion(string val)
        {
            int i = 0;
            string result = string.Empty;
            while (i!= val.Length){
                result += val[val.Length - i-1];
                i++;
            }
            return result;
        }
        static int CountingNumberOfWordsInString(string val)
        {
            char[] delimiters = { ',', ';', '|' ,' ','\''};
            string[] tab= val.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return tab.Length;
        }
        static bool CheckPalindrome(string val1,string val2)
        {
            var tab=val2.ToLower().ToCharArray();
            Array.Reverse(tab);
            var reversedstring = new string(tab);
            return reversedstring.Equals(val1.ToLower());
        }
        static char HighestOccuredCharInString(string val)
        {
            Dictionary<char,int> count= new Dictionary<char, int>();
            foreach(char c in val)
            {
                if (count.ContainsKey(c))
                {
                    count[c]++;
                }
                else
                {
                    count[c] = 1;
                }
            }
            return count.OrderByDescending(kv => kv.Value).First().Key;
        }
        static bool IsStringUnique(string val)
        {
            HashSet<char> set = new HashSet<char>();
            foreach(char c in val)
            {
                set.Add(c);
            }
            return set.Count == val.Length;
        }
        static char FirstNotRepeatingCharacter(string val)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            char y = '_';
            foreach (char c in val)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
                else
                {
                    dic[c] = 1;
                }
            }
            foreach (char c in val)
            {
                if (dic[c] == 1)
                {
                    return c;
                }
            }
            return y;
        }

        static char FirstNotRepeatingCharacter2(string val)
        {
            char y = '_';
            foreach (char c in val)
            {
                if (val.IndexOf(c) == val.LastIndexOf(c))
                {
                    return c;
                }
            }
            return y;
        }
        static int ClosestNumberToZero(int[] nums)
        {
            if ( nums is null || nums.Length == 0 ) return 0;
            int ClosestNumber = nums[0];
            int ClosestDistance = Math.Abs(nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                int CurrentDistance = Math.Abs(nums[i]);
                if ((CurrentDistance < ClosestDistance)  || ( CurrentDistance==ClosestDistance && (nums[i] > 0)))
                {
                    ClosestDistance = CurrentDistance;
                    ClosestNumber = nums[i];
                }
            }
            return ClosestNumber;
        }
        static IList<int> TopKFrequent(int[] nums, int k)
        {
            var answer = nums
                .GroupBy(n => n)            // Group elements by their values
                .OrderByDescending(g => g.Count()) // Order groups by frequency in descending order
                .Take(k)                    // Take the top k groups
                .Select(g => g.Key)         // Select the keys (distinct elements) from the groups
                .ToList();                  // Convert the result to a List<int>

            return answer;
        }
        static int[] TopKFrequent2(int[] nums, int k)
        {
            // counting how many times each number appears
            Dictionary<int, int> numberFrequency = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if (numberFrequency.TryGetValue(i, out var temp))
                {
                    // Key exists, update its value
                    numberFrequency[i] = temp + 1;
                }
                else
                {
                    // Key doesn't exist, add it to the dictionary with a count of 1
                    numberFrequency[i] = 1;
                }
            }
            // apply bucket sorting
            //create an array of list in the size of the original nums array
            List<int>[] bucket = new List<int>[nums.Length + 1];
            // populate the bucket with list of numbers where the index represents their frequency
            foreach (int key in numberFrequency.Keys)
            {
                int frequency = numberFrequency[key];
                if (bucket[frequency] == null)
                {
                    bucket[frequency] = new List<int>();
                }
                bucket[frequency].Add(key);
            }
            List<int> result = new List<int>();
            for (int i = bucket.Length - 1; i >= 0 && result.Count < k; i--)
            {
                if (bucket[i] != null)
                {
                    result.AddRange(bucket[i]);
                }
            }
            return result.ToArray();

        }
        static int CalculateSumBetweenIndices(int[] array, int startIndex, int endIndex)
        {
            // Use LINQ to calculate the sum of numbers between the specified indices
            int sum = array
                .Skip(startIndex)
                .Take(endIndex - startIndex + 1) // Add 1 to include the endIndex in the range
                .Sum();

            return sum;
        }
    }
}
