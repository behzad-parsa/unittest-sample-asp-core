using NUnit.Framework;
using System;
using TestNinja;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    //With NUnit
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });

            //Assert
            Assert.IsTrue(result);
            Assert.That(result,Is.True);
            Assert.That(result == true);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnsTrue()
        {
            var reservation = new Reservation();
            reservation.MadeBy = new User();
            var result = reservation.CanBeCancelledBy(reservation.MadeBy);
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnsFalse()
        {
            var reservation = new Reservation();
            var result = reservation.CanBeCancelledBy(new User());
            Assert.IsFalse(result);
        }

    }

    //With MsTest

    // [TestClass]
    //public class ReservationTests
    //{
    //    [TestMethod]
    //    public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
    //    {
    //        //Arrange
    //        var reservation = new Reservation();

    //        //Act
    //        var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });

    //        //Assert
    //        Assert.IsTrue(result);

    //    }

    //    [TestMethod]
    //    public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnsTrue()
    //    {
    //        var reservation = new Reservation();
    //        reservation.MadeBy = new User();
    //        var result = reservation.CanBeCancelledBy(reservation.MadeBy);
    //        Assert.IsTrue(result);
    //    }
    //    [TestMethod]
    //    public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnsFalse()
    //    {
    //        var reservation = new Reservation();
    //        var result = reservation.CanBeCancelledBy(new User());
    //        Assert.IsFalse(result);
    //    }

    //}

}
