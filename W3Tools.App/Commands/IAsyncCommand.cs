using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace W3Tools.App.Commands
{
    /// <summary>
    /// Defines an asynchronous command.
    /// </summary>
    public interface IAsyncCommand : ICommand
    {
        IAsyncResult BeginExecute(object parameter);
        void EndExecute(IAsyncResult result);
    }
}
