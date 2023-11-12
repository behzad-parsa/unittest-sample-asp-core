using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private Mock<IBookRepository> repository;
        private Booking existingBooking;
        [SetUp]
        public void SetUp()
        {
            repository = new Mock<IBookRepository>();
            existingBooking = new Booking()
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),
                Reference = "a",
            };

            repository.Setup(g => g.GetActiveBookings(1)).Returns(new List<Booking>()
            {
                existingBooking
            }.AsQueryable());
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            var bookingHelperResult = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(existingBooking.ArrivalDate,2),
                DepartureDate = Before(existingBooking.ArrivalDate),
                Reference = "b"
            }, repository.Object) ;

            Assert.That(bookingHelperResult, Is.EqualTo(string.Empty));
        }

        //overlap test
        [Test]
        public void OverlappingBookingsExist_BookingStartAfterAnExistingBookingAndFinishBeforeExistingBooking_ReturnExisitingBookingReference()
        {
            var bookingHelperResult = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(existingBooking.ArrivalDate),
                DepartureDate = Before(existingBooking.DepartureDate),
                Reference = "c"
            }, repository.Object) ;

            Assert.That(bookingHelperResult, Is.EqualTo(existingBooking.Reference));
        }

       private DateTime Before(DateTime dateTime, int days = 1) => dateTime.AddDays(-days);
        private DateTime After(DateTime dateTime) => dateTime.AddDays(1); private DateTime After(DateTime dateTime,int days = 1) => dateTime.AddDays(days); 
        private DateTime ArriveOn(int year, int month, int day) =>
            new DateTime(year, month, day, 14, 0, 0);
        private DateTime DepartOn(int year, int month, int day) =>
            new DateTime(year, month, day, 14, 0, 0);

    }
}
