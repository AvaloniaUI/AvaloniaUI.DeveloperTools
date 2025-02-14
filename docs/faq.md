# Frequently Asked Questions

## Is it possible to connect multiple instances to the Developer Tools?

Yes, while single instance of Developer Tools is running and activated, you can connect one or many apps to it.
Each new connection will open a new Developer Tools window, working independently from each other.

## Does it work with Browser/Android/iOS?

It does work with mobile and browser applications. But it requires slightly different setup, mainly - Developer Tools application has to be opened manually, as it's not possible to run desktop prcesses from the sandboxed environment or mobile.

## Can I use Developer Tools and DiagnosticsPackage with NativeAOT app?

Yes. DiagnosticsPackage is fully trimming friendly. Even though it does use reflection, the tool was tested with AOT.

## Is AvaloniaUI Developer Tools open source?

No, it's not.

## Are arm64 and x86 builds of the tool available or planned?

Only **x64** builds for Windows, macOS and Linux are available at the moment. Where **arm64** is supported via platform emulation.

We have plans to eventually release native **arm64** builds.

No **x86** builds are available nor planned.

## I have another question. Where can I ask it?

Feel free to leave your questions or other feedback on [AvaloniaUI/AvaloniaUI.DeveloperTools](https://github.com/AvaloniaUI/AvaloniaUI.DeveloperTools/ ) repository.
