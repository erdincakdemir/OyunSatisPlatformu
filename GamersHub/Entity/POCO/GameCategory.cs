using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;

namespace Entity.POCO
{
    public class GameCategory:IBaseEntity
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int CategoryId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Category Category { get; set; }
    }
}
