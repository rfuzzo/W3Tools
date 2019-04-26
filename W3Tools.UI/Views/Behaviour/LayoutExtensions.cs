using System.Collections.Generic;
using System.Linq;
using Xceed.Wpf.AvalonDock.Layout;

namespace W3Tools.UI.Views.Behaviour
{
    public static class LayoutExtensions
    {
        public static bool IsContent<T>(this LayoutContent content)
        {
            return content.Content is T;
        }

        public static bool IsContent<T1, T2>(this LayoutContent content)
        {
            return content.Content is T1
                || content.Content is T2;
        }

        public static bool IsContent<T1, T2, T3>(this LayoutContent content)
        {
            return content.Content is T1
                || content.Content is T2
                || content.Content is T3;
        }


        public static LayoutAnchorablePane GetAnchorabePaneByName(this LayoutRoot root, string name)
        {
            var panes = root.Descendents().OfType<LayoutAnchorablePane>();
            return panes.FirstOrDefault(p => p.Name == name);
        }

        public static void AddChild<T>(this LayoutGroup<T> group, ILayoutElement element) where T : class, ILayoutElement
        {
            var count = group.Children.Count;
            group.InsertChildAt(count, element);
        }

        public static LayoutAnchorGroup FirstOrAdd(this LayoutAnchorSide side)
        {
            var group = side.Children.FirstOrDefault<LayoutAnchorGroup>();
            if(group is null)
            {
                group = new LayoutAnchorGroup();
                side.AddChild(group);
            }
            return group;
        }

        public static LayoutAnchorGroup AddGroup(this LayoutAnchorSide side)
        {
            var group = new LayoutAnchorGroup();
            side.AddChild(group);
            return group;
        }

        public static IEnumerable<T> Descendents<T>(this ILayoutElement element) where T : class, ILayoutElement
        {
            if(element is ILayoutContainer container)
            {
                foreach(var childElement in container.Children)
                {
                    if(childElement is T value)
                    {
                        yield return value;
                    }
                    foreach(var childChildElement in childElement.Descendents<T>())
                    {
                        yield return childChildElement;
                    }
                }
            }
        }

        public static T FirstDescendent<T>(this ILayoutElement element) where T : class, ILayoutElement
        {
            return element.Descendents<T>().FirstOrDefault();
        }
    }
}
