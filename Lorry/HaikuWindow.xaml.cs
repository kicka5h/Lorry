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

namespace Lorry
{
    /// <summary>
    /// Interaction logic for HaikuWindow.xaml
    /// </summary>
    public partial class HaikuWindow : Events
    {
        private Lorry.Haikus.HaikuListViewModel _haikuViewModel = new Lorry.Haikus.HaikuListViewModel();

        public HaikuWindow()
        {
            InitializeComponent();
            this.DataContext = HaikuViewModel;
            uxList.ItemsSource = HaikuViewModel.Haikus;
        }

        public new Lorry.Haikus.HaikuListViewModel HaikuViewModel { get { return _haikuViewModel; } }

        private void uxFileReload_Click(object sender, RoutedEventArgs e)
        {
            _haikuViewModel.LoadHaikus();
            uxList.ItemsSource = HaikuViewModel.Haikus;
        }
    }
}
