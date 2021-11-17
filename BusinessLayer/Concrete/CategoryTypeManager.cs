using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryTypeManager : ICategoryTypeService
    {
        ICategoryTypeDal _categoryTypeDal;

        public CategoryTypeManager(ICategoryTypeDal categoryTypeDal)
        {
            _categoryTypeDal = categoryTypeDal;
        }

        public void CategoryTypeAdd(CategoryType categoryType)
        {
            _categoryTypeDal.Insert(categoryType);
        }

        public void CategoryTypeDelete(CategoryType categoryType)
        {
            _categoryTypeDal.Delete(categoryType);
        }

        public void CategoryTypeUpdate(CategoryType categoryType)
        {
            _categoryTypeDal.Update(categoryType);
        }

        public CategoryType GetByID(int id)
        {
            return _categoryTypeDal.Get(x => x.TypeID == id);
        }

        public List<CategoryType> GetList()
        {
            return _categoryTypeDal.List();
        }

        //public CategoryType GetListByCategoryID(int id)
        //{
        //    return _categoryTypeDal.Get(x => x.Category.CategoryID == id);
        //}
    }
}
