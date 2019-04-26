using System;
using System.Windows.Input;

namespace W3Tools.App.ViewModels
{
    /// <summary>
    /// Defines a viewmodel that can be represented as a layout item in avalondock.
    /// </summary>
    public interface ILayoutItemViewModel : IViewModel
    {
        string Title { get; }
        string ToolTip { get; }
        ICommand CloseCommand { get; }
        Uri IconSource { get; }
        string ContentId { get; set; }
        bool IsActive { get; set; }
        bool IsSelected { get; set; }
        ILayoutHostViewModel Host { get; set; }
    }
}
