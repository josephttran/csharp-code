using System;
using System.Collections.Generic;

namespace GenericsConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = new List<int> { 2, 4, 6, 8, 10 };
            List<string> wordList = new List<string> { "Fruit", "Vegetable", "Meat" };

            List<object> mixList = InterMixLists<string, int>(wordList, numberList);

            DisplayList(mixList);
        }

        static void DisplayList(List<object> list)
        {
            foreach (object item in list)
            {
                Console.WriteLine(item);
            }
        }

        static List<object> InterMixLists<T, K>(in List<T> firstList, in List<K> secondList)
        {
            List<object> mixList = new List<object>();

            if (firstList.Count >= secondList.Count)
            {
                List<K>.Enumerator secondListEnumerator = secondList.GetEnumerator();

                foreach (T item in firstList)
                {
                    mixList.Add(item);

                    if (secondListEnumerator.MoveNext())
                    {
                        mixList.Add(secondListEnumerator.Current);
                    }
                }
            }
            else
            {
                List<T>.Enumerator firstListEnumerator = firstList.GetEnumerator();

                foreach (K item in secondList)
                {
                    mixList.Add(item);

                    if (firstListEnumerator.MoveNext())
                    {
                        mixList.Add(firstListEnumerator.Current);
                    }
                }
            }

            return mixList;
        }
    }
}
