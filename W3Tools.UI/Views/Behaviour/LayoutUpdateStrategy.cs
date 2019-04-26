using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.AvalonDock.Layout;
using W3Tools.App.ViewModels.Documents;
using W3Tools.App.ViewModels.Tools;
using W3Tools.App.ViewModels;

namespace W3Tools.UI.Views.Behaviour
{
    /// <summary>
    /// Main strategy for avalon dock for positioning elements to the docking manager.
    /// </summary>
    public class LayoutUpdateStrategy : DependencyObject, ILayoutUpdateStrategy
    {
        #region Anchorables
        public void AfterInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableShown)
        {

        }
        public bool BeforeInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableToShow, ILayoutContainer destinationContainer)
        {
            // TODO:
            // A system needs to be put in place that can take an IToolViewModel and place it in the right
            // position based on the property 'PreferedPosition', which contains all the relevent information.
            // If the anchorable is not an IToolViewModel, (which should not happen) let avalondock place it in the default position.

            // var tool = anchorableToShow as IToolViewModel;
            // if(tool is null)
            // {
            //     return false;
            // }
            // var position = tool.PreferedPosition;


            var sub = layout.GetAnchorabePaneByName("bottomPane");
            if(sub != null && anchorableToShow.IsContent<LoggerViewModel, ErrorListViewModel>())
            {
                sub.AddChild(anchorableToShow);
                return true;
            }

            if(destinationContainer is LayoutAnchorablePane pane)
            {
                pane.AddChild(anchorableToShow);
                return true;
            }

            return false;
        }
        #endregion

        #region Documents
        public bool BeforeInsertDocument(LayoutRoot layout, LayoutDocument anchorableToShow, ILayoutContainer destinationContainer)
        {
            if(destinationContainer is LayoutDocumentPane pane)
            {
                pane.AddChild(anchorableToShow);
                return true;
            }
            return false;
        }
        public void AfterInsertDocument(LayoutRoot layout, LayoutDocument anchorableShown)
        {

        }
        #endregion
    }
}
