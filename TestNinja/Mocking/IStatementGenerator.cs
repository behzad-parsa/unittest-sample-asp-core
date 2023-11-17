using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Mocking
{
    public interface IStatementGenerator
    {
        string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate);
    }
}
