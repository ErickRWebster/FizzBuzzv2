using FizzBuzz;
using FizzBuzzer;
using System;

namespace TestingUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFizzBuzz()
        {
            var buzzer = new Fizziest();

            var pairs = new Dictionary<int, string>();
            pairs.Add(3, "fizz");
            pairs.Add(5, "buzz");

            var newreq = new FizzBuzzer.FizzerRequest()
            {
                StartNumber = 1,
                EndNumber = 20,
                DividorOutputPairs = pairs
            };

            var response = buzzer.FizzBuzzer(newreq);
            if(response.Error == true)
            {
                throw new Exception(response.ErrorMessage);
            }

            var linethree = response.Results[2].Substring(response.Results[2].Length - 4);
            var linefive = response.Results[4].Substring(response.Results[4].Length - 4);
            var linefifteen = response.Results[14].Substring(response.Results[14].Length - 8);
            Assert.AreEqual("fizz", linethree);
            Assert.AreEqual("buzz", linefive);
            Assert.AreEqual("fizzbuzz", linefifteen);

        }
    }
}