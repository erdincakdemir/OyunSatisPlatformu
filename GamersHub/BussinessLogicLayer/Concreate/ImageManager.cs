using BussinessLogicLayer.Abstract;
using Core.BLL.Logger;
using DataAccessLayer.Abstract;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicLayer.Concreate
{
    public class ImageManager : IimageService
    {
        IimageDAL _imageDal;
        public ImageManager(IimageDAL dAL)
        {
            _imageDal = dAL;
        }

        public bool Add(Image entity)
        {
            try
            {
                bool result = _imageDal.Add(entity);
                if (result == true)
                {
                    GamersHubLogger.AddLog($"{entity.GameID} ıd değerine sahip oyuna yeni fotoğraf eklendi.", LogType.Insert);
                    return true;
                }
                else
                {
                    GamersHubLogger.AddLog($"{entity.GameID} ıd değerine sahip oyuna yeni fotoğraf eklenemedi.", LogType.NonValidation);
                    return false;
                }
            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return false;
            }
        }

        public bool Delete(Image entity)
        {
            try
            {
                bool result = _imageDal.Add(entity);
                if (result == true)
                {
                    GamersHubLogger.AddLog($"{entity.GameID} ıd değerine sahip oyunun {entity.Id} değerine sahip fotoğrafı silindi.", LogType.Delete);
                    return true;
                }
                else
                {
                    GamersHubLogger.AddLog($"{entity.GameID} ıd değerine sahip oyunun {entity.Id} değerine sahip fotoğrafı silinemedi.", LogType.NotFound);
                    return false;
                }
            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return false;
            }
        }

        public Image Get(int id)
        {
            try
            {
                return _imageDal.Get(id);

            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return null;

            }
        }

        public IEnumerable<Image> Get()
        {
            try
            {
                return _imageDal.Get();

            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return null;

            }
        }

        public bool Update(Image entity)
        {
            try
            {
                bool result = _imageDal.Add(entity);
                if (result == true)
                {
                    GamersHubLogger.AddLog($"{entity.GameID} ıd değerine sahip oyunun {entity.Id} değerine sahip fotoğrafı güncellendi.", LogType.Update);
                    return true;
                }
                else
                {
                    GamersHubLogger.AddLog($"{entity.GameID} ıd değerine sahip oyunun {entity.Id} değerine sahip fotoğrafı güncellendi.", LogType.NonValidation);
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
