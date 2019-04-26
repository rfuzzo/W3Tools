using System;
using System.Windows;
using Microsoft.Win32;
using Ninject;
using W3Tools.App.Services;
using W3Tools.App.ViewModels.Dialogs;

namespace W3Tools.UI.Services
{
    using Views.Dialogs;

    /// <summary>
    /// The UI implementation of the dialog service.
    /// This will display dialog windows to the user.
    /// </summary>
    public class ViewDialogService : IDialogService
    {
        /// <summary>
        /// The window owner of the dialog service.
        /// </summary>
        public Window Owner { get; }

        /// <summary>
        /// Initialise a new instance of the ViewDialogService.
        /// </summary>
        /// <param name="owner">The parent window that all dialog views will be the child of.</param>
        public ViewDialogService(Window owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner), "The dialog service owner window cannot be null.");
        }

        [Inject]
        public ViewDialogService()
        {
            Owner = Application.Current.MainWindow;
        }

        /// <summary>
        /// Display a custom modal dialog box to the user.
        /// </summary>
        /// <param name="viewModel">The viewmodel for the dialog.</param>
        /// <returns></returns>
        public bool? ShowDialog(IDialogViewModel viewModel)
        {
            var view = new DialogView(viewModel);
            var dResult = view.ShowDialog(Owner);
            return dResult;
        }

        /// <summary>
        /// Resolve and instance of a dialog view model.
        /// </summary>
        /// <typeparam name="T">The type of IDialogViewModel to resolve.</typeparam>
        /// <returns>A dialog viewmodel instance.</returns>
        public T GetDialog<T>() where T : IDialogViewModel
        {
            throw new NotImplementedException();
        }

        #region Win32
        private T CreateWin32Dialog<T>(IDialogViewModel viewModel) where T : CommonDialog, new()
        {
            return new T();
        }
        #endregion
    }
}