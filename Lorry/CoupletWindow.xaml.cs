using Lorry.Couplets;
using Lorry.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public new Lorry.Couplets.CoupletListViewModel CoupletViewModel { get { return _coupletViewModel; } }

        private Lorry.Main.MainListViewModel _mainViewModel = new Lorry.Main.MainListViewModel();
        public new Lorry.Main.MainListViewModel MainViewMdodel { get { return _mainViewModel; } }

        public CoupletWindow()
        {
            InitializeComponent();
            this.DataContext = CoupletViewModel;

            uxList.ItemsSource = CoupletViewModel.Couplets;
            uxCoupletRecent.Content = MainViewMdodel.MostRecentCouplet.RecentContent;
        }

        private void uxFileReload_Click(object sender, RoutedEventArgs e)
        {
            _coupletViewModel.LoadCouplets();
            _mainViewModel.LoadRecents();

            uxList.ItemsSource = CoupletViewModel.Couplets;
            uxCoupletRecent.Content = MainViewMdodel.MostRecentCouplet.RecentContent;
        }
    }
}
