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
            var response = IsStringUnique("abcdefgh");
            Console.WriteLine(response);
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
    }
}
