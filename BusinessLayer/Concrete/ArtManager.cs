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
    public class ArtManager : IArtService
    {
        IArtDal _artDal;

        public ArtManager(IArtDal artDal)
        {
            _artDal = artDal;
        }

        public void ArtAdd(Art art)
        {
            _artDal.Insert(art);
        }

        public void ArtDelete(Art art)
        {
            _artDal.Delete(art);
        }

        public void ArtUpdate(Art art)
        {
            _artDal.Update(art); ;
        }

        public List<Art> GetByCategoryID(int id)
        {
            return _artDal.List(x => x.CategoryID == id);
        }

        public Art GetByID(int id)
        {
            return _artDal.Get(x => x.ArtID == id);
        }

        public List<Art> GetByTypeID(int id, int typeId)
        {
            return _artDal.List(x => x.CategoryID == id && x.TypeID == typeId);
        }

        public List<Art> GetList()
        {
            return _artDal.List();
        }
    }
}
