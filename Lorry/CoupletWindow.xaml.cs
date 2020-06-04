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
        #region set the view model context
        private Lorry.Couplets.CoupletListViewModel _coupletViewModel = new Lorry.Couplets.CoupletListViewModel();

        private Lorry.Main.MainListViewModel _mainViewModel = new Lorry.Main.MainListViewModel();
        public new Lorry.Main.MainListViewModel MainViewModel { get { return _mainViewModel; } }
        public new Lorry.Couplets.CoupletListViewModel CoupletViewModel { get { return _coupletViewModel; } }
        public ObservableCollection<Lorry.Main.Recent> Recents { get; set; }
        #endregion

        public CoupletWindow()
        {
            InitializeComponent();

            DataContext = Recents;
            uxCoupletList.DataContext = MainViewModel.Recents;
            Lorry.Main.Recent recentCouplet = MainViewModel.Recents.Where(t => t.RecentType == "couplet").LastOrDefault();
            uxCoupletRecent.DataContext = recentCouplet.RecentContent;

            uxCoupletList.ItemsSource = MainViewModel.Recents.Where(t => t.RecentType == "couplet");
            uxCoupletRecent.Content = recentCouplet.RecentContent;
        }

        public void uxCoupletList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MessageBox.Show($"Are you sure you'd like to delete this poem?", "", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new MainWindow();
                Lorry.Repository.IDatabaseRepository<Repository.Recents.Recent> getRecent = new Lorry.Repository.Recents.RecentRepository();

                Main.Recent item = (Main.Recent)mainWindow.uxCoupletList.Items.CurrentItem;
                string content = item.RecentContent;

                Main.Recent deleteRecent = MainViewModel.Recents.Where(t => t.RecentContent == content).SingleOrDefault();
                Repository.Recents.Recent finallyDelete = deleteRecent.ToRepositoryModel();

                getRecent.Delete(finallyDelete);

                MessageBox.Show("Okay, poem has been deleted.");
            }
            else { };
        }
    }
}