# Build Guide for WinUI 3 SVG Viewer

## Detaillierte Build-Anleitung für Windows

### Voraussetzungen

#### 1. Visual Studio 2022 installieren

Laden Sie Visual Studio 2022 (Version 17.12 oder höher) herunter und installieren Sie folgende Workloads:

- ✅ **.NET Desktop Development**
- ✅ **Windows application development** (enthält Windows App SDK)

#### 2. .NET 10 SDK installieren

Falls noch nicht installiert:
- Download von: https://dotnet.microsoft.com/download/dotnet/10.0
- Oder über Visual Studio Installer

#### 3. Windows App SDK

Die Version 1.6 wird automatisch über NuGet wiederhergestellt.

### Build-Schritte

#### Option 1: Visual Studio 2022

1. **Öffnen Sie die Solution**
   ```
   WinUISvgViewer.sln
   ```
   Doppelklick auf die Datei oder in Visual Studio: File → Open → Project/Solution

2. **Platform-Konfiguration**
   - Stellen Sie die Platform auf `x64` ein (Dropdown in der Toolbar)
   - Configuration: `Debug` für Entwicklung, `Release` für Produktion

3. **NuGet-Pakete wiederherstellen**
   - Visual Studio macht dies automatisch beim ersten Build
   - Manuell: Tools → NuGet Package Manager → Manage NuGet Packages for Solution → Restore

4. **Build durchführen**
   - Menü: Build → Build Solution (Strg+Shift+B)
   - Oder: Build → Rebuild Solution für einen sauberen Build

5. **Applikation ausführen**
   - Debug → Start Without Debugging (Strg+F5)
   - Oder: Debug → Start Debugging (F5)

#### Option 2: Command Line (Developer Command Prompt)

1. **Öffnen Sie Developer Command Prompt for VS 2022**

2. **Navigieren Sie zum Projektverzeichnis**
   ```cmd
   cd C:\path\to\winui-skia
   ```

3. **NuGet-Pakete wiederherstellen**
   ```cmd
   dotnet restore WinUISvgViewer.sln
   ```

4. **Build durchführen**
   ```cmd
   dotnet build WinUISvgViewer.sln -c Release
   ```

5. **Applikation ausführen**
   ```cmd
   dotnet run --project WinUISvgViewer\WinUISvgViewer.csproj
   ```

### Troubleshooting

#### Problem: "NETSDK1100: To build a project targeting Windows..."

**Lösung**: Stellen Sie sicher, dass Sie auf einem Windows-System arbeiten. WinUI 3 kann nur unter Windows gebaut werden.

#### Problem: "The Windows App SDK package was not detected."

**Lösung**: 
1. Löschen Sie die `bin` und `obj` Ordner
2. Führen Sie `dotnet restore` erneut aus
3. Starten Sie Visual Studio neu

#### Problem: "XAML compilation failed"

**Lösung**:
1. Stellen Sie sicher, dass die Windows App SDK Workload in Visual Studio installiert ist
2. Überprüfen Sie, ob .NET 10 SDK installiert ist
3. Führen Sie `dotnet clean` und dann `dotnet build` aus

#### Problem: "Could not load file or assembly 'SkiaSharp'"

**Lösung**:
1. Stellen Sie sicher, dass alle NuGet-Pakete wiederhergestellt wurden
2. Überprüfen Sie die Internet-Verbindung
3. Löschen Sie den NuGet-Cache: `dotnet nuget locals all --clear`
4. Führen Sie `dotnet restore` erneut aus

### Deployment

#### Unpackaged Deployment (Entwicklung)

Die Applikation läuft direkt aus dem `bin` Ordner:
```
WinUISvgViewer\bin\x64\Release\net10.0-windows10.0.19041.0\WinUISvgViewer.exe
```

#### MSIX Packaged Deployment (Produktion)

Für die Verteilung als MSIX-Paket:

1. In Visual Studio: Project → Publish → Create App Packages
2. Folgen Sie dem Wizard
3. Das MSIX-Paket kann dann im Microsoft Store oder als Sideload-Paket verteilt werden

### Performance-Optimierungen

Für optimale Performance im Release-Build:

1. **AOT (Ahead-of-Time) Compilation** aktivieren (optional):
   ```xml
   <PublishAot>true</PublishAot>
   ```

2. **Trimming** aktivieren (optional):
   ```xml
   <PublishTrimmed>true</PublishTrimmed>
   ```

**Hinweis**: Diese Optimierungen können die Build-Zeit erhöhen und sollten nur für finale Release-Builds verwendet werden.

### System-Anforderungen für die Ausführung

- **OS**: Windows 10 (Version 1809, Build 17763) oder höher
- **RAM**: Mindestens 2 GB (4 GB empfohlen)
- **Festplatte**: 100 MB freier Speicherplatz
- **Display**: Mindestens 1024x768 Auflösung

### Nächste Schritte

Nach erfolgreichem Build:

1. Kopieren Sie einige SVG-Dateien in den `SampleSVGs` Ordner (oder verwenden Sie die bereitgestellten Beispiele)
2. Starten Sie die Applikation
3. Klicken Sie auf "Select Folder" und wählen Sie den `SampleSVGs` Ordner
4. Wählen Sie eine SVG-Datei aus der Liste
5. Die SVG wird automatisch gerendert

## Support

Bei Problemen:
1. Überprüfen Sie die Voraussetzungen
2. Konsultieren Sie die Troubleshooting-Sektion
3. Erstellen Sie ein Issue im GitHub Repository
