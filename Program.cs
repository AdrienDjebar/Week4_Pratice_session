using System;
using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//4th Oct 2022 : Coding pratice 
namespace OOP_Course5
{
    class Program
    {
        static void Main(string[] args)
        {
            //char[] test = sortedStringDescendingOrder();
            //for (int i = 0; i < test.Length; i++) Console.WriteLine(test[i]);
            Console.WriteLine(CompressString("p555ppp7www"));
            ArmstrongNumber();
            CountNumberInArray(new int[] { 5, 7, 5, 2, 2, 4, 5 });
            Console.WriteLine($"{Factorial(4)}");
            Console.WriteLine(countWhiteSpace("My Name Is Pramit"));
        }

        #region Q1
        public static string ExchangeLetters()
        {
            Console.WriteLine("Enter the string you want to exchange letters: ");
            string s = Console.ReadLine();
            string new_string;
            if (s.Length == 1) new_string = s;
            else
            {
                char first_letter = s[0];
                char last_letter = s[s.Length - 1];

                new_string = s.Substring(0, s.Length - 1);
                new_string = new_string.Substring(1);
                new_string = last_letter + new_string + first_letter;

            }
            return new_string;
        }
        #endregion

        #region Q2
        public static bool VerifySequenceNumber()
        {
            Console.WriteLine("Enter the number sequences which will be checked if it appears in a given array of integers with the syntax 'number1, number2, number3,..., numberN': ");
            string[] toCheckSequenceString = (Console.ReadLine().Split(','));
            int[] toCheckSequenceInt = new int[toCheckSequenceString.Length];
            for(int i = 0; i < toCheckSequenceInt.Length; i++)
            {
                toCheckSequenceInt[i] = Convert.ToInt32(toCheckSequenceString[i]);
            }

            Console.WriteLine("Enter the array of integers with the syntax 'number1, number2, number3,..., numberN' : ");
            string[] intArrayString = Console.ReadLine().Split(',');
            int[] intArrayInt = new int[intArrayString.Length];
            for(int i = 0; i < intArrayInt.Length; i++)
            {
                intArrayInt[i] = Convert.ToInt32(intArrayString[i]);
            }
            bool tag = false;
            bool tagSecond = false;

            if (toCheckSequenceInt.Length < intArrayInt.Length)
            {

                for (int i = 0; i < intArrayInt.Length && !tag; i++)
                {
                    if (intArrayInt[i] == toCheckSequenceInt[0])
                    {
                        for (int j = 1; j < toCheckSequenceInt.Length; j++)
                        {
                            if (intArrayInt[i + j] == toCheckSequenceInt[j]) tagSecond = true;
                            else tagSecond = false;
                        }
                    }
                    if (tagSecond) tag = true;
                }

            }
            return tag;
        }
        #endregion

        #region Q3
        public static int returnASCII(char letter)
        {
            return Convert.ToInt32(letter);
        }
        public static void swapCharArray(ref char[] charArray, int start, int end)
        {
            char temp = charArray[start];
            charArray[start] = charArray[end];
            charArray[end] = temp;
        }
        public static char[] sortedStringDescendingOrder()
        {
            Console.WriteLine("Enter a string: ");
            char[] combinationUnsorted = Console.ReadLine().ToCharArray();
            bool swapped = false;
            do
            {
                swapped = false;
                for (int i = 0; i < combinationUnsorted.Length - 1; i++)
                {
                    if (returnASCII(combinationUnsorted[i]) < returnASCII(combinationUnsorted[i + 1]))
                    {
                        swapCharArray(ref combinationUnsorted, i, i + 1);
                        swapped = true;
                    }
                }
            } while (swapped);
            
            return combinationUnsorted;
        }
        #endregion

        #region Q4
        public static string CompressString(string input)
        {
            string output = "";
            int count = 0;
            for(int i = 0; i < input.Length; i += count)
            {
                count = 0;
                bool tag = true;
                for(int j = i; tag && j < input.Length; j++)
                {
                    if (input[i] == input[j]) count++;
                    else tag = false;
                }
                output += $"{input[i]}{count}";
            }
            return output;
        }
        #endregion

        #region Q5
        public static void ArmstrongNumber()
        {
            int count = 1;
            for(int i = 0; i <= 999; i++)
            {
                int hundreds = (i % 1000 - i % 100) / 100;
                int tens = (i % 100 - i % 10) / 10;
                int unit = i % 10;
                if (hundreds * hundreds * hundreds + tens * tens * tens + unit * unit * unit == i)
                {
                    Console.WriteLine($"Armstrong number n°{count}: {i}");
                    count++;
                }
            }
        }
        #endregion

        #region Q6
        public static void CountNumberInArray(int[] array)
        {
            List<int> listOccurences = new List<int>();
            SortedList<int, int> list = new SortedList<int, int>();
            for(int i = 0; i < array.Length; i++)
            {
                int count = 0;
                if (!listOccurences.Contains(array[i]))
                {
                    listOccurences.Add(array[i]);
                    for(int j = i; j < array.Length; j++)
                    {
                        if (array[i] == array[j]) count++;
                    }
                    list.Add(array[i], count);
                }
                
            }
            IList myKeyList = list.Keys.ToList();
            IList myValueList = list.Values.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{myKeyList[i]} is {myValueList[i]} times");
            }
        }
        #endregion

        #region Q7
        public static int Factorial(int num)
        {
            int factorial = 1;
            for(int i = 0; i <= num; i++, num--)
            {
                factorial *= num;
            }
            return factorial;
        }
        #endregion

        #region Q8
        public static int countWhiteSpace(string s)
        {
            int count = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if(char.IsWhiteSpace(s[i])) count++;
            }
            return count;
        }
        #endregion

    }

}