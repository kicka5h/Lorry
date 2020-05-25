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
    }

}
