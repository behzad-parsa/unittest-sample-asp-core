using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Mocking
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _db;

        public EmployeeRepository()
        {
            _db = new EmployeeContext();
            
        }
        public Employee GetEmployeeWithId(int id)
        {
            return _db.Employees.Find(id);
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeWithId(id);
            if (employee == null)
                return;
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }

    }
}
