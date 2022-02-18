using System;
using System.Collections.Generic;

namespace IS_TP_1th_lab
{
    public partial class Comment
    {
        public Comment()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime PostingDate { get; set; }
        public string CommentText { get; set; } = null!;

        public virtual Client Client { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
