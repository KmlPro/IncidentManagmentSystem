using System;
using Microsoft.Extensions.Logging;
using NUnitFramework = NUnit.Framework;

//kbytner 18.10.2020 - inspiration https://github.com/MarshallMoorman/Extensions.Logging.NUnit
namespace IncidentReport.Infrastructure.ReadModels.IntegrationTests.NUnitTestLogger
{
    public class NUnitLogger : ILogger
    {
        private readonly Func<string, LogLevel, bool> _filter;
        private readonly string _name;

        public NUnitLogger(string name)
            : this(name, filter: null)
        {
        }

        public NUnitLogger(string name, Func<string, LogLevel, bool> filter)
        {
            this._name = string.IsNullOrEmpty(name) ? nameof(NUnitLogger) : name;
            this._filter = filter;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NoopDisposable.Instance;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            var runningInNUnitContext = NUnitFramework.TestContext.Progress != null;
            return this.RunningInNUnitContext() && logLevel != LogLevel.None
                                                && (this._filter == null || this._filter(this._name, logLevel));
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!this.IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            message = $"{ logLevel }: {message}";

            if (exception != null)
            {
                message += Environment.NewLine + Environment.NewLine + exception.ToString();
            }

            this.WriteMessage(message, this._name);
        }

        private bool RunningInNUnitContext()
        {
            return NUnitFramework.TestContext.Progress != null;
        }

        private void WriteMessage(string message, string name)
        {
            NUnitFramework.TestContext.WriteLine(message);
        }

        private class NoopDisposable : IDisposable
        {
            public static NoopDisposable Instance = new NoopDisposable();

            public void Dispose()
            {
            }
        }
    }
}
