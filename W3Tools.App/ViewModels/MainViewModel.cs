using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace W3Tools.App.ViewModels
{
    using Services;
    using Tools;
    using Documents;
    using Commands;

    public class MainViewModel : LayoutHostViewModel
    {
        #region Services

        ILoggerService LoggerService { get; }
        IConfigService ConfigService { get; }
        IDialogService DialogService { get; }

        #endregion

        public ICommand SearchCommand { get; }

        public MainViewModel(
            IConfigService config, 
            ILoggerService logger, 
            IDialogService dialog)
        {
            LoggerService = logger;
            ConfigService = config;
            DialogService = dialog;

            SearchCommand = new DelegateCommand<string>(Search);

            AddLayoutItem(new WorkflowFileViewModel()   { Title = "Workflow 1", },  false);

            AddLayoutItem(new CommandToolboxViewModel() { Title = "Toolbox", },     false);
            AddLayoutItem(new ErrorListViewModel()      { Title = "Errors" },       false);
            AddLayoutItem(new LoggerViewModel()         { Title = "Logger" },       false);
            AddLayoutItem(new PropertiesViewModel()     { Title = "Properties" },   false);
        }

        private void Search(string searchText)
        {
            Console.WriteLine("Search: {0}", searchText);
        }
    }
}
