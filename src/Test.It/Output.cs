using System;
using System.Diagnostics;
using System.IO;

namespace Test.It
{
    public static class Output
    {
        public static TextWriter Writer => OutputCapturer.Writer;

        public static IDisposable WriteTo(TextWriter output)
        {
            return OutputCapturer.Capture(output);
        }

        private static readonly TextWriterTraceListener TextWriterTraceListener = new TextWriterTraceListener(OutputCapturer.Writer);
        private static readonly object TraceListenerLock = new object();

        public static IDisposable WriteToTrace()
        {
            lock (TraceListenerLock)
            {
                if (Trace.Listeners.Contains(TextWriterTraceListener))
                {
                    return new DisposableAction(() => { });
                }

                Trace.Listeners.Add(TextWriterTraceListener);
            }

            return new DisposableAction(() =>
            {
                lock (TraceListenerLock)
                {
                    Trace.Listeners.Remove(TextWriterTraceListener);
                }
            });
        }

        private static readonly StreamWriter ConsoleStreamWriter = new StreamWriter(Console.OpenStandardOutput());
        private static readonly object ConsoleStreamWriteLock = new object();

        public static IDisposable WriteToConsole()
        {
            TextWriter originalConsoleWriter;
            lock (ConsoleStreamWriteLock)
            {
                originalConsoleWriter = Console.Out;
                if (originalConsoleWriter == OutputCapturer.Writer)
                {
                    return new DisposableAction(() => { });
                }

                OutputCapturer.Writer.OnWriting += WriteToConsole;
                Console.SetOut(OutputCapturer.Writer);
            }

            return new DisposableAction(() =>
            {
                OutputCapturer.Writer.OnWriting -= WriteToConsole;
                Console.SetOut(originalConsoleWriter);
            });

            void WriteToConsole(char character)
            {
                lock (ConsoleStreamWriteLock)
                {
                    ConsoleStreamWriter.Write(character);
                }
            }
        }
    }
}