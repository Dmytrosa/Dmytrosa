using System;
using System.Collections.Generic;

namespace IS_TP_1th_lab
{
    public partial class Menu
    {
        public Menu()
        {
            DishLists = new HashSet<DishList>();
        }

        public int Id { get; set; }
        public string DishTitle { get; set; } = null!;
        public decimal DishPrice { get; set; }
        public double Waight { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual ICollection<DishList> DishLists { get; set; }
    }
}
