using System;
using System.Collections.Generic;
using System.ServiceModel;
using Patterns.Common;

namespace Patterns.TemplateMethod.DelegateBased
{
    public class LogSaverProxy : ILogSaver
    {
        class LogSaverClient : ClientBase<ILogSaver>
        {
            public ILogSaver LogSaver
            {
                get { return Channel; }
            }
        }

        public void UploadLogEntries(IEnumerable<LogEntry> logEntries)
        {
            UseProxyClient(c => c.UploadLogEntries(logEntries));
        }

        public void UploadExceptions(IEnumerable<ExceptionLogEntry> exceptions)
        {
            UseProxyClient(c => c.UploadExceptions(exceptions));
        }

        private void UseProxyClient(Action<ILogSaver> accessor)
        {
            var client = new LogSaverClient();

            try
            {
                accessor(client.LogSaver);
                client.Close();
            }
            catch (CommunicationException)
            {
                client.Abort();
                throw;
            }
        }
    }
}