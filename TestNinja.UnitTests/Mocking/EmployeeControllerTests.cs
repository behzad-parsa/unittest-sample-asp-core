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
    public class EmployeeControllerTests
    {

        private Mock<IEmployeeRepository> _employeeRepository;
        private EmployeeController _controller;

        [SetUp]
        public void SetUp()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _controller = new EmployeeController(_employeeRepository.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmloyeeFromDatabase()
        {
            _controller.DeleteEmployee(1);
            _employeeRepository.Verify(s => s.DeleteEmployee(1));
        }


    }
}
