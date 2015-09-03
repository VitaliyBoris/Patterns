using System.Collections.Generic;
using Patterns.Common;

namespace Patterns.TemplateMethod.DelegateBased
{
    public interface ILogSaver
    {
        void UploadLogEntries(IEnumerable<LogEntry> logEntries);

        void UploadExceptions(IEnumerable<ExceptionLogEntry> exceptions);
    }
}