using Avalonia.Controls;
using Avalonia.Input;
using AvaloniaEdit;
using AvaloniaEdit.Editing;
using AvaloniaEdit.TextMate;
using AvaloniaEdit.TextMate.Grammars;
using LuckyFish.Json;
using VisualJson.Models;
using VisualJson.ViewModels;

namespace VisualJson.Views;

public partial class MainWindow : Window
{
    private TextMate.Installation TextMateInstallation { get; set; }
    private RegistryOptions RegistryOptions { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        var editor = this.Find<TextEditor>("Editor");
        RegistryOptions = new RegistryOptions(ThemeName.Light);
        TextMateInstallation = editor.InstallTextMate(RegistryOptions);
        editor.TextArea.TextEntered += TextEntered;
        TextMateInstallation.
            SetGrammar(RegistryOptions.GetScopeByLanguageId
                (RegistryOptions.GetLanguageByExtension(".json").Id));
    }

    private void TextEntered(object? sender, TextInputEventArgs e)
    {
        var a = sender as TextArea;
        if(a is null)return;
        var b = Json.DeSerialization(a.Document.Text);
        if(b is null)return;
        if (DataContext is MainWindowViewModel model)
        {
            model.JsonModel = new JsonModel(b);
            model.UpdateTree(model.JsonModel);
        }
    }
}