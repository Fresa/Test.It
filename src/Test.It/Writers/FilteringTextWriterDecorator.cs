using System;
using System.IO;
using System.Text;

namespace Test.It.Writers
{
    internal class FilteringTextWriterDecorator : TextWriter
    {
        private readonly TextWriter _textWriter;
        private readonly Func<bool> _filter;

        public FilteringTextWriterDecorator(TextWriter textWriter, Func<bool> filter)
        {
            _textWriter = textWriter;
            _filter = filter;
        }

        public override void Write(char value)
        {
            if (_filter())
            {
                _textWriter.Write(value);
            }
        }

        public override Encoding Encoding => _textWriter.Encoding;
    }
}