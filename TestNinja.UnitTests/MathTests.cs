using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_RetrunTheSumOfArguments()
        {
            //Arrange
            var result = _math.Add(1, 2);
            //assert
            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            var result = _math.Max(10, 2);
            Assert.That(result, Is.EqualTo(10));
        }
        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            var result = _math.Max(2, 10);
            Assert.That(result, Is.EqualTo(10));
        }
        [Test]
        public void Max_ArgumentsAreEqual_ReturnSameArgument()
        {
            var result = _math.Max(2, 2);
            Assert.That(result, Is.EqualTo(2));
        }

        //Parameterized Test of Max
        [Test]
        [TestCase(1,10,10)]
        [TestCase(10,1,10)]
        [TestCase(2,2,2)]
        public void Max_WhenCalled_RetrunTheGreaterArgument(int a,int b,int exepectedResult)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(exepectedResult));
        }

        //Ignore The test
        [Test]
        [TestCase(1, 10, 10)]
        [Ignore("Just to have sample")]
        public void Max_WhenCalled_RetrunTheGreaterArgument_Ignored(int a, int b, int exepectedResult)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(exepectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);


            //General
            //Assert.That(result, Is.Not.Empty);
            //Assert.That(result.Count(), Is.EqualTo(3));

            //Specific
            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));
            //Or
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

           // Assert.That(result,Is.Ordered)
            //Assert.That(result,Is.Unique )

        }


    }
}
