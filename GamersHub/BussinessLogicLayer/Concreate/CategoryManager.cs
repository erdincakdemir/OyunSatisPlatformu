using BussinessLogicLayer.Abstract;
using Core.BLL.Logger;
using DataAccessLayer.Abstract;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicLayer.Concreate
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDal;
        public CategoryManager(ICategoryDAL dAL)
        {
            _categoryDal = dAL;
        }

        public bool Add(Category entity)
        {
            try
            {
               bool result = _categoryDal.Add(entity);
                if (result == true)
                {
                    GamersHubLogger.AddLog($"{entity.CategoryName} isimli yeni kategori eklendi.", LogType.Insert);
                    return true;
                }
                else
                {
                    GamersHubLogger.AddLog($"{entity.CategoryName} isimli yeni kategori eklenemedi.", LogType.NonValidation);
                    return false;
                }
            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return false;
            }
        }

        public bool Delete(Category entity)
        {
            try
            {
                bool result = _categoryDal.Delete(entity);
                if (result == true)
                {
                    GamersHubLogger.AddLog($"{entity.CategoryName} isimli kategori silindi!", LogType.Delete);
                    return true;
                }
                else
                {
                    GamersHubLogger.AddLog($"{entity.CategoryName} isimli kategori silinemedi!", LogType.NotFound);
                    return false;
                }
            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return false;

            }
        }

        public Category Get(int id)
        {
            try
            {
                return _categoryDal.Get(id);
               
            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return null;

            }
        }

        public IEnumerable<Category> Get()
        {
            try
            {
                return _categoryDal.Get();

            }
            catch (Exception e)
            {

                GamersHubLogger.AddLog(e.Message, LogType.Error);
                return null;

            }
        }

        public bool Update(Category entity)
        {
            try
            {
                bool result = _categoryDal.Update(entity);
                if (result == true)
                {
                    GamersHubLogger.AddLog($"{entity.CategoryName} isimli kategori güncellendi!", LogType.Update);
                    return true;
                }
                else
                {
                    GamersHubLogger.AddLog($"{entity.CategoryName} isimli kategori güncelenemedi!", LogType.NonValidation);
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
