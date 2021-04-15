using System.Collections.ObjectModel;

namespace DraggableTreeView
{
    public interface IDraggableGroup : IDraggable
    {
        ObservableCollection<IDraggable> Children { get; set; }
    }
}