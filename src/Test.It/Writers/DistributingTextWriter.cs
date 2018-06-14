using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;

namespace Test.It.Writers
{
    internal class DistributingTextWriter : TextWriter
    {
        private readonly ConcurrentDictionary<Guid, TextWriter> _textWriters = new ConcurrentDictionary<Guid, TextWriter>();

        public IDisposable Register(TextWriter textWriter)
        {
            var id = Guid.NewGuid();
            _textWriters.TryAdd(id, textWriter);
            return new DisposeAction(() => _textWriters.TryRemove(id, out _));
        }

        public override void Write(char value)
        {
            foreach (var textWriter in _textWriters.Values)
            {
                textWriter.Write(value);
            }
        }

        public override Encoding Encoding => Encoding.Default;
    }
}