using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(15,"FizzBuzz")]
        [TestCase(6,"Fizz")]
        [TestCase(10,"Buzz")]
        [TestCase(19,"19")]
        public void GetOutput_WhenCalled_ReturnExpectedString(int number , string expectedResult)
        {
            var result = FizzBuzz.GetOutput(number);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
