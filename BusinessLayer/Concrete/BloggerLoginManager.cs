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
   public class BloggerLoginManager:IBloggerLoginService
    {
        IBloggerDal _bloggerDal;

        public BloggerLoginManager(IBloggerDal bloggerDal)
        {
            _bloggerDal = bloggerDal;
        }

        public Blogger GetBlogger(string username, string password)
        {
            return _bloggerDal.Get(x => x.BloggerMail == username && x.BloggerPassword == password);
        }
    }
}
