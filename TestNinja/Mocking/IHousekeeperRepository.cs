using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestNinja.Mocking
{
    public interface IHousekeeperRepository
    {
        IQueryable<Housekeeper> GetAll();

    }
}
