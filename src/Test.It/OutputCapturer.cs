using System;
using System.IO;
using System.Threading;
using Test.It.Writers;

namespace Test.It
{
    internal static class OutputCapturer
    {
        private static readonly AsyncLocal<Guid> LocalCaptureId = new AsyncLocal<Guid>();

        public static DistributingTextWriter Writer { get; } = new DistributingTextWriter();

        public static IDisposable Capture(TextWriter output)
        {
            var id = Guid.NewGuid();

            var filteringTextWriter = new FilteringTextWriterDecorator(output, () => ShouldCapture(id));

            LocalCaptureId.Value = id;
            var unregistrer = Writer.Register(filteringTextWriter);

            return new DisposeAction(() =>
            {
                LocalCaptureId.Value = Guid.Empty;
                unregistrer.Dispose();
                filteringTextWriter.Dispose();
            });
        }

        private static bool ShouldCapture(Guid id)
        {
            return LocalCaptureId.Value == id;
        }
    }
}