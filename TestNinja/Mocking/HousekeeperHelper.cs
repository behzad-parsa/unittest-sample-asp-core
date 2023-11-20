using System;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;

namespace TestNinja.Mocking
{
    public class HousekeeperHelper
    {
        private readonly IHousekeeperRepository housekeeperRepository;
        private readonly IStatementGenerator statementGenerator;
        private readonly ISendService sendService;
        private readonly IXtraMessageBox xtraMessageBox;
        public HousekeeperHelper(IHousekeeperRepository housekeeperRepository,
            IStatementGenerator statementGenerator,
            ISendService sendService,
            IXtraMessageBox xtraMessageBox)
        {
            this.housekeeperRepository = housekeeperRepository;
            this.statementGenerator = statementGenerator;
            this.sendService = sendService;
            this.xtraMessageBox = xtraMessageBox;
        }
        public void SendStatementEmails(DateTime statementDate)
        {
            var housekeepers = housekeeperRepository.GetAll();

            foreach (var housekeeper in housekeepers)
            {
                if (string.IsNullOrWhiteSpace(housekeeper.Email))
                    continue;

                var statementFilename = statementGenerator.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate);

                if (string.IsNullOrWhiteSpace(statementFilename))
                    continue;

                var emailAddress = housekeeper.Email;
                var emailBody = housekeeper.StatementEmailBody;

                try
                {
                    sendService.EmailFile(emailAddress, emailBody, statementFilename,
                        string.Format("Sandpiper Statement {0:yyyy-MM} {1}", statementDate, housekeeper.FullName));
                }
                catch (Exception e)
                {
                    xtraMessageBox.Show(e.Message, string.Format("Email failure: {0}", emailAddress),
                        MessageBoxButtons.OK);
                }
             }
        }
    }

    public enum MessageBoxButtons
    {
        OK
    }

    public class XtraMessageBox : IXtraMessageBox
    {
        public void Show(string s, string housekeeperStatements, MessageBoxButtons ok)
        {
        }
    }

    public class MainForm
    {
        public bool HousekeeperStatementsSending { get; set; }
    }

    public class DateForm
    {
        public DateForm(string statementDate, object endOfLastMonth)
        {
        }

        public DateTime Date { get; set; }

        public DialogResult ShowDialog()
        {
            return DialogResult.Abort;
        }
    }

    public enum DialogResult
    {
        Abort,
        OK
    }

    public class SystemSettingsHelper
    {
        public static string EmailSmtpHost { get; set; }
        public static int EmailPort { get; set; }
        public static string EmailUsername { get; set; }
        public static string EmailPassword { get; set; }
        public static string EmailFromEmail { get; set; }
        public static string EmailFromName { get; set; }
    }

    public class Housekeeper
    {
        public string Email { get; set; }
        public int Oid { get; set; }
        public string FullName { get; set; }
        public string StatementEmailBody { get; set; }
    }

    public class HousekeeperStatementReport
    {
        public HousekeeperStatementReport(int housekeeperOid, DateTime statementDate)
        {
        }

        public bool HasData { get; set; }

        public void CreateDocument()
        {
        }

        public void ExportToPdf(string filename)
        {
        }
    }
}