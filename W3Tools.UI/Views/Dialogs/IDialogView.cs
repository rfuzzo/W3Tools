using System.Windows;

namespace W3Tools.UI.Views.Dialogs
{
    /// <summary>
    /// Represents a dialog view
    /// </summary>
    public interface IDialogView : IView
    {
        bool? DialogResult { get; set; }
        bool? ShowDialog();
        bool? ShowDialog(Window parent);
    }
}
