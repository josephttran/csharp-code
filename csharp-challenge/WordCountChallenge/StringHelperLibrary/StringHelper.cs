using System;

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
    }
}
