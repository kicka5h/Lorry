using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Lorry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Events
    {
        private Lorry.Main.MainListViewModel _mainViewModel = new Lorry.Main.MainListViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MainViewModel;
            uxRecentPoem.DataContext = MainViewModel.Recents;
        }

        public Lorry.Main.MainListViewModel MainViewModel { get { return _mainViewModel; } }

        private void uxFileReload_Click(object sender, RoutedEventArgs e)
        {
            _mainViewModel.LoadRecents();
            uxRecentPoem.DataContext = MainViewModel.Recents;
        }
    }
}