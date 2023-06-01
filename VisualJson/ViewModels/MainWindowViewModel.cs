using AvaloniaEdit.Document;

namespace VisualJson.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private TextDocument? _jsonContext;
    public TextDocument? JsonContext
    {
        get => _jsonContext;
        set => SetField(ref _jsonContext, value);
    }
}