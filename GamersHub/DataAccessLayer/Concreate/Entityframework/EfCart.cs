using DataAccessLayer.Abstract;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concreate.Entityframework
{
    public class EfCart : EfRepository<Cart>,ICartDAL
    {
        
    }
}
