using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace TriangleTests
{
    public class Tests
    {
        private readonly StreamReader _cases = new StreamReader("Cases.txt");
        private readonly StreamWriter _result = new StreamWriter("Result.txt");

        [TearDown]
        public void Finish()
        {
            _result.Flush();
            _result.Close();
            
            File.Copy("Result.txt", "../../../Result.txt", true);
        }
        
        [Test]
        public void Run()
        {
            using (_cases)
            {
                string line;
                for (var i = 0; (line = _cases.ReadLine()) != null; i++)
                {
                    var programOutput = new StringWriter();
                    Console.SetOut(programOutput);
                    
                    var args = line.Split().Where(s => !string.IsNullOrEmpty(s)).ToArray();
                    Triangle.Program.Main(args);
                    
                    var expected = _cases.ReadLine();
                    var actual = programOutput.ToString();

                    _result.WriteLine($"{i + 1}: {(actual == expected ? "success" : "failure")}");
                    
                    Assert.AreEqual(expected, actual, $"Args were: {string.Join(',', args)}");
                }
            }
        }
    }
}