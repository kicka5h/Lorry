using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Lorry.Haikus
{
    public class HaikuListViewModel
    {

        private Lorry.Repository.Haikus.HaikuRepository _repo = new Lorry.Repository.Haikus.HaikuRepository();


        public HaikuListViewModel()
        {
            LoadHaikus();
        }

        private ObservableCollection<Lorry.Haikus.Haiku> _haikus;
        public ObservableCollection<Lorry.Haikus.Haiku> Haikus
        {
            get { return _haikus; }
            set { _haikus = value; }
        }

        public void LoadHaikus()
        {
            _haikus = new ObservableCollection<Lorry.Haikus.Haiku>(_repo.GetAll().Select(t => t.ToUIModel()));
        }
    }
}
