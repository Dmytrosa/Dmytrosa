using System;
using System.Collections.Generic;

namespace IS_TP_1th_lab
{
    public partial class Order
    {
        public int Id { get; set; }
        public string StartLocation { get; set; } = null!;
        public int? CommentId { get; set; }
        public int ClientId { get; set; }
        public int AddressId { get; set; }
        public int DeliverId { get; set; }
        public int DishListId { get; set; }

        public virtual Addre Address { get; set; } = null!;
        public virtual Client Client { get; set; } = null!;
        public virtual Comment? Comment { get; set; }
        public virtual Deliver Deliver { get; set; } = null!;
        public virtual DishList DishList { get; set; } = null!;
    }
}
