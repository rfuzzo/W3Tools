using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3Tools.App.ViewModels
{
    /// <summary>
    /// Represents a tool item for hosting in avalon dock anchorable panes.
    /// </summary>
    public abstract class ToolViewModel : LayoutItemViewModel, IToolViewModel
    {
        #region Properties

        public ToolPosition PreferedPosition { get; }
        public double PreferedWidth { get; }
        public double PreferedHeight { get; }

        #endregion

        #region Constructors
        public ToolViewModel()
        {

        }
        #endregion
    }
}
