using System;
using System.Collections.Generic;

namespace IS_TP_1th_lab
{
    public partial class Client
    {
        public Client()
        {
            Addres = new HashSet<Addre>();
            Comments = new HashSet<Comment>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string Password { get; set; } = null!;
        public string Mail { get; set; } = null!;

        public virtual ICollection<Addre> Addres { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
