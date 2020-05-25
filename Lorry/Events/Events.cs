using Lorry.Couplets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;

namespace Lorry
{
    public static class CollectionExtension
    {
        private static Random rng = new Random();

        public static Couplet RandomElement<Couplet>(this IList<Couplet> list)
        {
            return list[rng.Next(list.Count)];
        }

        public static Couplet RandomElement<Couplet>(this Couplet[] array)
        {
            return array[rng.Next(array.Length)];
        }
    }

    public class Events : Window
    {
        private Lorry.Couplets.CoupletListViewModel _coupletViewModel = new Lorry.Couplets.CoupletListViewModel();
        public Lorry.Couplets.CoupletListViewModel CoupletViewModel { get { return _coupletViewModel; } }


        public void uxFile_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void uxFileNew_Click(object sender, RoutedEventArgs e)
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

        public void uxFileOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        public void uxFileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        public void uxFileNewFreeForm_Click(object sender, RoutedEventArgs e)
        {

        }

        public void uxRecentLabel_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void uxGenerateCouplet_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = _coupletViewModel;

            List<Lorry.Couplets.Couplet> coupletList = CoupletViewModel.Couplets.ToList();

            Couplet randomCouplet = null;
            for (int i = 0; i <= 10; i++)
            {
                randomCouplet = coupletList.RandomElement();
            }

            MessageBox.Show(randomCouplet.CoupletContent);
        }
    }
}

