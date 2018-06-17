using System;
using System.Diagnostics;
using System.IO;

namespace Test.It
{
    public static class Output
    {
        private static readonly TextWriterTraceListener TextWriterTraceListener = new TextWriterTraceListener(OutputCapturer.Writer);

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
            OutputCapturer.Writer.OnWriting += new StreamWriter(Console.OpenStandardOutput()).Write;
            Console.SetOut(OutputCapturer.Writer);
        }
    }
}