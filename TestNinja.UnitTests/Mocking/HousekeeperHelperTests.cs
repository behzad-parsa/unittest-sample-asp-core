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
    public class HousekeeperHelperTests
    {
        private Mock<IHousekeeperRepository> _mockHousekeeperRepository;
        private Mock<IStatementGenerator> _mockStatementGenerator;
        private Mock<ISendService> _mockSendService;
        private Mock<IXtraMessageBox> _mockMessageBox;
        private HousekeeperHelper _housekeeperHelper;
        private readonly DateTime _statementDate = new DateTime(2017, 1, 1);
        private Housekeeper _housekeeper;
        private readonly string _statementFileName = "filename";

        [SetUp]
        public void SetUp()
        {
            _housekeeper = new Housekeeper()
            {
                Email = "a",
                FullName = "b",
                Oid = 1,
                StatementEmailBody = "c"
            };
            _mockHousekeeperRepository = new Mock<IHousekeeperRepository>();
            _mockHousekeeperRepository.Setup(r => r.GetAll()).Returns(new List<Housekeeper>
            {
              _housekeeper

            }.AsQueryable());

            _mockMessageBox = new Mock<IXtraMessageBox>();
            _mockSendService = new Mock<ISendService>();
            _mockStatementGenerator = new Mock<IStatementGenerator>();
            _housekeeperHelper = new HousekeeperHelper(_mockHousekeeperRepository.Object,
                _mockStatementGenerator.Object,
                _mockSendService.Object,
                _mockMessageBox.Object);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            _housekeeperHelper.SendStatementEmails(_statementDate);

            _mockStatementGenerator.Verify(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate));

        }
        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void SendStatementEmails_HouseKeepersEmailIsNullOrEmptyOrWhiteSpace_ShouldNotGenerateStatements(string email)
        {
            _housekeeper.Email = email;
            _housekeeperHelper.SendStatementEmails(_statementDate);

            _mockStatementGenerator.Verify(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate), Times.Never);

        }
        //[Test]
        //public void SendStatementEmails_HouseKeepersEmailIsNull_ShouldNotGenerateStatements()
        //{
        //    _housekeeper.Email = null;
        //    _housekeeperHelper.SendStatementEmails(_statementDate);

        //    _mockStatementGenerator.Verify(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate),Times.Never);

        //}        
        //[Test]
        //public void SendStatementEmails_HouseKeepersEmailIsWhitspace_ShouldNotGenerateStatements()
        //{
        //    _housekeeper.Email = " ";
        //    _housekeeperHelper.SendStatementEmails(_statementDate);

        //    _mockStatementGenerator.Verify(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate),Times.Never);

        //}        
        //[Test]
        //public void SendStatementEmails_HouseKeepersEmailIsEmpty_ShouldNotGenerateStatements()
        //{
        //    _housekeeper.Email = "";
        //    _housekeeperHelper.SendStatementEmails(_statementDate);

        //    _mockStatementGenerator.Verify(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate),Times.Never);

        //}

        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {

            _mockStatementGenerator.Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate)).Returns(_statementFileName);

            _housekeeperHelper.SendStatementEmails(_statementDate);

            _mockSendService.Verify(es => es.EmailFile(_housekeeper.Email, _housekeeper.StatementEmailBody, _statementFileName, It.IsAny<string>()));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_StatmentFileNameIsNullOrWhitespaceOrEmpty_EmailTheStatement(string statementFileName)
        {

            _mockStatementGenerator.Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate)).Returns(() => statementFileName);

            _housekeeperHelper.SendStatementEmails(_statementDate);

            _mockSendService.Verify(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Never);
        }

    }
}
