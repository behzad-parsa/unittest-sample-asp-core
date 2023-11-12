using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestNinja.Mocking
{
    public interface IBookRepository
    {
        IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null);
    }
}
