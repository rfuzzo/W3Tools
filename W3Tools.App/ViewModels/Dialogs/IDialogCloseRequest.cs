using System;

namespace W3Tools.App.ViewModels.Dialogs
{
    public interface IDialogCloseRequest
    {
        bool IsClosed { get; }
        event EventHandler<DialogCloseRequestEventArgs> CloseRequest;
    }
}
