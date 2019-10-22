using System;
using System.Collections.Generic;
using System.Reflection;

namespace GenericsConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = new List<int> { 2, 4, 6, 8, 10 };
            List<string> wordList = new List<string> { "Fruit", "Vegetable", "Meat" };
            List<object> mixList = InterMixLists<string, int>(wordList, numberList);

            Person person = new Person
            {
                FirstName = "Bob",
                LastName = "Light",
                Title = "Lead Singer"
            };

            Song song = new Song
            {
                Album = "Not New",
                Title = "Around the World"
            };

            object longerTitleObject = GetObjectWithLongerTitle<TitleBase>(person, song);

            DisplayList(mixList);
            DisplayTitle(longerTitleObject);
        }

        static void DisplayList(List<object> list)
        {
            foreach (object item in list)
            {
                Console.WriteLine(item);
            }
        }

        static void DisplayTitle(object titleObject)
        {
            if (titleObject != null)
            {
                string titleValue = titleObject.GetType().GetProperty("Title").GetValue(titleObject).ToString();
                Console.WriteLine("\nTitle: " + titleValue);
            }
        }

        static object GetObjectWithLongerTitle<TitleBase>(in TitleBase objectOne, in TitleBase objectTwo)
        {
            object titleObject = null;
            PropertyInfo objectOneInfo = objectOne.GetType().GetProperty("Title");
            PropertyInfo objectTwoInfo = objectTwo.GetType().GetProperty("Title");
            object objectOneTitleValue = objectOneInfo.GetValue(objectOne);
            object objectTwoTitleValue = objectTwoInfo.GetValue(objectTwo);

            if (objectOneTitleValue == null && objectTwoTitleValue == null)
            {
                Console.WriteLine("Titles value are empty");
            }
            else if (objectOneTitleValue != null && objectTwoTitleValue == null)
            {
                return objectOne;
            }
            else if (objectOneTitleValue == null && objectTwoTitleValue != null)
            {
                return objectTwo;
            }
            else
            {
                if (objectOneTitleValue.ToString().Length > objectTwoTitleValue.ToString().Length)
                {
                    return objectOne;
                }

                if (objectOneTitleValue.ToString().Length < objectTwoTitleValue.ToString().Length)
                {
                    return objectTwo;
                }
            }

            return titleObject;
        }

        static List<object> InterMixLists<T1, T2>(in List<T1> firstList, in List<T2> secondList)
        {
            List<object> mixList = new List<object>();

            if (firstList.Count >= secondList.Count)
            {
                List<T2>.Enumerator secondListEnumerator = secondList.GetEnumerator();

                foreach (T1 item in firstList)
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
                List<T1>.Enumerator firstListEnumerator = firstList.GetEnumerator();

                foreach (T2 item in secondList)
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
