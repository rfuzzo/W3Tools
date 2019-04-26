using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3Tools.App.Services;
using W3Tools.App.ViewModels;
using W3Tools.UI.Services;
using W3Tools.UI.Views;

namespace W3Tools.UI
{
    public class DefaultModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IViewModel>().To<MainViewModel>().WhenInjectedInto<MainView>();

            Bind<ILoggerService>().To<DefaultLoggerService>().InSingletonScope();
            Bind<IConfigService>().To<DefaultConfigService>().InSingletonScope();
            Bind<IDialogService>().To<ViewDialogService>();
        }
    }
}
