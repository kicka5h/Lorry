using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace Lorry.Couplets
{
    public class CoupletListViewModel
    {

        private Lorry.Repository.Couplets.CoupletRepository _repo = new Lorry.Repository.Couplets.CoupletRepository();


        public CoupletListViewModel()
        {
            LoadCouplets();
        }

        private ObservableCollection<Lorry.Couplets.Couplet> _couplets;
        public ObservableCollection<Lorry.Couplets.Couplet> Couplets
        {
            get { return _couplets; }
            set { _couplets = value;  }
        }

        public void LoadCouplets()
        {
            _couplets = new ObservableCollection<Lorry.Couplets.Couplet>(_repo.GetAll().Select(t => t.ToUIModel()));
        }
    }
}
