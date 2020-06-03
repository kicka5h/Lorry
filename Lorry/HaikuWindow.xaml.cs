using System;
using System.Collections.Generic;
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

namespace Lorry
{
    /// <summary>
    /// Interaction logic for HaikuWindow.xaml
    /// </summary>
    public partial class HaikuWindow : Events
    {
        #region addd the view model context
        private Lorry.Haikus.HaikuListViewModel _haikuViewModel = new Lorry.Haikus.HaikuListViewModel();
        public new Lorry.Haikus.HaikuListViewModel HaikuViewModel { get { return _haikuViewModel; } }

        private Lorry.Main.MainListViewModel _mainViewModel = new Lorry.Main.MainListViewModel();
        public new Lorry.Main.MainListViewModel MainViewModel { get { return _mainViewModel; } }
        #endregion

        public HaikuWindow()
        {
            InitializeComponent();
            uxHaikuList.DataContext = MainViewModel.Recents;
            Lorry.Main.Recent recentHaiku = MainViewModel.Recents.Where(t => t.RecentType == "haiku").LastOrDefault();
            uxHaikuRecent.DataContext = recentHaiku.RecentContent;

            uxHaikuList.ItemsSource = MainViewModel.Recents.Where(t => t.RecentType == "haiku");

            uxHaikuRecent.Content = recentHaiku.RecentContent;
        }

        private void uxHaikuList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
