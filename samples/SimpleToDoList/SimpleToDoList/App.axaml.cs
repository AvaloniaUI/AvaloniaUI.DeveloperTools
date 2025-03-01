using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Serilog;
using Serilog.Core;
using SimpleToDoList.Services;
using SimpleToDoList.ViewModels;
using SimpleToDoList.Views;

namespace SimpleToDoList;

public partial class App: Application
{
    public static Logger? Logger { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        var sink = new DevToolsSerilogSink();

        Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Sink(sink)
            .CreateLogger();

        this.AttachDeveloperTools(o =>
        {
            o.AddLoggerObservable(sink);
            o.ConnectOnStartup |= Design.IsDesignMode;
        });
    }

    // This is a reference to our MainViewModel which we use to save the list on shutdown. You can also use Dependency Injection 
    // in your App.
    private readonly MainViewModel _mainViewModel = new MainViewModel();

    public override async void OnFrameworkInitializationCompleted()
    {
        //BindingPlugins.DataValidators.RemoveAt(0);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow { DataContext = _mainViewModel };
            desktop.ShutdownRequested += DesktopOnShutdownRequested;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView { DataContext = _mainViewModel };
        }

        base.OnFrameworkInitializationCompleted();

        // Init the MainViewModel 
        await InitMainViewModelAsync();
    }

    // We want to save our ToDoList before we actually shutdown the App. As File I/O is async, we need to wait until file is closed 
    // before we can actually close this window

    private bool _canClose; // This flag is used to check if window is allowed to close
    private async void DesktopOnShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
    {
        e.Cancel = !_canClose; // cancel closing event first time

        if (!_canClose)
        {
            // To save the items, we map them to the ToDoItem-Model which is better suited for I/O operations
            var itemsToSave = _mainViewModel.ToDoItems.Select(item => item.GetToDoItem());
            
            await ToDoListFileService.SaveToFileAsync(itemsToSave);
            
            // Set _canClose to true and Close this Window again
            _canClose = true;
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown();
            }
        }
    }
    
    // Optional: Load data from disc
    private async Task InitMainViewModelAsync()
    {
        // get the items to load
        var itemsLoaded = await ToDoListFileService.LoadFromFileAsync();

        if (itemsLoaded is not null)
        {
            foreach (var item in itemsLoaded)
            {
                _mainViewModel.ToDoItems.Add(new ToDoItemViewModel(item));
            }
        }
    }
}