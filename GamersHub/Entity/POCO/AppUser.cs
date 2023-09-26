using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class AppUser:IdentityUser<int>
    {
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
