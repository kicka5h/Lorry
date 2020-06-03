using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Lorry.Main
{
    public class MainListViewModel
    {

        private Lorry.Repository.Recents.RecentRepository _repo = new Lorry.Repository.Recents.RecentRepository();

        public MainListViewModel()
        {
            LoadRecents();
        }

        private ObservableCollection<Lorry.Main.Recent> _recents;
        public ObservableCollection<Lorry.Main.Recent> Recents
        {
            get { return _recents; }
            set { _recents = value; }
        }

        public void LoadRecents()
        {
            _recents = new ObservableCollection<Lorry.Main.Recent>(_repo.GetAll().Select(t => t.ToUIModel()));
        }

        public Main.Recent MostRecent
        {
            get
            {
                Main.Recent mostRecent = _recents.OrderByDescending(t => t.RecentId).FirstOrDefault();

                return mostRecent;
            }
        }

        public Main.Recent MostRecentCouplet
        {

            get
            {
                Main.Recent mostRecent = _recents.OrderByDescending(t => t.RecentType).LastOrDefault();

                if (mostRecent.RecentType == "couplet") { return mostRecent; }
                else { return mostRecent; }
            }
        }

        public Main.Recent MostRecentHaiku
        {
            get
            {
                Main.Recent mostRecent = _recents.OrderByDescending(t => t.RecentType).FirstOrDefault();

                if (mostRecent.RecentType == "haiku") { return mostRecent; }
                else { return mostRecent; }
            }
        }
    }
}
