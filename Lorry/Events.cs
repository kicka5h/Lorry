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

namespace Lorry
{
    public class Events : Window
    {
        #region add the view model context
        private Lorry.Couplets.CoupletListViewModel _coupletViewModel = new Lorry.Couplets.CoupletListViewModel();
        public Lorry.Couplets.CoupletListViewModel CoupletViewModel { get { return _coupletViewModel; } }

        private Lorry.Main.MainListViewModel _recentViewModel = new Lorry.Main.MainListViewModel();
        public Lorry.Main.MainListViewModel RecentViewModel { get { return _recentViewModel; } }
        #endregion

        public void uxButtonViewCouplets_Click(object sender, RoutedEventArgs e)
        {

        }

        public void uxButtonViewHaikus_Click(object sender, RoutedEventArgs e)
        {

        }

        public void uxFileDashboard_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();

            this.Close();
        }

        public void uxFileNewHaiku_Click(object sender, RoutedEventArgs e)
        {
            var haikuWindow = new HaikuWindow();
            Application.Current.MainWindow = haikuWindow;
            haikuWindow.Show();

            this.Close();
        }

        public void uxFileNewCouplet_Click(object sender, RoutedEventArgs e)
        {
            var coupletWindow = new CoupletWindow();
            Application.Current.MainWindow = coupletWindow;
            coupletWindow.Show();

            this.Close();
        }

        public void uxFileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void uxButtonGenerateCouplet_Click(object sender, RoutedEventArgs e)
        {
            string returnRecent = GenerateRandom.RandomCouplet;
            CoupletWindow coupletWindow = new CoupletWindow();

            Lorry.Repository.Recents.Recent newRecent = new Repository.Recents.Recent();
            newRecent.RecentContent = returnRecent;
            newRecent.RecentDate = DateTime.Now.ToString("MM.dd.yyyy");
            newRecent.RecentType = "couplet";

            Lorry.Repository.IDatabaseRepository<Repository.Recents.Recent> addRecent = new Lorry.Repository.Recents.RecentRepository();
            addRecent.Insert(newRecent);
            coupletWindow.uxCoupletRecent.Content = RecentViewModel.MostRecentCouplet.RecentContent;
        }

        public void uxButtonGenerateHaiku_Click(object sender, RoutedEventArgs e)
        {
            string returnRecent = GenerateRandom.RandomHaiku;

            Lorry.Repository.Recents.Recent newRecent = new Repository.Recents.Recent();
            newRecent.RecentContent = returnRecent;
            newRecent.RecentDate = DateTime.Now.ToString("MM.dd.yyyy");
            newRecent.RecentType = "haiku";

            Lorry.Repository.IDatabaseRepository<Repository.Recents.Recent> addRecent = new Lorry.Repository.Recents.RecentRepository();
            addRecent.Insert(newRecent);
        }

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

