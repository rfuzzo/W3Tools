using System.Windows.Input;

namespace W3Tools.App.ViewModels
{
    /// <summary>
    /// Represents a viewmodel modeling a document.
    /// </summary>
    public interface IDocumentViewModel : ILayoutItemViewModel
    {
        string FilePath { get; set; }
        bool HasUnsavedChanges { get; }

        ICommand SaveCommand { get; }
        ICommand SaveAsCommand { get; }
    }
}
