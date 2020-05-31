using Lorry.Couplets;
using Lorry.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Lorry.Helpers
{
    #region extension: get a random element from a list
    public static class CoupletCollectionExtension
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
    #endregion

    public class GenerateRandom
    {
        #region Set the View Model context
        private static Lorry.Couplets.CoupletListViewModel _coupletViewModel = new Lorry.Couplets.CoupletListViewModel();
        private static Lorry.Couplets.CoupletListViewModel CoupletViewModel { get { return _coupletViewModel; } }

        private static Lorry.Haikus.HaikuListViewModel _haikuViewModel = new Lorry.Haikus.HaikuListViewModel();
        private static Lorry.Haikus.HaikuListViewModel HaikuViewModel { get { return _haikuViewModel;  } }
        #endregion

        #region method: Get a random couplet line
        public static Couplets.Couplet RandomCoupletLine
        {
            get
            {
                List<Couplets.Couplet> coupletList = CoupletViewModel.Couplets.ToList();
                Couplets.Couplet randomCouplet = coupletList.RandomElement();
                return randomCouplet;
            }
        }
        #endregion

        #region method: Get a random haiku line
        public static Haikus.Haiku RandomHaikuLine
        {
            get
            {
                List<Haikus.Haiku> haikuList = HaikuViewModel.Haikus.ToList();
                Haikus.Haiku randomHaiku = haikuList.RandomElement();
                return randomHaiku;
            }
        }
        #endregion

        #region method: Generate a complete random couplet
        public static string RandomCouplet
        {
            get
            {
                MainWindow mainWindow = new MainWindow();

                string[] lines1 = new string[2];
                for (int i = 0; i < 2; i++)
                {
                    lines1[i] = GenerateRandom.RandomCoupletLine.CoupletContent;
                }
                string returnRecent1 = String.Join(Environment.NewLine, lines1);
                string space = "\n";

                string[] lines2 = new string[2];
                for (int i = 0; i < 2; i++)
                {
                    lines2[i] = GenerateRandom.RandomCoupletLine.CoupletContent;
                }
                string returnRecent2 = String.Join(Environment.NewLine, lines2);

                string[] lines3 = new string[2];
                for (int i = 0; i < 2; i++)
                {
                    lines3[i] = GenerateRandom.RandomCoupletLine.CoupletContent;
                }
                string returnRecent3 = String.Join(Environment.NewLine, lines3);

                string generateMessage = "Success! Here's your Couplet:";

                string closeMessage = "Press Ok to close.";

                string returnRecent = generateMessage + space + space + returnRecent1 + space + space + returnRecent2 + space + space + returnRecent3 + space  + space + closeMessage;
                string showRecent = returnRecent1 + space + space + returnRecent2 + space + space + returnRecent3;

                MessageBox.Show(returnRecent);

                return showRecent;
            }
        }
        #endregion

        #region method: Generate a complete random Haiku
        public static string RandomHaiku
        {
            get
            {
                MainWindow mainWindow = new MainWindow();

                string[] lines = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    lines[i] = GenerateRandom.RandomHaikuLine.HaikuContent;
                }
                string returnRecent1 = String.Join(Environment.NewLine, lines);

                string generateMessage = "Success! Here's your Haiku:";

                string closeMessage = "Press Ok to close.";

                string space = "\n";

                string returnRecent = generateMessage + space + space + returnRecent1 + space + space + closeMessage;

                MessageBox.Show(returnRecent);
                mainWindow.uxExpanderRecent.IsExpanded = true;
                
                return returnRecent1;
            }
        }
        #endregion
    }
}
