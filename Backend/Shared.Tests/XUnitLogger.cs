﻿using System;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace HeyImIn.Shared.Tests
{
	public class XUnitLogger<T> : ILogger<T>, IDisposable
	{
		public XUnitLogger(ITestOutputHelper output)
		{
			_output = output;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			_output.WriteLine(state.ToString());
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return logLevel >= LogLevel.Information;
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			return this;
		}

		public void Dispose()
		{
		}

		private readonly ITestOutputHelper _output;
	}
}
