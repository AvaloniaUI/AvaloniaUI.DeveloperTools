# Application Metrics Tool

## Interacting with metrics

TODO

## Disabling/Enabling default sources

TODO

## Enabling custom metric sources

By default, `Developer Tools` is configured to only accept Avalonia and several .NET BCL metric sources.

You can follow .NET [Collect metrics](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/metrics-collection) documentation on how to write custom metric sources which then can be previewed in the `Developer Tools` or the official `dotnet-counters` console tool.

Before viewing them in the `Developer Tools`, it's necessary to allow this source by adding `Meter` name to the `Additional Performance Meters` field on the settings page.
