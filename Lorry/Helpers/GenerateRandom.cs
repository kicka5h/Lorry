using Lorry.Couplets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lorry.Helpers
{
    public static class ListExtensions
    {
        public static T PickRandom<T>(this List<T> enumerable)
        {
            int index = new Random().Next(0, enumerable.Count());
            return enumerable[index];
        }
    }

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

    public class GenerateRandom
    {
        private static Lorry.Couplets.CoupletListViewModel _coupletViewModel = new Lorry.Couplets.CoupletListViewModel();
        private static Lorry.Couplets.CoupletListViewModel CoupletViewModel { get { return _coupletViewModel; } }

        public static Couplet GenerateCouplet
        {
            get
            {
                for (int i = 1; i <= 6; i++) {
                    List<Couplet> coupletList = CoupletViewModel.Couplets.ToList();
                    Couplet randomCouplet = coupletList.RandomElement();
                    return randomCouplet;
                }
                return null;
            }
        }
    }
}
