using System;
using System.Collections.Generic;

namespace IS_TP_1th_lab
{
    public partial class Deliver
    {
        public Deliver()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Transport { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
