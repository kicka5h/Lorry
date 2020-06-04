using Lorry.Couplets;
using Lorry.Database;
using Lorry.Helpers;
using Lorry.Main;
using Lorry.Repository;
using Lorry.Repository.Recents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Lorry
{
    public class Events : Window
    {
        #region add the view model context
        private Lorry.Couplets.CoupletListViewModel _coupletViewModel = new Lorry.Couplets.CoupletListViewModel();
        public Lorry.Couplets.CoupletListViewModel CoupletViewModel { get { return _coupletViewModel; } }
        private Lorry.Haikus.HaikuListViewModel _haikuViewModel = new Lorry.Haikus.HaikuListViewModel();
        public new Lorry.Haikus.HaikuListViewModel HaikuViewModel { get { return _haikuViewModel; } }

        private Lorry.Main.MainListViewModel _recentViewModel = new Lorry.Main.MainListViewModel();
        public Lorry.Main.MainListViewModel RecentViewModel { get { return _recentViewModel; } }
        private Lorry.Main.MainListViewModel _mainViewModel = new Lorry.Main.MainListViewModel();
        public new Lorry.Main.MainListViewModel MainViewModel { get { return _mainViewModel; } }
        #endregion

        public static string classContent;

        #region couplet events
        public void uxCoupletList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            Lorry.Repository.IDatabaseRepository<Repository.Recents.Recent> getRecent = new Lorry.Repository.Recents.RecentRepository();

            Main.Recent item = (Main.Recent)mainWindow.uxCoupletList.Items.CurrentItem;
            classContent = item.RecentContent;

            EditPoem editPoem = new EditPoem();
            editPoem.Show();
        }

        public void uxDeleteEditedPoem_Click(object sender, RoutedEventArgs e)
        {
            Lorry.Repository.IDatabaseRepository<Repository.Recents.Recent> getRecent = new Lorry.Repository.Recents.RecentRepository();
            Main.Recent deleteRecent = MainViewModel.Recents.Where(t => t.RecentContent == classContent).SingleOrDefault();

            Repository.Recents.Recent finallyDelete = deleteRecent.ToRepositoryModel();
            getRecent.Delete(finallyDelete);

            this.Close();
        }

        public void uxButtonAddCustomCouplet_Click(object sender, RoutedEventArgs e)
        {
            string inputRead = new Lorry.Helpers.GetInput.InputBox("Add your own").ShowDialog();

            Lorry.Repository.Recents.Recent newRecent = new Repository.Recents.Recent();
            newRecent.RecentContent = inputRead;
            newRecent.RecentDate = DateTime.Now.ToString("MM.dd.yyyy");
            newRecent.RecentType = "couplet";

            Lorry.Repository.IDatabaseRepository<Repository.Recents.Recent> addRecent = new Lorry.Repository.Recents.RecentRepository();
            addRecent.Insert(newRecent);
        }

        public void uxButtonGenerateCouplet_Click(object sender, RoutedEventArgs e)
        {
            string returnRecent = GenerateRandom.RandomCouplet;

            Lorry.Repository.Recents.Recent newRecent = new Repository.Recents.Recent();
            newRecent.RecentContent = returnRecent;
            newRecent.RecentDate = DateTime.Now.ToString("MM.dd.yyyy");
            newRecent.RecentType = "couplet";

            Lorry.Repository.IDatabaseRepository<Repository.Recents.Recent> addRecent = new Lorry.Repository.Recents.RecentRepository();
            addRecent.Insert(newRecent);
        }

        public void uxFileNewCouplet_Click(object sender, RoutedEventArgs e)
        {
            var coupletWindow = new CoupletWindow();
            Application.Current.MainWindow = coupletWindow;
            coupletWindow.Show();

            this.Close();
        }

        public void uxButtonEditCouplets_Click(object sender, RoutedEventArgs e)
        {
            var coupletWindow = new CoupletWindow();
            Application.Current.MainWindow = coupletWindow;
            coupletWindow.Show();

            this.Close();
        }

        public void uxButtonViewCouplets_Click(object sender, RoutedEventArgs e)
        {
            var coupletWindow = new CoupletWindow();
            Application.Current.MainWindow = coupletWindow;
            coupletWindow.Show();

            this.Close();
        }

        public void uxRefreshCouplets_Click(object sender, RoutedEventArgs e)
        {
            var coupletWindow = new CoupletWindow();
            Application.Current.MainWindow = coupletWindow;
            coupletWindow.Show();

            this.Close();
        }

        public void uxRefreshRecentCouplets_Click(object sender, RoutedEventArgs e)
        {
            CoupletWindow coupletWindow = new CoupletWindow();

            _mainViewModel.LoadRecents();
            coupletWindow.uxCoupletRecent.DataContext = MainViewModel.Recents;

            coupletWindow.uxCoupletRecent.Content = MainViewModel.MostRecentCouplet.RecentContent;
            coupletWindow.uxExpanderRecentCoupletWindow.IsExpanded = true;
        }
        #endregion

        #region haiku events
        public void uxButtonAddCustomHaiku_Click(object sender, RoutedEventArgs e)
        {
            string inputRead = new Lorry.Helpers.GetInput.InputBox("Add your own").ShowDialog();

            Lorry.Repository.Recents.Recent newRecent = new Repository.Recents.Recent();
            newRecent.RecentContent = inputRead;
            newRecent.RecentDate = DateTime.Now.ToString("MM.dd.yyyy");
            newRecent.RecentType = "haiku";

            Lorry.Repository.IDatabaseRepository<Repository.Recents.Recent> addRecent = new Lorry.Repository.Recents.RecentRepository();
            addRecent.Insert(newRecent);
        }

        public void uxButtonGenerateHaiku_Click(object sender, RoutedEventArgs e)
        {
            string returnRecent = GenerateRandom.RandomHaiku;
            HaikuWindow haikuWindow = new HaikuWindow();
            MainWindow mainWindow = new MainWindow();

            Lorry.Repository.Recents.Recent newRecent = new Repository.Recents.Recent();
            newRecent.RecentContent = returnRecent;
            newRecent.RecentDate = DateTime.Now.ToString("MM.dd.yyyy");
            newRecent.RecentType = "haiku";

            Lorry.Repository.IDatabaseRepository<Repository.Recents.Recent> addRecent = new Lorry.Repository.Recents.RecentRepository();
            addRecent.Insert(newRecent);

            Application.Current.MainWindow = haikuWindow;
            mainWindow.uxExpanderRecent.IsExpanded = true;
        }

        public void uxButtonEditHaikus_Click(object sender, RoutedEventArgs e)
        {
            var haikuWindow = new HaikuWindow();
            Application.Current.MainWindow = haikuWindow;
            haikuWindow.Show();

            this.Close();
        }

        public void uxButtonViewHaikus_Click(object sender, RoutedEventArgs e)
        {
            var haikuWindow = new HaikuWindow();
            Application.Current.MainWindow = haikuWindow;
            haikuWindow.Show();

            this.Close();
        }

        public void uxFileNewHaiku_Click(object sender, RoutedEventArgs e)
        {
            var haikuWindow = new HaikuWindow();
            Application.Current.MainWindow = haikuWindow;
            haikuWindow.Show();

            this.Close();
        }
        public void uxRefreshHaikus_Click(object sender, RoutedEventArgs e)
        {
            var haikuWindow = new HaikuWindow();
            Application.Current.MainWindow = haikuWindow;
            haikuWindow.Show();

            this.Close();
        }

        public void uxHaikuList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Lorry.Repository.IDatabaseRepository<Repository.Recents.Recent> getRecent = new Lorry.Repository.Recents.RecentRepository();

            Main.Recent item = (Main.Recent)mainWindow.uxHaikuList.Items.CurrentItem;
            classContent = item.RecentContent;

            EditPoem editPoem = new EditPoem();
            editPoem.Show();
        }
        #endregion

        #region main window events
        public void uxFileDashboard_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();

            this.Close();
        }

        public void uxFileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void uxRefreshRecent_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();

            this.Close();
        }
        #endregion

        #region unused event handlers
        public void uxFileNew_Click(object sender, RoutedEventArgs e)
        {

        }

        public void uxFileOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        public void uxEdit_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void uxEditAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        public void uxEditAddHaiku_Click(object sender, RoutedEventArgs e)
        {

        }

        public void uxEditAddCouplet_Click(object sender, RoutedEventArgs e)
        {

        }

        public void uxHelp_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void uxEditAddCoupletRhyme_Click(object sender, RoutedEventArgs e)
        {

        }

        public void uxRecentLabel_Loaded(object sender, RoutedEventArgs e)
        {

        }


        public void uxFile_Loaded(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}