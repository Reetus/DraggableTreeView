using System.Collections.ObjectModel;

namespace DraggableTreeView
{
    public interface IDraggableGroup : IDraggable
    {
        public ObservableCollection<IDraggable> Children { get; set; }
    }
}