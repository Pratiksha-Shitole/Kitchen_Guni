
using System;

namespace Kitchen_Guni.Services
{
    public class MyEmailSenderException
        : ApplicationException
    {

        private const string StandardERRORMESSAGE
            = "Something went wrong while sending the email.";

        public MyEmailSenderException()
            : base(StandardERRORMESSAGE)
        {
        }

        public MyEmailSenderException(string message)
            : base(message)
        {
        }

        public MyEmailSenderException(string message, Exception exception)
            : base(message, exception)
        {
        }

    }
}