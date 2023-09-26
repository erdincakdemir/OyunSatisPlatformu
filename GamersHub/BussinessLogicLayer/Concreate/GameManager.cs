using BussinessLogicLayer.Abstract;
using Core.BLL.Logger;
using DataAccessLayer.Abstract;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicLayer.Concreate
{
    public class GameManager : IGameService
    {
        IGameDAL _gameDal;
        public GameManager(IGameDAL dAL)
        {
            _gameDal = dAL;
        }

        public bool Add(Game entity)
        {
            try
            {
                bool result = _gameDal.Add(entity);
                if (result == true)
                {
                    GamersHubLogger.AddLog($"{entity.GameName} isimli yeni oyun eklendi.", LogType.Insert);
                    return true;
                }
                else
                {
                    GamersHubLogger.AddLog($"{entity.GameName} isimli yeni oyun eklenemedi.", LogType.NonValidation);
                    return false;
                }
            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return false;
            }
        }

        public bool Delete(Game entity)
        {
            try
            {
                bool result = _gameDal.Add(entity);
                if (result == true)
                {
                    GamersHubLogger.AddLog($"{entity.GameName} isimli oyun silindi.", LogType.Delete);
                    return true;
                }
                else
                {
                    GamersHubLogger.AddLog($"{entity.GameName} isimli oyun silinemedi.", LogType.NotFound);
                    return false;
                }
            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return false;
            }
        }

        public Game Get(int id)
        {
            try
            {
                return _gameDal.Get(id);

            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return null;

            }
        }

        public IEnumerable<Game> Get()
        {
            try
            {
                return _gameDal.Get();

            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return null;

            }
        }

        public bool Update(Game entity)
        {
            try
            {
                bool result = _gameDal.Add(entity);
                if (result == true)
                {
                    GamersHubLogger.AddLog($"{entity.GameName} isimli oyun güncellendi.", LogType.Update);
                    return true;
                }
                else
                {
                    GamersHubLogger.AddLog($"{entity.GameName} isimli oyun güncellenemedi.", LogType.NonValidation);
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
