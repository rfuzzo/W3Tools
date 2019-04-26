using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3Tools.App.ViewModels
{
    /// <summary>
    /// Represents a viewmodel that is a host for documents and tools.
    /// This viewmodel is designed to be used with avalondock's dockingmanager.
    /// </summary>
    public abstract class LayoutHostViewModel : ViewModel, ILayoutHostViewModel
    {
        #region DocumentsSource
        private ICollection<IDocumentViewModel> _documentsSource;
        /// <summary>
        /// Holds all the currently open documents in the project.
        /// </summary>
        public ICollection<IDocumentViewModel> DocumentsSource
        {
            get
            {
                return _documentsSource;
            }
            private set
            {
                if(value is null)
                {
                    return;
                }
                if(_documentsSource != value)
                {
                    _documentsSource = value;
                    InvokePropertyChanged();
                }
            }
        }
        #endregion

        #region AnchorablesSource
        private ICollection<IToolViewModel> _anchorablesSource;
        /// <summary>
        /// Holds the anchorable panes for controls.
        /// </summary>
        public ICollection<IToolViewModel> AnchorablesSource
        {
            get
            {
                return _anchorablesSource;
            }
            private set
            {
                if(value is null)
                {
                    return;
                }
                if(_anchorablesSource != value)
                {
                    _anchorablesSource = value;
                    InvokePropertyChanged();
                }
            }
        }
        #endregion

        #region ActiveContent
        private ILayoutItemViewModel _activeContent;
        /// <summary>
        /// Holds the currently active content in the window.
        /// </summary>
        public virtual ILayoutItemViewModel ActiveContent
        {
            get
            {
                return _activeContent;
            }
            set
            {
                if(_activeContent != value)
                {
                    _activeContent = value;
                    InvokePropertyChanged();
                }
            }
        }
        #endregion

        #region Contructors

        public LayoutHostViewModel()
        {
            DocumentsSource = new ObservableCollection<IDocumentViewModel>();
            AnchorablesSource = new ObservableCollection<IToolViewModel>();
        }

        #endregion

        #region AddLayoutItems

        /// <summary>
        /// Add a layout item to this instance.
        /// </summary>
        /// <param name="item">The item to dock.</param>
        /// <param name="setAsActive">Set the item as the currenly active content.</param>
        public void AddLayoutItem(ILayoutItemViewModel item, bool setAsActive)
        {
            switch(item)
            {
                case IToolViewModel tool:
                    AnchorablesSource.Add(tool);
                    break;

                case IDocumentViewModel document:
                    DocumentsSource.Add(document);
                    break;

                default:
                    return;
            }
            if(setAsActive)
            {
                ActiveContent = item;
            }
        }

        #endregion

        #region RemoveLayoutItem

        /// <summary>
        /// Remove a layout item from this instance.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>True if the item was sucsessfully remove, else false.</returns>
        public bool RemoveLayoutItem(ILayoutItemViewModel item)
        {
            bool sucsess;
            switch(item)
            {
                case IToolViewModel tool:
                    sucsess = AnchorablesSource.Remove(tool);
                    break;

                case IDocumentViewModel document:
                    sucsess = DocumentsSource.Remove(document);
                    break;

                default:
                    sucsess = false;
                    break;
            }
            if(item == ActiveContent && sucsess)
            {
                ILayoutItemViewModel newActive = DocumentsSource.FirstOrDefault();
                if(newActive is null)
                {
                    newActive = AnchorablesSource.FirstOrDefault();
                }
                ActiveContent = newActive;
            }
            return sucsess;
        }

        #endregion
    }
}
