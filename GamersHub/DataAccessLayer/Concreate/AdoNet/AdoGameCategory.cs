using DataAccessLayer.Abstract;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concreate.AdoNet
{
    internal class AdoGameCategory : ICategoryDAL
    {
        public bool Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
