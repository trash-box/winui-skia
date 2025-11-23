using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SkiaSharp;
using SkiaSharp.Views.Windows;
using Svg.Skia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace WinUISvgViewer;

public sealed partial class MainWindow : Window
{
    private List<string> _svgFiles = new();
    private int _currentIndex = -1;
    private SKSvg? _currentSvg;

    public MainWindow()
    {
        this.InitializeComponent();
        Title = "SVG Viewer with SkiaSharp";
    }

    private async void SelectFolderButton_Click(object sender, RoutedEventArgs e)
    {
        var picker = new FolderPicker();
        
        // Get the window handle for the picker
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
        WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);
        
        picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
        picker.FileTypeFilter.Add("*");

        var folder = await picker.PickSingleFolderAsync();
        if (folder != null)
        {
            await LoadSvgFilesFromFolder(folder);
        }
    }

    private async System.Threading.Tasks.Task LoadSvgFilesFromFolder(StorageFolder folder)
    {
        CurrentFolderText.Text = folder.Path;
        
        var files = await folder.GetFilesAsync();
        _svgFiles = files
            .Where(f => f.FileType.Equals(".svg", StringComparison.OrdinalIgnoreCase))
            .Select(f => f.Path)
            .OrderBy(f => f)
            .ToList();

        SvgFilesList.Items.Clear();
        foreach (var file in _svgFiles)
        {
            SvgFilesList.Items.Add(Path.GetFileName(file));
        }

        if (_svgFiles.Count > 0)
        {
            SvgFilesList.SelectedIndex = 0;
        }
        else
        {
            CurrentFileText.Text = "No SVG files found in folder";
        }
    }

    private void SvgFilesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (SvgFilesList.SelectedIndex >= 0 && SvgFilesList.SelectedIndex < _svgFiles.Count)
        {
            _currentIndex = SvgFilesList.SelectedIndex;
            LoadAndDisplaySvg(_svgFiles[_currentIndex]);
            UpdateNavigationButtons();
        }
    }

    private void LoadAndDisplaySvg(string filePath)
    {
        try
        {
            _currentSvg = new SKSvg();
            _currentSvg.Load(filePath);
            
            CurrentFileText.Text = Path.GetFileName(filePath);
            SkiaCanvas.Invalidate();
        }
        catch (Exception ex)
        {
            CurrentFileText.Text = $"Error loading {Path.GetFileName(filePath)}: {ex.Message}";
            _currentSvg = null;
            SkiaCanvas.Invalidate();
        }
    }

    private void SkiaCanvas_PaintSurface(object? sender, SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        canvas.Clear(SKColors.White);

        if (_currentSvg?.Picture != null)
        {
            var picture = _currentSvg.Picture;
            var bounds = picture.CullRect;
            
            // Calculate scaling to fit the canvas while maintaining aspect ratio
            var canvasWidth = e.Info.Width;
            var canvasHeight = e.Info.Height;
            
            var scaleX = canvasWidth / bounds.Width;
            var scaleY = canvasHeight / bounds.Height;
            var scale = Math.Min(scaleX, scaleY) * 0.9f; // 90% to add some padding
            
            // Center the SVG
            var offsetX = (canvasWidth - bounds.Width * scale) / 2;
            var offsetY = (canvasHeight - bounds.Height * scale) / 2;
            
            canvas.Translate(offsetX, offsetY);
            canvas.Scale(scale);
            canvas.DrawPicture(picture);
        }
    }

    private void PreviousButton_Click(object sender, RoutedEventArgs e)
    {
        if (_currentIndex > 0)
        {
            SvgFilesList.SelectedIndex = _currentIndex - 1;
        }
    }

    private void NextButton_Click(object sender, RoutedEventArgs e)
    {
        if (_currentIndex < _svgFiles.Count - 1)
        {
            SvgFilesList.SelectedIndex = _currentIndex + 1;
        }
    }

    private void UpdateNavigationButtons()
    {
        PreviousButton.IsEnabled = _currentIndex > 0;
        NextButton.IsEnabled = _currentIndex < _svgFiles.Count - 1;
    }
}
