using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowOutOfRangeException(int speed)
        {
            var demeritPoints = new DemeritPointsCalculator();
            Assert.That(() => demeritPoints.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }


        [Test]
        [TestCase(0,0)]
        [TestCase(64,0)]
        [TestCase(65,0)]
        [TestCase(66,0)]
        [TestCase(70,1)]
        [TestCase(75,2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoint(int speed,int expectedResult)
        {
            var demeritPoints = new DemeritPointsCalculator();
            var result = demeritPoints.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(expectedResult));
        }   

    }
}
