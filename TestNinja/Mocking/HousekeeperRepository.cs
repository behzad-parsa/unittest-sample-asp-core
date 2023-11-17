using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestNinja.Mocking
{
    public class HousekeeperRepository : IHousekeeperRepository
    {
        private readonly UnitOfWork UnitOfWork;

        public HousekeeperRepository()
        {
            UnitOfWork = new UnitOfWork();
        }
        public IQueryable<Housekeeper> GetAll()
        {
            var result = UnitOfWork.Query<Housekeeper>();
            return result;
        }
    }
}
