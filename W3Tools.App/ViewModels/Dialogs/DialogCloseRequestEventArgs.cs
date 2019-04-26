using System;

namespace W3Tools.App.ViewModels.Dialogs
{
    public class DialogCloseRequestEventArgs : EventArgs
    {
        public bool? DialogResult { get; }

        public DialogCloseRequestEventArgs(bool? result)
        {
            this.DialogResult = result;
        }
    }
}
