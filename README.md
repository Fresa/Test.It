# Test.It
Abstract testing framework.

[![Build status](https://ci.appveyor.com/api/projects/status/365r5txc1s431mu0?svg=true)](https://ci.appveyor.com/project/Fresa/test-it)

[![Build history](https://buildstats.info/appveyor/chart/Fresa/test-it)](https://ci.appveyor.com/project/Fresa/test-it/history)

## Download
https://www.nuget.org/packages/Test.It/

## Getting Started
Let your unit test specification inherit `Specification` or `SpecificationAsync` to utilize a simple BDD test design. See the tests for examples. 

## Output
When testing multiple tests in parallel it can sometimes be problematic to isolate logs between the tests, specifically when using globally defined logging frameworks like <a href="https://nlog-project.org/" target="_blank">NLog</a>. In order to handle that, use the `Output` or `OutputCapturer` classes to capture logs per test. See the tests for example.

## Output to Trace and Console
Setting up output for `Trace` and `Console` must be done explicitly by using `Output.WriteToTrace()` and `Output.WriteToConsole()`. Make sure to reset the output by disposing the returned 'subscription' when done. 

It's usually not recommended using any of these when running tests, specifically not when running tests in parallel since it is hard to isolate the output per test. Testing frameworks like <a href="https://xunit.github.io/" target="_blank">XUnit</a> therefor provides output helpers which can be wired up with the `OutputCapturer`. 