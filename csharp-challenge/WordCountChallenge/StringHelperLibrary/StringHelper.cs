﻿using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace StringHelperLibrary
{
    public class StringHelper
    {
        public static int CharacterCount(string myString)
        {
            int count = 0;
            int index = 0;

            while (index < myString.Length)
            {
                if (!myString[index].Equals('\r'))
                {
                    count++;
                }
                index++;
            }

            return count;
        }

        public static int CharacterMinusSpaceLineReturnCount(string myString)
        {
            int count = 0;
            int index = 0;

            while (index < myString.Length)
            {
                if (!(Char.IsWhiteSpace(myString[index])))
                {
                    count++;
                }

                index++;
            }

            return count;
        }

        public static string[] GetWords(string myString)
        {
            MatchCollection matches = Regex.Matches(myString, @"(\w+)");
            string[] myStrings = new string[matches.Count];

            IEnumerator matchesEnumerator = matches.GetEnumerator();

            int index = 0;

            while (matchesEnumerator.MoveNext())
            {
                myStrings.SetValue(matchesEnumerator.Current.ToString(), index);
                index++;
            }

            return myStrings;
        }

        public static int WordCount(string myString)
        {
            MatchCollection matchCollection = Regex.Matches(myString, @"(\w+)");

            return matchCollection.Count;
        }
    }
}
