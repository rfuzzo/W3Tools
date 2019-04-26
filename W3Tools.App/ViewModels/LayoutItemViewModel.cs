using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using W3Tools.App.Commands;

namespace W3Tools.App.ViewModels
{
    public abstract class LayoutItemViewModel : ViewModel, ILayoutItemViewModel
    {
        #region Properties

        #region Title
        private string _title;
        public virtual string Title
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
        #endregion

        #region ContentId
        private string _contentId;
        public virtual string ContentId
        {
            get
            {
                return _contentId;
            }
            set
            {
                if(_contentId != value)
                {
                    _contentId = value;
                    InvokePropertyChanged();
                }
            }
        }
        #endregion

        #region IsSelected
        private bool _isSelected;
        public virtual bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if(_isSelected != value)
                {
                    _isSelected = value;
                    InvokePropertyChanged();
                }
            }
        }
        #endregion

        #region IsActive
        private bool _isActive;
        public virtual bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                if(_isActive != value)
                {
                    _isActive = value;
                    InvokePropertyChanged();
                }
            }
        }
        #endregion

        #region IconSource
        private Uri _iconSource;
        public virtual Uri IconSource
        {
            get
            {
                return _iconSource;
            }
            set
            {
                if(_iconSource != value)
                {
                    _iconSource = value;
                    InvokePropertyChanged();
                }
            }
        }
        #endregion

        #region ToolTip
        private string _toolTip;
        public virtual string ToolTip
        {
            get
            {
                return _toolTip;
            }
            set
            {
                if(_toolTip != value)
                {
                    _toolTip = value;
                    InvokePropertyChanged();
                }
            }
        }
        #endregion

        #region Host
        private ILayoutHostViewModel _parent;
        public ILayoutHostViewModel Host
        {
            get
            {
                return _parent;
            }
            set
            {
                if(_parent != value)
                {
                    _parent = value;
                    InvokePropertyChanged();
                }
            }
        }
        #endregion

        #endregion

        #region Commands
        public ICommand CloseCommand { get; }
        #endregion

        #region Contructors

        public LayoutItemViewModel()
        {
            CloseCommand = new RelayCommand(Close, CanClose);
        }

        #endregion

        protected virtual bool CanClose()
        {
            return true;
        }

        protected virtual void Close()
        {

        }

        #region Static Methods
        public static Uri GetIconUri(string fileName)
        {
            var path = Path.Combine(@"/W3Tools.UI;component/Resources/Icons", fileName);
            if(Uri.TryCreate(path, UriKind.Relative, out var uri))
            {
                return uri;
            }
            return null;
        }
        #endregion

    }
}
