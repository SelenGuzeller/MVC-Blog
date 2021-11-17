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
    public class BloggerManager : IBloggerService
    {
        IBloggerDal _bloggerDal;

        public BloggerManager(IBloggerDal bloggerDal)
        {
            _bloggerDal = bloggerDal;
        }

        public void BloggerAdd(Blogger blogger)
        {
            _bloggerDal.Insert(blogger);
        }

        public void BloggerDelete(Blogger blogger)
        {
            _bloggerDal.Delete(blogger);
        }

        public void BloggerUpdate(Blogger blogger)
        {
            _bloggerDal.Update(blogger);
        }

        public Blogger GetByID(int id)
        {
            return _bloggerDal.Get(x => x.BloggerID == id);
        }

        public List<Blogger> GetList()
        {
            return _bloggerDal.List();
        }
    }
}
