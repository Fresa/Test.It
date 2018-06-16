using System;
using FluentAssertions;
using Test.It.Tests.Helpers;
using Xunit;

namespace Test.It.Tests
{
    namespace Given_an_input_target
    {
        public class When_writing_to_input : XUnit2Specification, IDisposable
        {
            private ToStringTextWriter _toStringTextWriter;
            private IDisposable _subscription;

            protected override void Given()
            {
                _toStringTextWriter = new ToStringTextWriter();
                _subscription= Input.WriteTo(_toStringTextWriter);
            }

            protected override void When()
            {
                Input.Writer.WriteLine("Writing to");
                Input.Writer.Write("input");
            }

            [Fact]
            public void It_should_have_sent_the_output_to_the_output_target()
            {
                _toStringTextWriter.Output.Should().Be("Writing to\r\ninput");
            }

            public void Dispose()
            {
                _toStringTextWriter.Dispose();
                _subscription.Dispose();
            }
        }

        public class When_writing_to_input_utilizing_xunit_parallelism : XUnit2Specification, IDisposable
        {
            private ToStringTextWriter _toStringTextWriter;
            private IDisposable _subscription;

            protected override void Given()
            {
                _toStringTextWriter = new ToStringTextWriter();
                _subscription = Input.WriteTo(_toStringTextWriter);
            }

            protected override void When()
            {
                Input.Writer.WriteLine("Writing again to");
                Input.Writer.Write("input writer");
            }

            [Fact]
            public void It_should_have_sent_the_output_to_the_output_target()
            {
                _toStringTextWriter.Output.Should().Be("Writing again to\r\ninput writer");
            }

            public void Dispose()
            {
                _toStringTextWriter.Dispose();
                _subscription.Dispose();
            }
        }
    }
}