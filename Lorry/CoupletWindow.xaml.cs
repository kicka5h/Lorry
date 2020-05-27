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

        public CoupletWindow()
        {
            InitializeComponent();
            this.DataContext = CoupletViewModel;

            uxList.ItemsSource = CoupletViewModel.Couplets;
            uxCoupletRecent.DataContext = CoupletViewModel.Recents;
        }

        public new Lorry.Couplets.CoupletListViewModel CoupletViewModel { get { return _coupletViewModel; } }

        private void uxFileReload_Click(object sender, RoutedEventArgs e)
        {
            _coupletViewModel.LoadCouplets();

            uxList.ItemsSource = CoupletViewModel.Couplets;
            uxCoupletRecent.DataContext = CoupletViewModel.Recents;
        }
    }
}
