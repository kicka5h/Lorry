using Lorry.Couplets;
using Lorry.Main;
using Lorry.Repository.Recents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace Lorry
{
    /// <summary>
    /// Interaction logic for CoupletWindow.xaml
    /// </summary>
    public partial class CoupletWindow : Events
    {
        private Lorry.Couplets.CoupletListViewModel _coupletViewModel = new Lorry.Couplets.CoupletListViewModel();

        private Lorry.Main.MainListViewModel _mainViewModel = new Lorry.Main.MainListViewModel();
        public new Lorry.Main.MainListViewModel MainViewModel { get { return _mainViewModel; } }
        public new Lorry.Couplets.CoupletListViewModel CoupletViewModel { get { return _coupletViewModel; } }

        public ObservableCollection<Lorry.Main.Recent> Recents { get; set; }

        public CoupletWindow()
        {
            InitializeComponent();

            DataContext = Recents;
            uxList.DataContext = Recents;
            uxList.ItemsSource = MainViewModel.Recents;
        }

        private void uxFileReload_Click(object sender, RoutedEventArgs e)
        {
            _coupletViewModel.LoadCouplets();
            _mainViewModel.LoadRecents();
            uxList.DataContext = MainViewModel;

            uxList.ItemsSource = CoupletViewModel.Recents;
            uxCoupletRecent.Content = MainViewModel.MostRecentCouplet.RecentContent;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show($"Are you sure you'd like to delete this poem?", "", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Main.Recent item = (Main.Recent)uxList.Items.CurrentItem;
                string content = item.RecentContent;

                /*
                var deleteRecent = from deletedRecent in getDeleteRecent
                                   where deletedRecent.RecentContent == content
                                   select deletedRecent;
                */

                Main.Recent deleteRecent = MainViewModel.Recents.Where(t => t.RecentContent == content).SingleOrDefault();
                Repository.Recents.Recent finallyDelete = deleteRecent.ToRepositoryModel();

                Lorry.Repository.IDatabaseRepository<Repository.Recents.Recent> getRecent = new Lorry.Repository.Recents.RecentRepository();
                getRecent.Delete(finallyDelete);
            }
            else { };
        }
    }
}
