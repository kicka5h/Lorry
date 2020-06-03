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
            uxList.DataContext = Recents;
            uxList.ItemsSource = MainViewModel.Recents.Where(t => t.RecentType == "couplet");
            uxCoupletRecent.Content = MainViewModel.MostRecentCouplet.RecentContent;
        }
    }
}
