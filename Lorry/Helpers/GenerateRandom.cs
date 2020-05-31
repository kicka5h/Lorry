using Lorry.Couplets;
using Lorry.Database;
using Lorry.Haikus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Lorry.Helpers
{
    #region extension: Generate random elements from Haikus and Couplets
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

        public static List<Lorry.Couplets.Couplet> GetTwoRandomCouplets(this IList<Lorry.Couplets.Couplet> list)
        {
            List<Lorry.Couplets.Couplet> output = new List<Lorry.Couplets.Couplet>();
            Lorry.Couplets.Couplet first = list[rng.Next(list.Count)];

            List<Lorry.Couplets.Couplet> secondList = list.Where(t => t.CoupletRhyme == first.CoupletRhyme).ToList();
            Lorry.Couplets.Couplet second = secondList[rng.Next(secondList.Count)];

            output.Add(first);

            if (second.CoupletId != first.CoupletId)
            {
                output.Add(second);
            }
            else
            {
                second = list[rng.Next(list.Count)];
            }

            return output;
        }

        public static List<Lorry.Haikus.Haiku> GetThreeRandomHaikus(this IList<Lorry.Haikus.Haiku> list)
        {
            List<Lorry.Haikus.Haiku> output = new List<Lorry.Haikus.Haiku>();

            List<Lorry.Haikus.Haiku> firstList = list.Where(t => t.HaikuCount == "5").ToList();
            Lorry.Haikus.Haiku first = firstList[rng.Next(firstList.Count)];

            List<Lorry.Haikus.Haiku> secondList = list.Where(t => t.HaikuCount == "7").ToList();
            Lorry.Haikus.Haiku second = secondList[rng.Next(secondList.Count)];

            List<Lorry.Haikus.Haiku> thirdList = list.Where(t => t.HaikuCount == "5").ToList();
            Lorry.Haikus.Haiku third = thirdList[rng.Next(thirdList.Count)];

            output.Add(first);
            output.Add(second);

            if (third.HaikuId != first.HaikuId)
            {
                output.Add(third);
            }
            else
            {
                third = list[rng.Next(list.Count)];
            }

            return output;
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

        #region method: Get a random couplet line (no longer used)
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

        #region method: Get a random haiku line (no longer used)
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

        #region method: Generate a random Couplet pair
        public static string RandomTwoCoupletLines
        {
            get
            {
                List<Couplets.Couplet> coupletList = CoupletViewModel.Couplets.ToList().GetTwoRandomCouplets();
                string outputLines;

                outputLines = String.Format($"{coupletList[0].CoupletContent}{Environment.NewLine}{coupletList[1].CoupletContent}{Environment.NewLine}");
                return outputLines;
            }
        }
        #endregion

        #region method: Generate a random Haiku
        public static string RandomThreeHaikuLines
        {
            get
            {
                List<Haikus.Haiku> haikuList = HaikuViewModel.Haikus.ToList().GetThreeRandomHaikus();
                string outputLines;

                outputLines = String.Format($"{haikuList[0].HaikuContent}{Environment.NewLine}{haikuList[1].HaikuContent}{Environment.NewLine}{haikuList[2].HaikuContent}");
                return outputLines;
            }
        }
        #endregion

        #region method: Generate a complete random couplet & show a message
        public static string RandomCouplet
        {
            get
            {
                MainWindow mainWindow = new MainWindow();

                /*
                string[] lines1 = new string[2];
                for (int i = 0; i < 2; i++)
                {
                    lines1[i] = GenerateRandom.RandomCoupletLine.CoupletContent;
                }
                string returnRecent1 = String.Join(Environment.NewLine, lines1);
                */

                string space = "\n";
                
                /*
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
                */

                string generateMessage = "Success! Here's your Couplet:";

                string closeMessage = "Press Ok to close.";

                /*
                string returnRecent = generateMessage + space + space + returnRecent1 + space + space + returnRecent2 + space + space + returnRecent3 + space  + space + closeMessage;
                string showRecent = returnRecent1 + space + space + returnRecent2 + space + space + returnRecent3;
                */

                string returnRecent1 = GenerateRandom.RandomTwoCoupletLines;
                string returnRecent2 = GenerateRandom.RandomTwoCoupletLines;
                string returnRecent3 = GenerateRandom.RandomTwoCoupletLines;

                string returnRecent = returnRecent1 + space + space + returnRecent2 + space + space + returnRecent3;
                string showMessage = generateMessage + space + returnRecent1 + space + returnRecent2 + space + returnRecent3 + space + closeMessage;

                MessageBox.Show(returnRecent);

                return returnRecent;
            }
        }
        #endregion

        #region method: Generate a complete random Haiku & show a message
        public static string RandomHaiku
        {
            get
            {
                MainWindow mainWindow = new MainWindow();

                /*
                string[] lines = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    lines[i] = GenerateRandom.RandomHaikuLine.HaikuContent;
                }
                string returnRecent1 = String.Join(Environment.NewLine, lines);
                */

                string generateMessage = "Success! Here's your Haiku:";

                string closeMessage = "Press Ok to close.";

                string space = "\n";

                string returnRecent = GenerateRandom.RandomThreeHaikuLines;

                string showMessage = generateMessage + space + space + returnRecent + space + space + closeMessage;

                MessageBox.Show(showMessage);
                mainWindow.uxExpanderRecent.IsExpanded = true;
                
                return returnRecent;
            }
        }
        #endregion
    }
}
