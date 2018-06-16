using System;
using System.IO;
using System.Text;

namespace Test.It.Writers
{
    internal class ListeningTextWriter : TextWriter
    {
        public event Action<char> OnWriting;

        public override void Write(char value)
        {
            OnWriting?.Invoke(value);
        }

        public override Encoding Encoding => Encoding.Default;
    }
}