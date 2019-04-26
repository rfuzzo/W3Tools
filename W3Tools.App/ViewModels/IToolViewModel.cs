using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3Tools.App.ViewModels
{
    /// <summary>
    /// Indicates the postition the tool should take in the view.
    /// </summary>
    [Flags]
    public enum ToolPosition
    {
        /// <summary>
        /// The tool has no defined position.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Place the tool on the left of the layout.
        /// </summary>
        Left = 1,
        /// <summary>
        /// Place the tool on the right of the layout.
        /// </summary>
        Right = 2,
        /// <summary>
        /// Place the tool on the top of the layout.
        /// </summary>
        Top = 4,
        /// <summary>
        /// Place the tool on the bottom of the layout.
        /// </summary>
        Bottom = 8,

        /// <summary>
        /// Place the tool in the doauments layout.
        /// </summary>
        Document = 16,
        /// <summary>
        /// Place the tool in the side tabs.
        /// </summary>
        Side = 32,

        /// <summary>
        /// Create a new group when placing the tool.
        /// </summary>
        NewGroup = 64,
    }

    /// <summary>
    /// Represents a viewmodel modeling a tool control.
    /// </summary>
    public interface IToolViewModel : ILayoutItemViewModel
    {
        ToolPosition PreferedPosition { get; }
        double PreferedWidth { get; }
        double PreferedHeight { get; }

    }
}
