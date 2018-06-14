using System.IO;
using System.Text;

namespace Test.It.Tests.Helpers
{
    internal class ToStringTextWriter : TextWriter
    {
        private readonly StringBuilder _output = new StringBuilder();

        public string Output => _output.ToString();

        public override void Write(char value)
        {
            _output.Append(value);
        }

        public override Encoding Encoding => Encoding.UTF8;
    }
}