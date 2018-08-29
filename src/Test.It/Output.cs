using System;
using System.Diagnostics;
using System.IO;

namespace Test.It
{
    public static class Output
    {
        private static readonly TextWriterTraceListener TextWriterTraceListener = new TextWriterTraceListener(OutputCapturer.Writer);
        private static readonly StreamWriter ConsoleStreamWriter = new StreamWriter(Console.OpenStandardOutput());
        private static readonly object ConsoleStreamWriteLock = new object();

        static Output()
        {
            SetupTraceListener();
            SetupConsoleOut();
        }

        public static TextWriter Writer => OutputCapturer.Writer;

        public static IDisposable WriteTo(TextWriter output)
        {
            return OutputCapturer.Capture(output);
        }
        
        private static void SetupTraceListener()
        {
            Trace.Listeners.Add(TextWriterTraceListener);
        }

        private static void SetupConsoleOut()
        {
            OutputCapturer.Writer.OnWriting += character =>
            {
                lock (ConsoleStreamWriteLock)
                {
                    ConsoleStreamWriter.Write(character);
                }
            };
            Console.SetOut(OutputCapturer.Writer);
        }
    }
}