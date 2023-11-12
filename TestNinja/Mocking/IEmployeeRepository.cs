using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Mocking
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeWithId(int id);
        void DeleteEmployee(int id);
    }
}
