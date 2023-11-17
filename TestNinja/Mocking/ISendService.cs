using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Mocking
{
    public interface ISendService
    {
        void EmailFile(string emailAddress, string emailBody, string filename, string subject);
    }
}
