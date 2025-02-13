# Getting Started

:::note

You can find pre-setup demo project by [AvaloniaUI/AvaloniaUI.DeveloperTools/samples/SimpleToDoList](https://github.com/AvaloniaUI/AvaloniaUI.DeveloperTools/tree/main/samples/SimpleToDoList#simpletodolist).

:::

## Step 1: Prepare NuGet feed

Avalonia Accelerate packages are distributed via a special NuGet feed that can be accessed with your AvaloniaUI portal credentials.

You can use Visual Studio documentation on how to add custom NuGet feed: [Install NuGet packages with Visual Studio](https://learn.microsoft.com/en-us/azure/devops/artifacts/nuget/consume?view=azure-devops&tabs=windows).
Or you can do it manually by creating a NuGet.config file at the root of your solution, or modify an existing one to contain the following:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="api.nuget.org" value="https://api.nuget.org/v3/index.json" />
    <add key="avalonia-pro" value="https://pro-nuget-feed.avaloniaui.net/v3/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <avalonia-pro>
      <add key="Username" value="<YOUR_PORTAL_USERNAME>" />
      <add key="ClearTextPassword" value="<YOUR_PORTAL_LICENSE_KEY>" />
    </avalonia-pro>
  </packageSourceCredentials>
</configuration>
```

Where `<YOUR_PORTAL_USERNAME>` is username for `https://portal.avaloniaui.net/` and `<YOUR_PORTAL_LICENSE_KEY>` is a license key that was received after completing seat purchase.

:::note
This NuGet Feed can also be configured globally, by modifying common NuGet.Config that can be found by following [Common NuGet configurations](https://learn.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior).
:::

## Step 2: Installing AvaloniaUI DeveloperTools .NET tool

AvaloniaUI DeveloperTools is currently distributed and updated via .NET tool mechanism.
By default, this tools should be installed only globally. For locally installed tool your also need to redefine `Diagnostics Support` runner by following [Extra Options](./extra-options.md) pages.

For macOS:

```bash
dotnet tool install --global AvaloniaUI.DeveloperTools.macOS --version "1.0.0-*"
```

For Windows:

```bash
dotnet tool install --global AvaloniaUI.DeveloperTools.Windows --version "1.0.0-*"
```

For Linux:

```bash
dotnet tool install --global AvaloniaUI.DeveloperTools.Linux --version "1.0.0-*"
```

When new version is released, Developer Tools will show notifications about new release.
It can be then installed via similar `dotnet tool update` command.

## Step 3: Installing Diagnostics Support package

`Diagnostics Support` package is responsible for establishment a connection bridge between user app and Developer Tools process.

This package can be installed either in the executable project with your Program AppBuilder or shared project with your Application, depending on your preferences and app architecture. This package is also compatible with Browser and Mobile projects.

In both cases, command is the same:

```bash
dotnet add package AvaloniaUI.DiagnosticsSupport.Avalonia --version "1.0.0-*"
```

:::note
`Diagnostics Support` package is compatible with .NET 6 and Avalonia 11.2.3 or newer.
We plan to lower Avalonia support to 11.1.x.
:::

## Step 4: Configuring your project

Once `DiagnosticsSupport` package is installed, you need to enable it in your `Application` class:

```csharp
public override void Initialize()
{
    AvaloniaXamlLoader.Load(this);

    this.AttachDeveloperTools();
}
```

Alternatively, it's possible to use `.WithDeveloperTools()` extension method on your AppBuilder.

These methods also accept `DeveloperToolsOptions` options class allowing to customize `Diagnostics Support` setup. See [Extra Options](./extra-options.md) for more details.

## Step 5: Run the tool

When your target app is running, press F12 to initialize connection.
`Diagnostics Support` will automatically run `Developer Tools` executable and initiate connection between processes.
Initial `MacOS` execution might take longer due to Gatekeeper validation. Following executions should be instant.

:::note

Since Browser/Mobile projects can't run `Developer Tools` executable, you need to run the tool manually before connecting it to your app.
With default installation, you only need to run a single command:

```
avdt
```

:::

## Step 6: Activate the tool

Once `Developer Tools` opened, you will be asked to input `AvaloniaUI Portal` credentials that were used to purchase and license the tool. This is the only time when tool requires internet connection. After that tool can be used offline or until license key session expires.

<img width="418" alt="Screenshot 2025-02-13 at 3 50 03 AM" src="https://github.com/user-attachments/assets/d1c47c0a-f891-4cdb-8ec9-44ca4b65928f" />

## Step 7: Done!

After activation, connection with the app will be resumed, and main Developer Tools window will be opened. 

You can read more about tools and features on this documentation.
