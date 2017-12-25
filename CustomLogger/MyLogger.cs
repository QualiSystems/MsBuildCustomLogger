using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace CustomLogger
{
    public class MyLogger : Logger
    {
        private const string Red = "\u001b[31;1m";
        private const string Yellow = "\u001b[33;1m";
        private const string Gray = "\u001b[38;5;247m";
        private const string Default = "\u001b[0m";

        private static void WriteConsoleLine(string color, string message)
        {
            Console.WriteLine(color + message + Default);
        }

        public override void Initialize(IEventSource eventSource)
        {
            eventSource.ProjectStarted += ProjectStarted;
            eventSource.ProjectFinished += ProjectFinished;
            eventSource.MessageRaised += MessageRaised;
            eventSource.ErrorRaised += ErrorRaised;
            eventSource.WarningRaised += WarningRaised;
            eventSource.TargetStarted += TargetStarted;
        }

        void TargetStarted(object sender, TargetStartedEventArgs e)
        {
        }

        void WarningRaised(object sender, BuildWarningEventArgs e)
        {
            if (!IsVerbosityAtLeast(LoggerVerbosity.Normal))
                return;

            var notWarn = e.Code == "MSB4098";

            if (!notWarn || IsVerbosityAtLeast(LoggerVerbosity.Normal))
            {
                WriteConsoleLine(Yellow, FormatWarningEvent(e));
            }
        }

        void ErrorRaised(object sender, BuildErrorEventArgs e)
        {
            WriteConsoleLine(Red, FormatErrorEvent(e));
        }

        void MessageRaised(object sender, BuildMessageEventArgs e)
        {
            if (!IsVerbosityAtLeast(LoggerVerbosity.Normal))
                return;

            switch (e.Importance)
            {
                case MessageImportance.High:
                case MessageImportance.Normal:
                        WriteConsoleLine(Default, e.Message);
                    break;
                case MessageImportance.Low:
                    if (IsVerbosityAtLeast(LoggerVerbosity.Detailed))
                        WriteConsoleLine(Gray, e.Message);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void ProjectStarted(object sender, ProjectStartedEventArgs e)
        {
        }

        void ProjectFinished(object sender, ProjectFinishedEventArgs e)
        {
        }
    }
}
