# Architecture Documentation

## System Architecture

```
┌─────────────────────────────────────────────────────────┐
│                   WinUI 3 Application                    │
├─────────────────────────────────────────────────────────┤
│                                                          │
│  ┌────────────────────────────────────────────────┐    │
│  │              App.xaml / App.xaml.cs            │    │
│  │  - Application Entry Point                     │    │
│  │  - Window Creation                             │    │
│  └────────────────────────────────────────────────┘    │
│                         │                               │
│                         ▼                               │
│  ┌────────────────────────────────────────────────┐    │
│  │       MainWindow.xaml / MainWindow.xaml.cs     │    │
│  ├────────────────────────────────────────────────┤    │
│  │  UI Layer (XAML)                               │    │
│  │  - Grid Layout                                 │    │
│  │  - FolderPicker Button                         │    │
│  │  - ListBox (SVG Files)                         │    │
│  │  - SKXamlCanvas (Display)                      │    │
│  │  - Navigation Buttons                          │    │
│  ├────────────────────────────────────────────────┤    │
│  │  Logic Layer (C#)                              │    │
│  │  - Folder Selection                            │    │
│  │  - File Management                             │    │
│  │  - SVG Loading                                 │    │
│  │  - Rendering Control                           │    │
│  └────────────────────────────────────────────────┘    │
│                                                          │
└─────────────────────────────────────────────────────────┘
                           │
                           ▼
┌─────────────────────────────────────────────────────────┐
│                   External Dependencies                  │
├─────────────────────────────────────────────────────────┤
│                                                          │
│  ┌──────────────────┐  ┌──────────────────┐           │
│  │  Windows App SDK │  │   SkiaSharp       │           │
│  │  - WinUI 3       │  │   - Graphics      │           │
│  │  - FolderPicker  │  │   - Canvas        │           │
│  └──────────────────┘  └──────────────────┘           │
│                                                          │
│  ┌──────────────────┐  ┌──────────────────┐           │
│  │  SkiaSharp.Views │  │   Svg.Skia       │           │
│  │  - WinUI         │  │   - SVG Parser   │           │
│  │  - SKXamlCanvas  │  │   - SVG Renderer │           │
│  └──────────────────┘  └──────────────────┘           │
│                                                          │
└─────────────────────────────────────────────────────────┘
```

## Component Diagram

```
┌─────────────────────────────────────────────────────┐
│                  MainWindow.xaml                     │
├──────────────┬──────────────────────────────────────┤
│              │                                      │
│  ┌─────────┐ │   ┌──────────────────────────┐      │
│  │ Button  │─┼──▶│  FolderPicker Dialog     │      │
│  │ "Select"│ │   └──────────────────────────┘      │
│  └─────────┘ │             │                        │
│              │             ▼                        │
│  ┌─────────┐ │   ┌──────────────────────────┐      │
│  │ ListBox │◀┼───│ LoadSvgFilesFromFolder() │      │
│  │ Files   │ │   └──────────────────────────┘      │
│  └─────────┘ │             │                        │
│      │       │             │                        │
│      │       │   ┌─────────▼───────────┐           │
│      └───────┼──▶│ LoadAndDisplaySvg() │           │
│              │   └─────────┬───────────┘           │
│              │             │                        │
│              │   ┌─────────▼───────────┐           │
│              │   │   SKSvg.Load()      │           │
│  ┌─────────┐ │   └─────────┬───────────┘           │
│  │ Canvas  │◀┼─────────────┘                       │
│  │ Display │ │   ┌──────────────────────────┐      │
│  └─────────┘ │   │ SkiaCanvas_PaintSurface()│      │
│              │   └──────────────────────────┘      │
│  ┌─────────┐ │             │                        │
│  │ Prev/   │ │             ▼                        │
│  │ Next    │─┼──▶  Update Selection                │
│  └─────────┘ │                                      │
│              │                                      │
└──────────────┴──────────────────────────────────────┘
```

## Data Flow

```
User Action: Click "Select Folder"
    │
    ▼
┌─────────────────────────┐
│ SelectFolderButton_Click│
└───────────┬─────────────┘
            │
            ▼
┌─────────────────────────┐
│   FolderPicker.Pick()   │
└───────────┬─────────────┘
            │
            ▼ (StorageFolder)
┌─────────────────────────┐
│ LoadSvgFilesFromFolder()│
└───────────┬─────────────┘
            │
            ├─► Scan for .svg files
            ├─► Filter by extension
            ├─► Sort alphabetically
            └─► Populate ListBox
            │
            ▼
┌─────────────────────────┐
│  ListBox.SelectedIndex  │
└───────────┬─────────────┘
            │
            ▼ (Selection Change)
┌─────────────────────────┐
│SvgFilesList_SelectionCh │
└───────────┬─────────────┘
            │
            ▼
┌─────────────────────────┐
│  LoadAndDisplaySvg()    │
└───────────┬─────────────┘
            │
            ├─► Create new SKSvg()
            ├─► Load SVG from file
            └─► Invalidate Canvas
            │
            ▼
┌─────────────────────────┐
│ SkiaCanvas_PaintSurface │
└───────────┬─────────────┘
            │
            ├─► Clear Canvas
            ├─► Get Picture bounds
            ├─► Calculate scale
            ├─► Center SVG
            └─► Draw Picture
            │
            ▼
        SVG Displayed
```

## Class Structure

```
┌─────────────────────────────────────────┐
│              App                        │
├─────────────────────────────────────────┤
│ + OnLaunched(args)                      │
│ - m_window: Window?                     │
└─────────────────────────────────────────┘
                    │
                    │ creates
                    ▼
┌─────────────────────────────────────────┐
│           MainWindow                    │
├─────────────────────────────────────────┤
│ Fields:                                 │
│ - _svgFiles: List<string>               │
│ - _currentIndex: int                    │
│ - _currentSvg: SKSvg?                   │
├─────────────────────────────────────────┤
│ Methods:                                │
│ + SelectFolderButton_Click()            │
│ - LoadSvgFilesFromFolder()              │
│ - SvgFilesList_SelectionChanged()       │
│ - LoadAndDisplaySvg()                   │
│ - SkiaCanvas_PaintSurface()             │
│ - PreviousButton_Click()                │
│ - NextButton_Click()                    │
│ - UpdateNavigationButtons()             │
└─────────────────────────────────────────┘
                    │
                    │ uses
                    ▼
┌─────────────────────────────────────────┐
│            SKSvg (Svg.Skia)             │
├─────────────────────────────────────────┤
│ + Load(filePath): void                  │
│ + Picture: SKPicture?                   │
└─────────────────────────────────────────┘
```

## Event Flow

```
User Interaction
    │
    ├─► Button Click Events
    │   ├─► SelectFolderButton_Click
    │   ├─► PreviousButton_Click
    │   └─► NextButton_Click
    │
    ├─► Selection Events
    │   └─► SvgFilesList_SelectionChanged
    │
    └─► Rendering Events
        └─► SkiaCanvas_PaintSurface

Internal Events
    │
    ├─► Canvas.Invalidate()
    │   └─► Triggers PaintSurface
    │
    └─► SelectedIndex Change
        └─► Triggers SelectionChanged
```

## State Management

```
Application State:
┌─────────────────────────────────────┐
│ _svgFiles: List<string>             │  ← All SVG file paths in folder
│ _currentIndex: int                  │  ← Currently selected file index
│ _currentSvg: SKSvg?                 │  ← Currently loaded SVG object
└─────────────────────────────────────┘

State Transitions:
    Initial State: Empty
        │
        ▼ Select Folder
    Folder Loaded: _svgFiles populated, _currentIndex = 0
        │
        ▼ Select File
    File Loaded: _currentSvg loaded, Canvas displays SVG
        │
        ▼ Navigate
    Different File: _currentIndex updated, _currentSvg reloaded
```

## File Structure

```
WinUISvgViewer/
│
├── App.xaml                          # Application Resources
│   └── App.xaml.cs                   # Application Entry Point
│
├── MainWindow.xaml                   # Main UI Definition
│   └── MainWindow.xaml.cs            # UI Logic & Event Handlers
│
├── Package.appxmanifest              # App Package Manifest
├── app.manifest                      # App Execution Manifest
├── WinUISvgViewer.csproj             # Project Configuration
│
└── Assets/                           # Application Assets
    ├── Square44x44Logo.png
    ├── Square150x150Logo.png
    ├── Wide310x150Logo.png
    ├── SplashScreen.png
    └── StoreLogo.png
```

## Threading Model

```
┌─────────────────────────────────────────┐
│         UI Thread (Main Thread)         │
├─────────────────────────────────────────┤
│                                         │
│  ┌───────────────────────────────┐     │
│  │  async/await for I/O:         │     │
│  │  - FolderPicker.Pick()        │     │
│  │  - folder.GetFilesAsync()     │     │
│  └───────────────────────────────┘     │
│              │                          │
│              ▼                          │
│  ┌───────────────────────────────┐     │
│  │  Synchronous Operations:      │     │
│  │  - SKSvg.Load()               │     │
│  │  - Canvas.DrawPicture()       │     │
│  │  - UI Updates                 │     │
│  └───────────────────────────────┘     │
│                                         │
└─────────────────────────────────────────┘

Note: All operations run on UI thread.
SKSvg.Load() could be moved to background
thread for large files (future optimization).
```

## Dependencies Graph

```
WinUISvgViewer
    │
    ├─► Microsoft.WindowsAppSDK
    │   └─► WinUI 3 Controls
    │       ├─► Window
    │       ├─► Button
    │       ├─► ListBox
    │       └─► FolderPicker
    │
    ├─► SkiaSharp
    │   └─► Graphics Engine
    │       ├─► SKCanvas
    │       ├─► SKPicture
    │       └─► SKColors
    │
    ├─► SkiaSharp.Views.WinUI
    │   └─► SKXamlCanvas
    │       └─► PaintSurface Event
    │
    └─► Svg.Skia
        └─► SKSvg
            ├─► Load()
            └─► Picture
```

## Design Patterns Used

### 1. Event-Driven Architecture
- UI events trigger business logic
- Separation of concerns between UI and logic

### 2. Observer Pattern
- SKXamlCanvas observes SVG changes via Invalidate()
- ListBox selection notifies MainWindow

### 3. Lazy Loading
- SVGs loaded only when selected
- Resources freed when not needed

### 4. Facade Pattern
- SKSvg provides simple interface to complex SVG parsing
- SkiaSharp abstracts complex graphics operations

## Error Handling Strategy

```
┌─────────────────────────────────────┐
│     Try-Catch at Key Points         │
├─────────────────────────────────────┤
│                                     │
│  LoadAndDisplaySvg()                │
│  ├─► try { Load SVG }               │
│  └─► catch { Show Error Message }  │
│                                     │
│  Other methods:                     │
│  └─► Defensive programming          │
│      ├─► null checks                │
│      └─► bounds checks              │
│                                     │
└─────────────────────────────────────┘

Error Recovery:
    Error occurs
        │
        ▼
    Display user-friendly message
        │
        ▼
    Clear canvas (white background)
        │
        ▼
    Application continues running
```

## Performance Considerations

### Optimization Points

1. **File Loading**: Async I/O operations
2. **SVG Parsing**: Handled by optimized Svg.Skia library
3. **Rendering**: GPU-accelerated via SkiaSharp
4. **Memory**: Single SVG cached at a time

### Scalability

- **Small folders (< 100 files)**: Instant loading
- **Medium folders (100-1000 files)**: Sub-second loading
- **Large folders (> 1000 files)**: May need virtual list optimization

### Future Optimizations

1. Virtual scrolling for large file lists
2. Thumbnail generation and caching
3. Background SVG pre-loading
4. Multi-threaded file scanning
