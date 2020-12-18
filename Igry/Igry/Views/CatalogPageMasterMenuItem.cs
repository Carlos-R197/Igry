using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igry.Views
{
    public class CatalogPageMasterMenuItem
    {
        public CatalogPageMasterMenuItem()
        {
            TargetType = typeof(CatalogPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}