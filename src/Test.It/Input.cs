using System;
using System.IO;

namespace Test.It
{
    public static class Input
    {
        public static TextWriter Writer => InputCapturer.Writer;

        public static IDisposable WriteTo(TextWriter output)
        {
            return InputCapturer.Capture(output);
        }
    }
}