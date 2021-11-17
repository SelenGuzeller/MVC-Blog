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
    public class MemberLoginManager : IMemberLoginService
    {
        IMemberDal _memberDal;

        public MemberLoginManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public void AddMember(Member member)
        {
             _memberDal.Insert(member);
        }

        public Member GetMember(string username, string password)
        {
            return _memberDal.Get(x => x.MemberMail == username && x.MemberPassword == password);
        }
    }
}
