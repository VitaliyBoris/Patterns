using System.Collections.Generic;
using System.Linq;
using Patterns.Common;

namespace Patterns.TemplateMethod.Classic
{
    public abstract class LogReader
    {
        private int _currentPosition;

        public IEnumerable<LogEntry> ReadLogEntry()
        {
            return ReadEntries(ref _currentPosition).Select(ParseLogEntry);
        }

        protected abstract IEnumerable<string> ReadEntries(ref int currentPosition);

        protected abstract LogEntry ParseLogEntry(string stringEntry);
    }
}