using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3Tools.App.ViewModels
{
    using Commands;
    using Dialogs;
    using System.IO;
    using System.Windows.Input;

    public abstract class DocumentViewModel : LayoutItemViewModel, IDocumentViewModel
    {
        #region FilePath
        private string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                if(_filePath != value)
                {
                    _filePath = value;
                    InvokePropertyChanged();
                    Title = Path.GetFileName(value);
                    ToolTip = value;
                }
            }
        }
        #endregion

        #region Title
        public override string Title
        {
            get
            {
                if(HasUnsavedChanges)
                {
                    return String.Format("{0}*", base.Title);
                }
                return base.Title;
            }
            set
            {
                base.Title = value;
            }
        }
        #endregion

        #region HasUnsavedChanges
        private bool _hasUnsavedChanges;
        public bool HasUnsavedChanges
        {
            get
            {
                return _hasUnsavedChanges;
            }
            set
            {
                if(_hasUnsavedChanges != value)
                {
                    _hasUnsavedChanges = value;
                    InvokePropertyChanged();
                    InvokePropertyChanged(nameof(Title));
                }
            }
        }
        #endregion

        #region Commands
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand CopyFullPathCommand { get; }
        public ICommand CopyDepotPathCommand { get; }
        public ICommand OpenFolderCommand { get; }
        #endregion

        #region Contructors

        public DocumentViewModel()
        {
            SaveCommand = new RelayCommand(Save);
            SaveAsCommand = new RelayCommand(SaveAs);

            HasUnsavedChanges = true;
        }

        #endregion

        #region Saving
        public virtual void SaveAs()
        {
            HasUnsavedChanges = false;
        }

        public virtual void Save()
        {
            HasUnsavedChanges = false;
        }
        #endregion
    }
}
