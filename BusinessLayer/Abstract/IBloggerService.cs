using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBloggerService
    {
        List<Blogger> GetList();
        void BloggerAdd(Blogger blogger);
        void BloggerDelete(Blogger blogger);
        void BloggerUpdate(Blogger blogger);
        Blogger GetByID(int id);

    }
}
