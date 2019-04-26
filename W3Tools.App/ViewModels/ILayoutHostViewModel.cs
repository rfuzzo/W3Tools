using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3Tools.App.ViewModels
{
    /// <summary>
    /// Represent view model that can hold child viewmodels. For use with avalondock dockingmanager.
    /// </summary>
    public interface ILayoutHostViewModel : IViewModel
    {
        ICollection<IToolViewModel> AnchorablesSource { get; }
        ICollection<IDocumentViewModel> DocumentsSource { get; }
        ILayoutItemViewModel ActiveContent { get; set; }

        void AddLayoutItem(ILayoutItemViewModel item, bool setAsActive);
        bool RemoveLayoutItem(ILayoutItemViewModel item);
    }
}
