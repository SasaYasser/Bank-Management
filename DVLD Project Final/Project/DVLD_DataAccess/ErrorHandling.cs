using System;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    internal static class clsErrorHandling
    {
        public static void LogError(Exception ex, string sourceName = "DVLD")
        {
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
        }
    }
}