using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimponiApp.Views
{

    public class SimponiMasterDetailPageMenuItemMenuItem
    {
        public SimponiMasterDetailPageMenuItemMenuItem()
        {
            TargetType = typeof(SimponiMasterDetailPageDetailDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}