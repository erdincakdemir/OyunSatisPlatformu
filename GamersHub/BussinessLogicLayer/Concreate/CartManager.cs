using BussinessLogicLayer.Abstract;
using Core.BLL.Logger;
using DataAccessLayer.Abstract;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicLayer.Concreate
{
    public class CartManager : ICartService
    {
        ICartDAL dAL;
        public CartManager(ICartDAL cartDAL)
        {
            dAL = cartDAL;
        }
        public bool Add(Cart entity)
        {
            try
            {
                //bool result = dAL.Add(entity);
                //return result;

               return dAL.Add(entity);
                
            }
            catch (Exception ex)
            {

                GamersHubLogger.AddLog(ex.Message, LogType.Error);
                return false;
            }
        }

        public bool Delete(Cart entity)
        {
            try
            {
               return dAL.Delete(entity);

            }
            catch (Exception ex)
            {

                GamersHubLogger.AddLog(ex.Message, LogType.Error);
                return false;
            }
        }

        public Cart Get(int id)
        {
            try
            {
                return dAL.Get(id);

            }
            catch (Exception ex)
            {

                GamersHubLogger.AddLog(ex.Message, LogType.Error);
                return null;
            }
        }

        public IEnumerable<Cart> Get()
        {
            try
            {
                return dAL.Get();

            }
            catch (Exception ex)
            {

                GamersHubLogger.AddLog(ex.Message, LogType.Error);
                return null;
            }
        }

        public bool Update(Cart entity)
        {
            try
            {
                return dAL.Update(entity);

            }
            catch (Exception ex)
            {

                GamersHubLogger.AddLog(ex.Message, LogType.Error);
                return false;
            }
        }
    }
}
