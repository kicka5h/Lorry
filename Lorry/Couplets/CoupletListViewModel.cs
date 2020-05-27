using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Lorry.Main;

namespace Lorry.Couplets
{
    public class CoupletListViewModel
    {

        private Lorry.Repository.Couplets.CoupletRepository _repo = new Lorry.Repository.Couplets.CoupletRepository();
        private Lorry.Repository.Recents.RecentRepository _recRepo = new Lorry.Repository.Recents.RecentRepository();

        public CoupletListViewModel()
        {
            LoadCouplets();
            LoadRecents();
        }

        private ObservableCollection<Lorry.Couplets.Couplet> _couplets;
        public ObservableCollection<Lorry.Couplets.Couplet> Couplets
        {
            get { return _couplets; }
            set { _couplets = value;  }
        }

        private ObservableCollection<Lorry.Main.Recent> _recents;
        public ObservableCollection<Lorry.Main.Recent> Recents
        {
            get { return _recents; }
            set { _recents = value; }
        }


        public void LoadCouplets()
        {
            _couplets = new ObservableCollection<Lorry.Couplets.Couplet>(_repo.GetAll().Select(t => t.ToUIModel()));
        }

        public void LoadRecents()
        {
            _recents = new ObservableCollection<Lorry.Main.Recent>(_recRepo.GetAll().Select(t => t.ToUIModel()));
        }

        public void AddRecents()
        {
            
        }
    }
}
