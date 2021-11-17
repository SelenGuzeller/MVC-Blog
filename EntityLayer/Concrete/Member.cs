using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }
        [StringLength(50)]
        public string MemberName { get; set; }
        [StringLength(50)]
        public string MemberSurName { get; set; }
        [StringLength(250)]
        public string MemberImage { get; set; }
        [StringLength(200)]
        public string MemberMail { get; set; }
        [StringLength(200)]
        public string MemberPassword { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
