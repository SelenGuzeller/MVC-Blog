using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryTypeService
    {
        List<CategoryType> GetList();
        void CategoryTypeAdd(CategoryType categoryType);
        CategoryType GetByID(int id);
        //CategoryType GetListByCategoryID(int id);
        void CategoryTypeDelete(CategoryType categoryType);
        void CategoryTypeUpdate(CategoryType categoryType);
    }
}
