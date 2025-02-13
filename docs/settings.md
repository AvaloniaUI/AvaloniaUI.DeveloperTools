# Developer Tools Settings

| Category | Setting | Description | Default Value |
|----------|---------|-------------|---------------|
| **Appearance** |
| | Theme Variant | Controls the application's color theme | Dark |
| | Exit On Last Window Close | Determines if the application should exit when the last window is closed | true |
| | Skip Welcome Window | Bypasses the welcome screen on application startup | false |
| | Enable Protocol Monitor | Shows diagnostic communication protocol monitoring window | false |
| **Elements Tree** |
| | Aggregate Templates | Combines template visual children into a single tree node for cleaner visualization, collapsed by default | true |
| | InlinePseudoclasses | By default, only visible element pseudoclasses are right-aligned in the tree, and the rest is hidden in the overlay button. This settings allows to inline all pseudoclasses regardless of their visibility. | false |
| | Contextual Properties | Only shows properties relevant to the current context/state of the selected element. For example, `Grid.Row` property only visible on direct `Grid` children | true |
| | Include CLR Properties | Displays .NET CLR properties in addition to Avalonia-specific properties, excluding duplicates | false |
| **Overlay** |
| | Show ToolTip Info | Displays tooltips with control information on hovered element | true |
| | Visualize Margin & Padding | Highlights margin, padding and border areas of hovered element | true |
| | Show Rulers | Displays measurement rulers for precise element positioning | true |
| | Show Extension Lines | Shows guide lines between hovered element and ruler | true |
| **Events** |
| | Default Routed Events | List of events to track by default in the events tool | `Button.ClickEvent`, `InputElement.KeyDownEvent`, `InputElement.KeyUpEvent`, `InputElement.TextInputEvent`, `InputElement.PointerReleasedEvent`, `InputElement.PointerPressedEvent` |
| **Metrics** |
| | Additional Performance Meters | List of performance counters to monitor in the metrics tool | `Avalonia` (11.3.0+), `System.Runtime`, `System.Net.Http` |
| **Protocol** |
| | HTTP port | Defines HTTP port used to listen for app connections. Requires restart on change. Needs to be in-sync with `DeveloperToolsOptions.Protocol` set-up in the target app. | 29414 |
