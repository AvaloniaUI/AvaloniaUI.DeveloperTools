# Reference to custom DeveloperToolsOptions

## DeveloperToolsOptions.Gesture

Defines gesture to run and connect to the `Developer Tools` process.
By default: `F12`.

## DeveloperToolsOptions.ApplicationName

Defines is app should be connected to dev tools on startup.
If unset, `Application.Name` or entry assembly name is used.

## DeveloperToolsOptions.ConnectOnStartup

Optional application display name.
By default: false.

## DeveloperToolsOptions.Runner

By default, `DiagnosticsSupport` package attempts to run global `avdt` .NET tool when requested, if `DevTools` instance is not already running.

But it is possible to redefine this behavior by changing `DeveloperToolsOptions.Runner` value:

```csharp
this.AttachDeveloperTools(new DeveloperToolsOptions
{
    Runner = DeveloperToolsOptions.DotNetTool
});
```

Possible options are:

1. `DeveloperToolsOptions.DotNetTool` - global .NET tool.
2. `DeveloperToolsOptions.AppleBundle` - runs macOS bundle by its ID. To make it work, you need to run Developer Tools process directly at least once.
3. `DeveloperToolsOptions.NoOp` - do nothing. It's only supported option on Mobile and Browser platforms.
4. `DeveloperToolsRunner.CreateFromExecutable(string)` - run executable by full path. This option is preferred, when you install .NET tool locally.
5. `DeveloperToolsRunner.GetDefaultForPlatform()` - returns `DotNetTool` on desktop or `NoOp` on mobile/browser.

## DeveloperToolsOptions.Protocol

`DiagnosticsSupport` uses one of two transport protocols to communicate between user app and `Developer Tools` process: HTTP and Named Pipes.

By default, HTTP is used on all platforms.

```csharp
this.AttachDeveloperTools(new DeveloperToolsOptions
{
    Protocol = DeveloperToolsProtocol.DefaultHttp
});
```

Possible options are:

1. `DeveloperToolsProtocol.DefaultHttp` - default HTTP connection on `29414` port and 5 seconds connection timeout.
2. `DeveloperToolsProtocol.CreateHttp(Uri, TimeSpan)` - creates HTTP connection with provided parameters. Note: you need to reconfigure Developer Tools listener port independently by following [Settings page](./settings.md).
3. `DeveloperToolsProtocol.CreateNamedPipe(string)` - creates Named Pipe connection. This option is only compatible with Desktop platforms and might be preferred if there are connectivity issues on the local machine. Named Pipe name will be automatically passed to the `Developer Tools` instance.
4. `DeveloperToolsProtocol.GetDefaultForPlatform()` - returns `DefaultHttp` on all platforms.

## DeveloperToolsOptions.DiagnosticLogger

Defines sink to which all `AvaloniaUI.DiagnosticsSupport` logs are written to.
By default is null and no `Diagnostics Support` logs are written.

Possible options are:

1. `DiagnosticLogger.CreateConsole(LogEntryVerbosity)`
2. Any user implementation of `DiagnosticLogger` abstract interface.

:::note
To learn more about `Developer Tools` logging, please read [Reporting Issue](./reporing-issue.md) page.
:::

## DeveloperToolsOptions.LoggerCollector

Defines collector which listens for logs to be displayed in Developer Tools.

By default, `Developer Tools` will listen only to Avalonia logs and display them in the [Logger tools](./tools/logs.md).

This behavior can be redefined with options:

1. `DevToolsLoggerCollector.WithAvaloniaLogs()` - default.
2. `DevToolsLoggerCollection.WithMicrosoftLogger(ILoggerFactory, LogLevel)` - allows to connect devtools as a logger provider to Microsoft `ILoggerFactory`.
3. `DevToolsLoggerCollection.WithLoggerObservable` - custom `ILoggerObservable` interface implementation. Use this option, if you want DevTools to display your third party logs provider like Serilog.
