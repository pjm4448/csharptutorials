using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_in_c_sharp
{
    public interface ILoggerDemo
    {
        void LogMessage(string aString);
    }

    public class DbLogger : ILoggerDemo
    {
        public void LogMessage(string aMessage)
        {
            //Code to write message in database.
        }
    }
    public class FileLogger : ILoggerDemo
    {
        public void LogMessage(string aStackTrace)
        {
            //code to log stack trace into a file.
        }
    }

    public class ExceptionLogger
    {
        private ILoggerDemo _logger;
        public ExceptionLogger(ILoggerDemo aLogger)
        {
            this._logger = aLogger;
        }
        public virtual void LogException(Exception aException)
        {
            if (aException == null)
            {
                throw new ArgumentNullException(nameof(aException));
            }
            string strMessage = GetUserReadableMessage(aException);
            this._logger.LogMessage(strMessage);
        }
        private string GetUserReadableMessage(Exception aException)
        {
            string strMessage = string.Empty;
            //code to convert Exception's stack trace and message to user readable format.
           return strMessage;
        }
    }
}
