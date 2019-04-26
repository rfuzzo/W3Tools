using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace W3Tools.UI.Controls
{
    /// <summary>
    /// A simple search box control.
    /// </summary>
    public class SearchBox : Control
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SearchBox), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register("SearchCommand", typeof(ICommand), typeof(SearchBox), new PropertyMetadata(null));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        static SearchBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchBox), new FrameworkPropertyMetadata(typeof(SearchBox)));
        }
    }
}
