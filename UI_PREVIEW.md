# UI Preview and Screenshots

## User Interface Layout

Da die Applikation nur auf Windows läuft, sind hier visuelle Beschreibungen der Benutzeroberfläche:

### Hauptfenster Layout

```
┌────────────────────────────────────────────────────────────────────┐
│ SVG Viewer with SkiaSharp                                    ⬜ ⊡ ✕ │
├────────────────────────────────────────────────────────────────────┤
│                                                                    │
│  [Select Folder]  No folder selected                              │
│                                                                    │
├──────────────────┬─────────────────────────────────────────────────┤
│                  │                                                 │
│  SVG Files       │  No file selected                               │
│  ──────────      │                                                 │
│                  │                                                 │
│                  │                                                 │
│  (empty)         │                                                 │
│                  │                                                 │
│                  │                                                 │
│                  │                                                 │
│                  │                                                 │
│                  │                                                 │
│                  │                                                 │
│                  │                                                 │
│                  │                                                 │
├──────────────────┴─────────────────────────────────────────────────┤
│                    [← Previous]  [Next →]                          │
│                    (disabled)    (disabled)                        │
└────────────────────────────────────────────────────────────────────┘
```

### Nach Ordnerauswahl

```
┌────────────────────────────────────────────────────────────────────┐
│ SVG Viewer with SkiaSharp                                    ⬜ ⊡ ✕ │
├────────────────────────────────────────────────────────────────────┤
│                                                                    │
│  [Select Folder]  C:\Users\...\SampleSVGs                         │
│                                                                    │
├──────────────────┬─────────────────────────────────────────────────┤
│                  │                                                 │
│  SVG Files       │  geometric_shapes.svg                           │
│  ──────────      │                                                 │
│                  │  ┌─────────────────────────────────────┐       │
│  geometric_shape │  │                                     │       │
│  gradient_exampl │  │         [SVG Rendering]             │       │
│  happy_face.svg  │  │                                     │       │
│                  │  │    ╔══╗         ╔══╗               │       │
│                  │  │    ║  ║   ●     ║  ║               │       │
│                  │  │    ╚══╝         ╚══╝               │       │
│                  │  │      ▲            ▲                │       │
│                  │  │                                     │       │
│                  │  └─────────────────────────────────────┘       │
│                  │                                                 │
├──────────────────┴─────────────────────────────────────────────────┤
│                    [← Previous]      [Next →]                      │
│                    (enabled)         (enabled)                     │
└────────────────────────────────────────────────────────────────────┘
```

### Mit Happy Face SVG

```
┌────────────────────────────────────────────────────────────────────┐
│ SVG Viewer with SkiaSharp                                    ⬜ ⊡ ✕ │
├────────────────────────────────────────────────────────────────────┤
│                                                                    │
│  [Select Folder]  C:\Users\...\SampleSVGs                         │
│                                                                    │
├──────────────────┬─────────────────────────────────────────────────┤
│                  │                                                 │
│  SVG Files       │  happy_face.svg                                 │
│  ──────────      │                                                 │
│                  │  ┌─────────────────────────────────────┐       │
│  geometric_shape │  │                                     │       │
│  gradient_exampl │  │         Happy Face                  │       │
│ ▶happy_face.svg  │  │                                     │       │
│                  │  │         ╭─────────╮                 │       │
│                  │  │        ╱  ●   ●    ╲                │       │
│                  │  │       │             │               │       │
│                  │  │       │   ╰─────╯   │               │       │
│                  │  │        ╲           ╱                │       │
│                  │  │         ╰─────────╯                 │       │
│                  │  │                                     │       │
│                  │  └─────────────────────────────────────┘       │
│                  │                                                 │
├──────────────────┴─────────────────────────────────────────────────┤
│                    [← Previous]      [Next →]                      │
│                    (enabled)         (enabled)                     │
└────────────────────────────────────────────────────────────────────┘
```

## UI-Elemente Beschreibung

### Top Bar
- **Select Folder Button**: Moderne WinUI 3 Button mit Accent Color
- **Current Folder Text**: Zeigt den vollständigen Pfad zum gewählten Ordner
- **Hintergrund**: Light gray mit subtiler Trennung

### Left Panel (250px breit)
- **Header "SVG Files"**: Bold Text, 10px Margin
- **ListBox**: 
  - Zeigt Dateinamen (ohne Pfad)
  - Hover-Effekt: Light blue Background
  - Selected: Accent color Background
  - Scrollbar: Erscheint automatisch bei vielen Dateien
  - Border: 1px solid light gray

### Right Panel (flexibel, nimmt restlichen Platz)
- **Current File Text**: 
  - Bold, zeigt aktuellen Dateinamen
  - Oder Fehlermeldung bei Load-Fehler
  - 10px Bottom Margin
- **SKXamlCanvas**:
  - White Background
  - 1px light gray Border
  - SVG wird automatisch skaliert und zentriert
  - 10% Padding für bessere Darstellung
  - Smooth Rendering mit Anti-Aliasing

### Bottom Bar
- **Navigation Buttons**:
  - "← Previous" und "Next →"
  - Zentriert im Panel
  - 10px Spacing zwischen Buttons
  - Disabled State: Grayed out und nicht klickbar
  - Enabled State: Accent color bei Hover

## Design-Eigenschaften

### Farben (Light Theme)
- **Background**: White (#FFFFFF)
- **Border**: Light Gray (#E0E0E0)
- **Text**: Black (#000000)
- **Accent**: Windows Accent Color (variiert, z.B. Blue #0078D4)
- **Hover**: Light Blue (#E5F1FB)
- **Disabled**: Gray (#A0A0A0)

### Farben (Dark Theme)
WinUI 3 unterstützt automatisch Dark Theme:
- **Background**: Dark Gray (#1E1E1E)
- **Border**: Dark Gray (#3F3F3F)
- **Text**: White (#FFFFFF)
- **Accent**: Windows Accent Color (angepasst für Dark Theme)

### Schriftarten
- **System Font**: Segoe UI (Windows Standard)
- **Header**: 14pt, Bold
- **Body**: 12pt, Regular
- **Monospace**: Consolas (für Pfadanzeige)

### Spacing
- **Padding**: 10px überall
- **Button Spacing**: 10px zwischen Elementen
- **Canvas Padding**: 10% der Canvas-Größe

### Animationen
- **Button Hover**: Smooth color transition (200ms)
- **Selection Change**: Instant (kein Fade)
- **SVG Load**: Instant rendering

## Responsive Verhalten

### Window Resize
```
Minimum:  800x600px
Optimal:  1200x800px
Maximum:  Unbegrenzt
```

- **Horizontal Resize**: Canvas wird breiter/schmaler
- **Vertical Resize**: Canvas wird höher/niedriger
- **Left Panel**: Behält feste 250px Breite
- **SVG**: Skaliert automatisch mit Canvas-Größe

### DPI Scaling
- Unterstützt Windows DPI Scaling (100%, 125%, 150%, 200%)
- Per-Monitor DPI Awareness (in app.manifest konfiguriert)
- Scharfe Darstellung auf High-DPI Displays

## Interaktions-Patterns

### Folder Selection
1. User klickt "Select Folder"
2. Windows FolderPicker Dialog öffnet sich
3. User navigiert zu Ordner und wählt aus
4. Dialog schließt sich
5. Ordnerpfad wird angezeigt
6. Dateiliste wird gefüllt
7. Erste Datei wird automatisch ausgewählt und angezeigt

### File Selection
1. User klickt auf Dateinamen in ListBox
2. Dateiname wird hervorgehoben
3. SVG wird sofort geladen und angezeigt
4. Navigation Buttons werden aktualisiert

### Navigation
1. User klickt "Next" Button
2. Nächste Datei in Liste wird ausgewählt
3. SVG wird sofort angezeigt
4. Buttons werden je nach Position aktiviert/deaktiviert

### Error Handling
1. Ungültige SVG wird ausgewählt
2. Error wird gefangen
3. Fehlermeldung wird im Current File Text angezeigt
4. Canvas zeigt weißen Hintergrund
5. Navigation funktioniert weiterhin

## Accessibility Features

- **Keyboard Navigation**: Tab zwischen Elementen
- **Screen Reader**: Alle Elemente haben ARIA Labels
- **High Contrast**: Unterstützt Windows High Contrast Mode
- **Focus Indicators**: Sichtbare Focus-Rahmen
- **Tooltips**: Für Buttons (bei Bedarf erweiterbar)

## Performance-Indikatoren

### Visuelle Feedback
- **Loading**: Sofortige Anzeige (kein Spinner nötig bei kleinen SVGs)
- **Large SVG**: Könnte kurze Verzögerung haben (< 500ms)
- **Empty Folder**: "No SVG files found" Nachricht

### Expected Performance
- **60 FPS Rendering**: Für die meisten SVGs
- **Smooth Scrolling**: Bei Dateilisten
- **Instant Selection**: Keine merkbare Verzögerung

## Testing Scenarios

### Scenario 1: First Launch
- Leeres Fenster
- "No folder selected" Text
- Disabled Navigation Buttons

### Scenario 2: Select SampleSVGs Folder
- 3 Dateien in Liste
- happy_face.svg automatisch ausgewählt
- Smiley wird angezeigt
- Alle Buttons enabled

### Scenario 3: Navigate Through Files
- Previous/Next funktioniert
- Smooth Übergang zwischen SVGs
- Buttons werden an Enden deaktiviert

### Scenario 4: Large SVG
- SVG wird automatisch skaliert
- Passt in Canvas mit Padding
- Aspect Ratio erhalten

### Scenario 5: Invalid SVG
- Error Message wird angezeigt
- App stürzt nicht ab
- Navigation funktioniert weiter

---

**Hinweis**: Diese Beschreibungen basieren auf dem implementierten XAML und Code. 
Für tatsächliche Screenshots muss die App auf einem Windows-System ausgeführt werden.
