using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;

namespace Entity.POCO
{
    public class Game:BaseEntity
    {
        public string GameName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Version { get; set; }
        public string CreatorName { get; set; }
        public double Rating { get; set; }
        public double Size { get; set; }
        public virtual ICollection<GameCategory> GameCategories { get; set; }
        public virtual ICollection<Image> Games { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }

    }
}
