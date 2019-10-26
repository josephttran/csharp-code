using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace CalculationsLibrary.Tests
{
    [TestFixture]
    class TextDataAccessTests
    {
        [Test]
        public void SaveText_ShouldThrowException()
        {
            WriteText writeText = new WriteText();
            TextDataAccess textDataAccess = new TextDataAccess(writeText);
            List<string> lines = new List<string> 
            { 
                "First line", 
                "Second line", 
                "Third line" 
            };

            string filePath =
                $"This path is too long with 261     characters" +
                $"qwertyuiopasdfghjklzxcvbnm1234567890" +
                $"qwertyuiopasdfghjklzxcvbnm1234567890" +
                $"qwertyuiopasdfghjklzxcvbnm1234567890" +
                $"qwertyuiopasdfghjklzxcvbnm1234567890" +
                $"qwertyuiopasdfghjklzxcvbnm1234567890" +
                $"qwertyuiopasdfghjklzxcvbnm1234567890";

            TestDelegate testDelegate = () => textDataAccess.SaveText(filePath, lines);

            Assert.Throws<PathTooLongException>(testDelegate);
        }
        
        [Test]
        public void SaveText_WhenCalled_ShouldExecuteWriteAllText()
        {
            FakeWriteText mockWrite = new FakeWriteText();
            TextDataAccess textDataAccess = new TextDataAccess(mockWrite);
            List<string> lines = new List<string> 
            { 
                "First line", 
                "Second line", 
                "Third line" 
            };

            string filePath = $"write.txt";

            textDataAccess.SaveText(filePath, lines);

            Assert.True(mockWrite.Done);
        }
    }
}
