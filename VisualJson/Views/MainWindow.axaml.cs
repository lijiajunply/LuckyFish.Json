using Avalonia.Controls;
using AvaloniaEdit;
using AvaloniaEdit.TextMate;
using AvaloniaEdit.TextMate.Grammars;

namespace VisualJson.Views;

public partial class MainWindow : Window
{
    private TextMate.Installation TextMateInstallation { get; set; }
    private RegistryOptions RegistryOptions { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        var _editor = this.Find<TextEditor>("Editor");
        RegistryOptions = new RegistryOptions(ThemeName.Light);
        TextMateInstallation = _editor.InstallTextMate(RegistryOptions);
        TextMateInstallation.
            SetGrammar(RegistryOptions.GetScopeByLanguageId(RegistryOptions.GetLanguageByExtension(".json").Id));
    }

    
}