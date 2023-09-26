using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class Image:BaseEntity
    {
        public int GameID { get; set; }
        public string ImageURL { get; set; }
        public string AltText { get; set; }
        public virtual Game Games { get; set; }
    }
}
