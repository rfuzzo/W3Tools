using Ninject;
using Ninject.Activation;
using Ninject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using W3Tools.UI.Views;

namespace W3Tools.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IHaveKernel
    {
        public IKernel Kernel { get; }

        public App()
        {
            Kernel = new StandardKernel();
            Kernel.Load<DefaultModule>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = Kernel.Get<MainView>();
            MainWindow.Show();
        }
    }

    public class WindowProvider : Provider<Window>
    {
        private Application _app;

        public WindowProvider(Application app)
        {
            _app = app;
        }

        protected override Window CreateInstance(IContext context)
        {
            return _app.MainWindow;
        }
    }
}
