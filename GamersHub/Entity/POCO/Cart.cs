using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class Cart:BaseEntity
    {
        public int GameId { get; set; }
        public int AppUserId { get; set; }
        public int Quantity { get; set; }
        public virtual Game Game { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
