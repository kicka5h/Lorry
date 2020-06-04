using Lorry.Main;
using Lorry.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Lorry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Events
    {
        #region set the view model context
        private Lorry.Main.MainListViewModel _mainViewModel = new Lorry.Main.MainListViewModel();
        public Lorry.Main.MainListViewModel MainViewModel { get { return _mainViewModel; } }
        public ObservableCollection<Lorry.Main.Recent> Recents { get; set; }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MainViewModel;

            uxRecentPoem.Content = MainViewModel.MostRecent.RecentContent;
            uxCoupletList.DataContext = Recents;
            uxHaikuList.DataContext = Recents;
            uxCoupletList.ItemsSource = MainViewModel.Recents.Where(t => t.RecentType == "couplet");
            uxHaikuList.ItemsSource = MainViewModel.Recents.Where(t => t.RecentType == "haiku");
        }
    }
}