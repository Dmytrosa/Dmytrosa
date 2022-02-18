using System;
using System.Collections.Generic;

namespace IS_TP_1th_lab
{
    public partial class DishList
    {
        public DishList()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int MenuId { get; set; }
        public decimal FullPrice { get; set; }

        public virtual Menu Menu { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
