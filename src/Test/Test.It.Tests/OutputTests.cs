using System;
using System.Diagnostics;
using FluentAssertions;
using Moq;
using Test.It.Tests.Helpers;
using Xunit;

namespace Test.It.Tests
{
    namespace Given_an_output_target
    {
        public class When_writing_to_trace : XUnit2Specification
        {
            private ToStringTextWriter _toStringTextWriter;

            protected override void Given()
            {
                _toStringTextWriter = new ToStringTextWriter();
                Output.WriteTo(_toStringTextWriter);
            }

            protected override void When()
            {
                Trace.WriteLine("Writing to");
                Trace.Write("trace");
            }

            [Fact]
            public void It_should_have_sent_the_output_to_the_output_target()
            {
                _toStringTextWriter.Output.Should().Be("Writing to\r\ntrace");
            }
        }

        public class When_writing_to_trace_utilizing_xunit_parallelism : XUnit2Specification
        {
            private ToStringTextWriter _toStringTextWriter;

            protected override void Given()
            {
                _toStringTextWriter = new ToStringTextWriter();
                Output.WriteTo(_toStringTextWriter);
            }

            protected override void When()
            {
                Trace.WriteLine("Writing again to");
                Trace.Write("tracing");
            }

            [Fact]
            public void It_should_have_sent_the_output_to_the_output_target()
            {
                _toStringTextWriter.Output.Should().Be("Writing again to\r\ntracing");
            }
        }

        // Will not work stable with a test runner that hijacks Console like NCrunch
        public class When_writing_to_console : XUnit2Specification
        {
            private ToStringTextWriter _toStringTextWriter;

            protected override void Given()
            {
                _toStringTextWriter = new ToStringTextWriter();
                Output.WriteTo(_toStringTextWriter);
            }

            protected override void When()
            {
                Console.WriteLine("Writing");
                Console.Write("to console");
            }

            [Fact]
            public void It_should_have_sent_the_output_to_the_output_target()
            {
                _toStringTextWriter.Output.Should().Be("Writing\r\nto console");
            }
        }

        // Will not work stable with a test runner that hijacks Console like NCrunch
        public class When_writing_to_console_utilizing_xunit_parallelism : XUnit2Specification
        {
            private ToStringTextWriter _toStringTextWriter;

            protected override void Given()
            {
                _toStringTextWriter = new ToStringTextWriter();
                Output.WriteTo(_toStringTextWriter);
            }

            protected override void When()
            {
                Console.WriteLine("Writing again");
                Console.Write("to the console");
            }

            [Fact]
            public void It_should_have_sent_the_output_to_the_output_target()
            {
                _toStringTextWriter.Output.Should().Be("Writing again\r\nto the console");
            }
        }
    }
    
}