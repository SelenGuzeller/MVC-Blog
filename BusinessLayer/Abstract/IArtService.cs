using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IArtService
    {
        List<Art> GetList();
        void ArtAdd(Art art);
        void ArtDelete(Art art);
        void ArtUpdate(Art art);
        Art GetByID(int id);
        List<Art> GetByCategoryID(int id);
        List<Art> GetByTypeID(int id, int typeId);
        
    }
}
