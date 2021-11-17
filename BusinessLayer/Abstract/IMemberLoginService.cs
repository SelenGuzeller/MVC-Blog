using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMemberLoginService
    {
        Member GetMember(string username, string password);
        void AddMember(Member member);
    }
}
