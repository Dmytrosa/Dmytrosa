using System;
using System.Collections.Generic;

namespace IS_TP_1th_lab
{
    public partial class Addre
    {
        public Addre()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Street { get; set; } = null!;
        public string Bulding { get; set; } = null!;
        public int? Flat { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
