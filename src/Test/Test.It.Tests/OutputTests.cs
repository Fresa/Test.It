using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Test.It.Tests.Helpers;
using Xunit;

namespace Test.It.Tests
{
    namespace Given_an_output_target
    {
        public class When_writing_to_trace : XUnit2Specification, IDisposable
        {
            private ToStringTextWriter _toStringTextWriter;
            private List<IDisposable> _subscriptions = new List<IDisposable>();

            protected override void Given()
            {
                _toStringTextWriter = new ToStringTextWriter();
                _subscriptions.Add(Output.WriteTo(_toStringTextWriter));
                _subscriptions.Add(Output.WriteToTrace());
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

            public void Dispose()
            {
                _toStringTextWriter.Dispose();
                foreach (var subscription in _subscriptions)
                {
                    subscription.Dispose();
                }
            }
        }

        public class When_writing_to_trace_utilizing_xunit_parallelism : XUnit2Specification, IDisposable
        {
            private ToStringTextWriter _toStringTextWriter;
            private readonly List<IDisposable> _subscriptions = new List<IDisposable>();

            protected override void Given()
            {
                _toStringTextWriter = new ToStringTextWriter();
                _subscriptions.Add(Output.WriteTo(_toStringTextWriter));
                _subscriptions.Add(Output.WriteToTrace());
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

            public void Dispose()
            {
                _toStringTextWriter.Dispose();
                foreach (var subscription in _subscriptions)
                {
                    subscription.Dispose();
                }
            }
        }

        // Will not work stable with a test runner that hijacks Console like NCrunch
        public class When_writing_to_console : XUnit2Specification, IDisposable
        {
            private ToStringTextWriter _toStringTextWriter;
            private readonly List<IDisposable> _subscriptions = new List<IDisposable>();

            protected override void Given()
            {
                _toStringTextWriter = new ToStringTextWriter();
                _subscriptions.Add(Output.WriteTo(_toStringTextWriter));
                _subscriptions.Add(Output.WriteToConsole());
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

            public void Dispose()
            {
                _toStringTextWriter.Dispose();
                foreach (var subscription in _subscriptions)
                {
                    subscription.Dispose();
                }
            }
        }

        // Will not work stable with a test runner that hijacks Console like NCrunch
        public class When_writing_to_console_utilizing_xunit_parallelism : XUnit2Specification, IDisposable
        {
            private ToStringTextWriter _toStringTextWriter;
            private readonly List<IDisposable> _subscriptions = new List<IDisposable>();

            protected override void Given()
            {
                _toStringTextWriter = new ToStringTextWriter();
                _subscriptions.Add(Output.WriteTo(_toStringTextWriter));
                _subscriptions.Add(Output.WriteToConsole());
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

            public void Dispose()
            {
                _toStringTextWriter.Dispose();
                foreach (var subscription in _subscriptions)
                {
                    subscription.Dispose();
                }
            }
        }

        public class When_writing_to_output : XUnit2Specification, IDisposable
        {
            private ToStringTextWriter _toStringTextWriter;
            private IDisposable _subscription;

            protected override void Given()
            {
                _toStringTextWriter = new ToStringTextWriter();
                _subscription = Output.WriteTo(_toStringTextWriter);
            }

            protected override void When()
            {
                Output.Writer.WriteLine("Writing to");
                Output.Writer.Write("input");
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

        public class When_writing_to_output_utilizing_xunit_parallelism : XUnit2Specification, IDisposable
        {
            private ToStringTextWriter _toStringTextWriter;
            private IDisposable _subscription;

            protected override void Given()
            {
                _toStringTextWriter = new ToStringTextWriter();
                _subscription = Output.WriteTo(_toStringTextWriter);
            }

            protected override void When()
            {
                Output.Writer.WriteLine("Writing again to");
                Output.Writer.Write("input writer");
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