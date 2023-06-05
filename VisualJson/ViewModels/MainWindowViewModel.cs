using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Avalonia.Controls;
using AvaloniaEdit.Document;
using LuckyFish.Json;
using VisualJson.Models;

namespace VisualJson.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    
    #region Pror

    private JsonModel? _jsonModel;

    public JsonModel? JsonModel
    {
        get => _jsonModel;
        set
        {
            SetField(ref _jsonModel, value);
            if (value == null || value.IsHasChildren) return;
            Context = value.Value?.GetValue()?.ToString();
        }
    }

    private string? _context;

    public string? Context
    {
        get => _context;
        set => SetField(ref _context, value);
    }

    public ObservableCollection<JsonModel> JsonObjects { get; set; } = new();

    private TextDocument? _jsonContext = new();

    public TextDocument? JsonContext
    {
        get => _jsonContext;
        set
        {
            SetField(ref _jsonContext, value);
            if (value == null) return;
            JsonObjects.Clear();
            JsonObjects.Add(new JsonModel(Json.DeSerialization(value.Text)));
        }
    }

    #endregion

    #region Function

    public async void OpenJsonFile()
    {
        var dialog = new OpenFileDialog
        {
            Filters = new List<FileDialogFilter>()
            {
                new()
                {
                    Name = "Json File(.json)",
                    Extensions = new List<string>()
                    {
                        "json"
                    }
                },
                new()
                {
                    Name = "All File(.)"
                }
            }
        };
        var result = await dialog.ShowAsync(new Window());
        if (result == null) return;
        JsonContext = new TextDocument(await File.ReadAllTextAsync(result[0])) 
            { FileName = result[0] };
    }

    public void UpdateTree(JsonModel model)
    {
        JsonObjects.Clear();
        JsonObjects.Add(model);
    }
    
    #endregion
    
}