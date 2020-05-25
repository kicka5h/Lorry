using System;
using System.Collections.Generic;

namespace Lorry.Database
{
    public partial class Recent
    {
        public int RecentId { get; set; }
        public string RecentContent { get; set; }
        public string RecentType { get; set; }
        public string RecentDate { get; set; }
    }
}
