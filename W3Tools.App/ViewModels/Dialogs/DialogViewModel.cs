using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3Tools.App.ViewModels.Dialogs
{
    /// <summary>
    /// Represents a viewmodel used for custom dialogs.
    /// </summary>
    public abstract class DialogViewModel : ViewModel, IDialogViewModel
    {
        public event EventHandler<DialogCloseRequestEventArgs> CloseRequest;

        private bool _isClosed;
        public bool IsClosed
        {
            get
            {
                return _isClosed;
            }
            set
            {
                if(_isClosed != value)
                {
                    _isClosed = value;
                    InvokePropertyChanged();
                }
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if(_title != value)
                {
                    _title = value;
                    InvokePropertyChanged();
                }
            }
        }

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if(_message != value)
                {
                    _message = value;
                    InvokePropertyChanged();
                }
            }
        }

        public IViewModel Owner { get; set; }

        public DialogViewModel()
        {
            // Default title
            Title = "W3Tools";
            IsClosed = false;
        }

        protected virtual void InvokeDialogCloseRequest(bool? dialogResult)
        {
            var closerequest = CloseRequest;
            closerequest.Invoke(this, new DialogCloseRequestEventArgs(dialogResult));
            IsClosed = true;
        }

        protected virtual void InvokeDialogCloseRequest(DialogCloseRequestEventArgs args)
        {
            var closerequest = CloseRequest;
            closerequest.Invoke(this, args);
            IsClosed = true;
        }
    }
}
