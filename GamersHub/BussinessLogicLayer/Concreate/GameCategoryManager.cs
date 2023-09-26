using BussinessLogicLayer.Abstract;
using Core.BLL.Logger;
using DataAccessLayer.Abstract;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicLayer.Concreate
{
    public class GameCategoryManager : IGameCategoryService
    {
        IGameCategoryDAL _gameCategoryDal;
        public GameCategoryManager(IGameCategoryDAL dAL)
        {
            _gameCategoryDal = dAL;
        }

        public bool Add(GameCategory entity)
        {
            try
            {
                bool result = _gameCategoryDal.Add(entity);
                if (result == true)
                {
                    GamersHubLogger.AddLog($"{entity.GameId} Id değerine sahip Oyun {entity.CategoryId} Id değerli kategori ile eşleştirildi.", LogType.Insert);
                    return true;
                }
                else
                {
                    GamersHubLogger.AddLog($"{entity.GameId} Id değerine sahip Oyun {entity.CategoryId} Id değerli kategori ile eşleştirildi.", LogType.NonValidation);
                    return false;
                }
            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return false;
            }
        }

        public bool Delete(GameCategory entity)
        {
            try
            {
                bool result = _gameCategoryDal.Delete(entity);
                if (result == true)
                {
                    GamersHubLogger.AddLog($"{entity.GameId} Id değerine sahip Oyun {entity.CategoryId} Id değerli kategori ile eşleştirilmesi kaldırıldı.", LogType.Delete);
                    return true;
                }
                else
                {
                    GamersHubLogger.AddLog($"{entity.GameId} Id değerine sahip Oyun {entity.CategoryId} Id değerli kategori ile eşleştirilmesi kaldırılamadı.", LogType.NotFound);
                    return false;
                }
            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return false;

            }
        }

        public GameCategory Get(int id)
        {
            try
            {
                return _gameCategoryDal.Get(id);

            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return null;

            }
        }

        public IEnumerable<GameCategory> Get()
        {
            try
            {
                return _gameCategoryDal.Get();

            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return null;

            }
        }

        public bool Update(GameCategory entity)
        {
            try
            {
                bool result = _gameCategoryDal.Update(entity);
                if (result == true)
                {
                    GamersHubLogger.AddLog($"{entity.GameId} Id değerine sahip Oyun {entity.CategoryId} Id değerli kategori ile eşleştirilmesi güncellendi.", LogType.Update);
                    return true;
                }
                else
                {
                    GamersHubLogger.AddLog($"{entity.GameId} Id değerine sahip Oyun {entity.CategoryId} Id değerli kategori ile eşleştirilmesi güncellenemedi.", LogType.NonValidation);
                    return false;
                }
            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return false;

            }
        }
    }
}
