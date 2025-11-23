# Quick Start Guide

## Schnellstart (Quick Start)

### Voraussetzungen
- Windows 10/11 (Build 17763+)
- Visual Studio 2022 mit Windows App Development Workload
- .NET 10 SDK

### In 5 Schritten zur laufenden App

1. **Repository klonen oder herunterladen**
   ```cmd
   git clone https://github.com/trash-box/winui-skia.git
   cd winui-skia
   ```

2. **Solution in Visual Studio öffnen**
   ```
   Doppelklick auf: WinUISvgViewer.sln
   ```

3. **Platform auf x64 setzen**
   - In Visual Studio Toolbar: Platform-Dropdown → x64 auswählen

4. **Build und Run**
   - Drücken Sie F5 (oder Strg+F5 für Start ohne Debugging)
   - Beim ersten Mal werden NuGet-Pakete automatisch wiederhergestellt

5. **SVGs anzeigen**
   - Klicken Sie "Select Folder"
   - Wählen Sie den `SampleSVGs` Ordner im Projekt
   - Klicken Sie auf eine SVG-Datei in der Liste
   - Die SVG wird angezeigt!

### Tastenkombinationen in Visual Studio

| Aktion | Tastenkombination |
|--------|-------------------|
| Build Solution | Strg+Shift+B |
| Start Debugging | F5 |
| Start ohne Debug | Strg+F5 |
| Stop Debugging | Shift+F5 |
| Clean Solution | - |
| Rebuild Solution | - |

### UI-Bedienung

```
┌─────────────────────────────────────────┐
│ 1. Klick hier → [Select Folder]        │
├──────────────┬──────────────────────────┤
│ 2. Klick auf │                          │
│    SVG-Datei │    3. SVG wird hier      │
│    in Liste  │       angezeigt          │
│              │                          │
│  • file1.svg │                          │
│  • file2.svg │                          │
│  • file3.svg │                          │
├──────────────┴──────────────────────────┤
│  4. Navigation: [← Prev]  [Next →]     │
└─────────────────────────────────────────┘
```

### Beispiel-Workflow

1. **Starten Sie die App**
2. **"Select Folder" klicken**
3. **Navigieren Sie zu einem Ordner mit SVG-Dateien**
   - Z.B. den `SampleSVGs` Ordner im Projekt
   - Oder einen beliebigen eigenen Ordner mit SVGs
4. **Wählen Sie eine Datei aus der Liste**
5. **Die SVG wird automatisch gerendert**
6. **Navigieren Sie mit Previous/Next zwischen Dateien**

### Problemlösung (Quick Fixes)

#### "NETSDK1100: To build a project targeting Windows..."
→ Sie sind nicht auf Windows. WinUI 3 benötigt Windows.

#### "Package restore failed"
→ Überprüfen Sie Ihre Internetverbindung und versuchen Sie:
```cmd
dotnet restore WinUISvgViewer.sln
```

#### "XAML compilation failed"
→ Stellen Sie sicher, dass die Windows App SDK Workload installiert ist

#### App startet nicht
→ Überprüfen Sie:
- Platform ist auf x64 gesetzt
- .NET 10 SDK ist installiert
- Windows 10 Build 17763 oder höher

### Eigene SVG-Dateien verwenden

1. Erstellen Sie einen Ordner auf Ihrem Computer
2. Kopieren Sie SVG-Dateien in den Ordner
3. In der App: "Select Folder" → Ihren Ordner auswählen
4. Fertig!

### SVG-Quellen zum Testen

- **SVG Repo**: https://www.svgrepo.com/
- **Heroicons**: https://heroicons.com/
- **Feather Icons**: https://feathericons.com/
- **Font Awesome**: https://fontawesome.com/
- **Inkscape**: Erstellen Sie eigene SVGs

### Was wird unterstützt?

✅ Grundformen (Rechtecke, Kreise, Pfade)
✅ Farben und Farbverläufe
✅ Transformationen (Rotation, Skalierung)
✅ Text
✅ Gruppierung
✅ Transparenz
✅ Clipping und Masking

❌ Animationen (SMIL)
❌ JavaScript
❌ Externe Ressourcen (URLs)

### Performance-Tipps

- Kleine bis mittelgroße SVGs (< 1MB) funktionieren am besten
- Sehr komplexe SVGs können langsamer rendern
- Der erste Load eines Ordners kann einen Moment dauern

### Nächste Schritte

📖 Lesen Sie die ausführliche Dokumentation:
- `README.md` - Überblick
- `BUILD_GUIDE.md` - Detaillierte Build-Anleitung
- `FEATURES.md` - Feature-Beschreibungen
- `ARCHITECTURE.md` - Technische Details

🔧 Erweitern Sie die App:
- Fügen Sie Zoom-Funktionalität hinzu
- Implementieren Sie Export zu PNG
- Fügen Sie Drag & Drop hinzu

💡 Experimentieren Sie:
- Ändern Sie Farben im XAML
- Fügen Sie weitere UI-Elemente hinzu
- Implementieren Sie eigene Features

### Support

Bei Problemen:
1. Überprüfen Sie die Troubleshooting-Sektion in `BUILD_GUIDE.md`
2. Überprüfen Sie die Known Limitations in `CHANGELOG.md`
3. Erstellen Sie ein Issue auf GitHub

---

**Happy SVG Viewing! 🎨**
