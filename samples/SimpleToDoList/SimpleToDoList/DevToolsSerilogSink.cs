using System;
using System.Collections.Generic;
using AvaloniaUI.DiagnosticsProtocol.Application;
using AvaloniaUI.DiagnosticsSupport;
using Serilog.Core;
using Serilog.Events;

namespace SimpleToDoList;

public class DevToolsSerilogSink(string logArea = "Serilog", IFormatProvider? formatProvider = null)
    : ILogEventSink, ILoggerObservable
{
    private readonly LinkedList<ILoggerObserver> _observers = [];

    public IDisposable Subscribe(ILoggerObserver observer)
    {
        _observers.AddLast(observer);
        return new Unsubscribe(this, observer);
    }

    public void Emit(LogEvent logEvent)
    {
        var logLevel = logEvent.Level switch
        {
            LogEventLevel.Verbose => LogEntryVerbosity.Verbose,
            LogEventLevel.Debug => LogEntryVerbosity.Debug,
            LogEventLevel.Information => LogEntryVerbosity.Information,
            LogEventLevel.Warning => LogEntryVerbosity.Warning,
            LogEventLevel.Error => LogEntryVerbosity.Error,
            LogEventLevel.Fatal => LogEntryVerbosity.Fatal,
            _ => throw new ArgumentOutOfRangeException()
        };

        var parameters = new string[logEvent.Properties.Count];
        var paramIndex = 0;
        foreach (var value in logEvent.Properties.Values)
        {
            parameters[paramIndex++] = value.ToString(null, formatProvider);
        }

        foreach (var observer in _observers)
        {
            if (observer.IsEnabled(logLevel, logArea))
            {
                observer.Log(logLevel, logArea, null, logEvent.MessageTemplate.Text, logEvent.Exception, parameters);
            }
        }
    }

    private class Unsubscribe(DevToolsSerilogSink @this, ILoggerObserver observer) : IDisposable
    {
        public void Dispose() => @this._observers.Remove(observer);
    }
}
