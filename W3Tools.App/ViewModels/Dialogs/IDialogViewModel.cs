namespace W3Tools.App.ViewModels.Dialogs
{
    public interface IDialogViewModel : IViewModel, IDialogCloseRequest
    {
        string Title { get; set; }
        string Message { get; set; }
        IViewModel Owner { get; set; }
    }
}
