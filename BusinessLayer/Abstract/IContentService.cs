using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(String p);
        List<Content> GetList();
        List<Content> GetListByMember(int id);
        List<Content> GetListByHeadingID(int id);
        List<Content> GetListByArtID(int id);
        void ContentAdd(Content content);
        Content GetByID(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
        Content GetByArtID(int id);
        Content GetByHeadingID(int id);
    }
}
