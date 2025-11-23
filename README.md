# WinUI 3 SVG Viewer with SkiaSharp

Eine einfache WinUI 3 Applikation (.NET 10), die SVG-Dateien mit SkiaSharp anzeigt.

## Funktionen

1. **Ordnerauswahl**: Button zum Auswählen eines Ordners mittels FolderPicker
2. **Dateiliste**: Alle SVG-Dateien im gewählten Ordner werden in einer ListBox aufgelistet
3. **SVG-Anzeige**: Ausgewählte SVG-Dateien werden mit SkiaSharp gerendert
4. **Navigation**: Vor/Zurück-Buttons zur Navigation zwischen den SVG-Dateien

## Technologie-Stack

- **.NET 10**: Neueste .NET Version
- **WinUI 3**: Moderne Windows UI Framework (Windows App SDK 1.6)
- **SkiaSharp 3.119.1**: Hochperformante 2D-Grafik-Engine
- **Svg.Skia 3.2.1**: SVG-Unterstützung für SkiaSharp

## Projektstruktur

```
WinUISvgViewer/
├── App.xaml                    # Application definition
├── App.xaml.cs                 # Application code-behind
├── MainWindow.xaml             # Main window UI
├── MainWindow.xaml.cs          # Main window logic
├── Package.appxmanifest        # App manifest for packaging
├── app.manifest                # Application manifest
├── WinUISvgViewer.csproj       # Project file
└── Assets/                     # Application assets (icons, splash screen)
```

## Anforderungen

- **Betriebssystem**: Windows 10 (Version 1809, Build 17763) oder höher
- **SDK**: .NET 10 SDK
- **Visual Studio**: Visual Studio 2022 (Version 17.12 oder höher) mit "Windows application development" Workload

## Build-Anleitung

### Auf Windows:

1. Öffnen Sie die Lösung in Visual Studio 2022:
   ```
   WinUISvgViewer.sln
   ```

2. Stellen Sie sicher, dass die Platform auf `x64` eingestellt ist

3. Erstellen Sie die Lösung:
   - In Visual Studio: Build → Build Solution (Strg+Shift+B)
   - Oder per Command Line:
     ```cmd
     dotnet build WinUISvgViewer.sln -c Release
     ```

4. Führen Sie die Applikation aus:
   - In Visual Studio: Debug → Start Without Debugging (Strg+F5)
   - Oder per Command Line:
     ```cmd
     dotnet run --project WinUISvgViewer\WinUISvgViewer.csproj
     ```

### Hinweis für Nicht-Windows-Systeme:

WinUI 3 Applikationen können nur auf Windows-Systemen gebaut und ausgeführt werden. Der Code in diesem Repository ist vollständig und lauffähig, benötigt jedoch ein Windows-System für die Kompilierung.

## Verwendung

1. **Starten Sie die Applikation**
2. **Klicken Sie auf "Select Folder"** um einen Ordner mit SVG-Dateien auszuwählen
3. **Wählen Sie eine SVG-Datei** aus der Liste auf der linken Seite
4. **Die SVG wird automatisch angezeigt** im Hauptbereich rechts
5. **Navigieren Sie zwischen SVGs** mit den "Previous" und "Next" Buttons

## Code-Übersicht

### MainWindow.xaml
- **Grid-Layout** mit 3 Zeilen und 2 Spalten
- **Top Bar**: Ordnerauswahl-Button und Pfadanzeige
- **Left Panel**: ListBox mit SVG-Dateiliste
- **Right Panel**: SKXamlCanvas für SVG-Rendering
- **Bottom Bar**: Navigation Buttons

### MainWindow.xaml.cs
- **SelectFolderButton_Click**: Öffnet FolderPicker und lädt SVG-Dateien
- **LoadSvgFilesFromFolder**: Scannt Ordner nach SVG-Dateien
- **SvgFilesList_SelectionChanged**: Behandelt Dateiauswahl
- **LoadAndDisplaySvg**: Lädt SVG mit Svg.Skia
- **SkiaCanvas_PaintSurface**: Rendert SVG mit automatischer Skalierung und Zentrierung
- **PreviousButton_Click / NextButton_Click**: Navigation zwischen Dateien
- **UpdateNavigationButtons**: Aktiviert/Deaktiviert Navigation-Buttons

## Abhängigkeiten

Die folgenden NuGet-Pakete werden verwendet:

```xml
<PackageReference Include="Microsoft.Windows.SDK.BuildTools" Version="10.0.26100.1742" />
<PackageReference Include="Microsoft.WindowsAppSDK" Version="1.6.250205002" />
<PackageReference Include="SkiaSharp" Version="3.119.1" />
<PackageReference Include="SkiaSharp.Views.WinUI" Version="3.119.1" />
<PackageReference Include="Svg.Skia" Version="3.2.1" />
```

## Lizenz

Dieses Projekt dient als Beispielimplementierung für Lernzwecke.

## Beispiel-SVGs zum Testen

Sie können SVG-Dateien von folgenden Quellen zum Testen herunterladen:
- [SVG Repo](https://www.svgrepo.com/) - Free SVG icons
- [Heroicons](https://heroicons.com/) - Beautiful hand-crafted SVG icons
- Eigene SVG-Dateien erstellen mit Tools wie Inkscape oder Adobe Illustrator
