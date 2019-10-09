using NUnit.Framework;
using StringHelperLibrary;
using System.Collections.Generic;

namespace StringHelperTests
{
    public class Tests
    {
        public static readonly string[] tests = new string[]
        {
            @"The test of the 
            best way to handle

multiple lines,   extra spaces and more.",
            @"Using the starter app, create code that will 
loop through the strings and identify the total 
character count, the number of characters
excluding whitespace (including line returns), and the
number of words in the string. Finally, list each word, ensuring it
is a valid word."
        };

        static IEnumerable<TestCaseData> CharacterCountTestData
        {
            get
            {
                yield return new TestCaseData(tests[0]).Returns(89);
                yield return new TestCaseData(tests[1]).Returns(276);
            }
        }

        static IEnumerable<TestCaseData> CharacterMinusSpaceLineReturnCountTestData
        {
            get
            {
                yield return new TestCaseData(tests[0]).Returns(60);
                yield return new TestCaseData(tests[1]).Returns(230);
            }
        }

        [TestCaseSource(typeof(Tests), "CharacterCountTestData")]
        public int TestCharacterCount(string myString)
        {
            return StringHelper.CharacterCount(myString);
        }

        [TestCaseSource(typeof(Tests), "CharacterMinusSpaceLineReturnCountTestData")]
        public static int TestCharacterMinusSpaceLineReturnCount(string myString)
        {
            return StringHelper.CharacterMinusSpaceLineReturnCount(myString);
        }
    }
}