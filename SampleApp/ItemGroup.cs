using System.Collections.ObjectModel;
using DraggableTreeView;

namespace SampleApp
{
    public class ItemGroup : IDraggableGroup
    {
        public string Name { get; set; }
        public ObservableCollection<IDraggable> Children { get; set; } = new ObservableCollection<IDraggable>();
    }
}