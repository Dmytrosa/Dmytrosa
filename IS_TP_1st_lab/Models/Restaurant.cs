using System;
using System.Collections.Generic;

namespace IS_TP_1th_lab
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Menus = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string RestAdress { get; set; } = null!;
        public string RestTitle { get; set; } = null!;

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
