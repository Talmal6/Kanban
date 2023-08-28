using FrontEnd.Model;
using FrontEnd.ViewModel;
using System.Windows;


namespace FrontEnd.View
{
    /// <summary>
    /// Interaction logic for AddBoardView.xaml
    /// </summary>
    public partial class AddBoardView : Window
    {
        ViewManager manager;
        AddBoardViewModel vm;
        public AddBoardView(ViewManager _manager,BackendController controller, BoardListView BLV)
        {

            InitializeComponent();
            vm = new AddBoardViewModel(controller, BLV.GetVM());
            DataContext = vm;
            this.manager = _manager;
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            manager.ExitAddBoard();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(vm.AddBoard(manager.currentUser.Email))
            {
                
                manager.ExitAddBoard();
            }
        }
    }
}
