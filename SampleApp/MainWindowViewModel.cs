using System.Collections.ObjectModel;
using System.Windows.Input;
using DraggableTreeView;

namespace SampleApp
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ICommand _newGroupCommand;
        private ICommand _newItemCommand;
        private IDraggableGroup _selectedGroup;
        private IDraggable _selectedItem;

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<IDraggable>
            {
                new ItemGroup
                {
                    Name = "Group",
                    Children = new ObservableCollection<IDraggable>
                    {
                        new ItemGroup
                        {
                            Name = "Group",
                            Children = new ObservableCollection<IDraggable>
                            {
                                new ItemEntry { Name = "Item" }
                            }
                        }
                    }
                },
                new ItemEntry { Name = "Item" }
            };
        }

        public ObservableCollection<IDraggable> Items { get; set; }

        public ICommand NewGroupCommand =>
            _newGroupCommand ?? ( _newGroupCommand = new RelayCommand( NewGroup, o => true ) );

        public ICommand NewItemCommand =>
            _newItemCommand ?? ( _newItemCommand = new RelayCommand( NewItem, o => true ) );

        public IDraggableGroup SelectedGroup
        {
            get => _selectedGroup;
            set => SetProperty( ref _selectedGroup, value );
        }

        public IDraggable SelectedItem
        {
            get => _selectedItem;
            set => SetProperty( ref _selectedItem, value );
        }

        private void NewGroup( object obj )
        {
            ObservableCollection<IDraggable> parent = GetParent();

            parent.Add( new ItemGroup { Name = "Group" } );
        }

        private void NewItem( object obj )
        {
            ObservableCollection<IDraggable> parent = GetParent();

            parent.Add( new ItemEntry { Name = "Item" } );
        }

        private ObservableCollection<IDraggable> GetParent()
        {
            ObservableCollection<IDraggable> parent = Items;

            if ( _selectedGroup != null )
            {
                parent = _selectedGroup.Children;
            }

            return parent;
        }
    }
}