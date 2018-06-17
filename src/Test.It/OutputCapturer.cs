using System;
using System.IO;
using System.Threading;
using Test.It.Writers;

namespace Test.It
{
    internal static class OutputCapturer
    {
        private static readonly AsyncLocal<Guid> LocalCaptureId = new AsyncLocal<Guid>();

        public static ListeningTextWriter Writer { get; } = new ListeningTextWriter();

        public static IDisposable Capture(TextWriter output)
        {
            var id = Guid.NewGuid();

            void Output(char character)
            {
                if (ShouldCapture(id))
                {
                    output.Write(character);
                }
            }

            LocalCaptureId.Value = id;
            Writer.OnWriting += Output;

            return new DisposableAction(() =>
            {
                Writer.OnWriting -= Output;
                LocalCaptureId.Value = Guid.Empty;
            });
        }

        private static bool ShouldCapture(Guid id)
        {
            return LocalCaptureId.Value == id;
        }
    }
}