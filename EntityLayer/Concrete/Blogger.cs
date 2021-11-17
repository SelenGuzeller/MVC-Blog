using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blogger
    {
        [Key]
        public int BloggerID { get; set; }
        [StringLength(50)]
        public string BloggerName { get; set; }
        [StringLength(50)]
        public string BloggerSurName { get; set; }
        [StringLength(250)]
        public string BloggerImage { get; set; }
        [StringLength(100)]
        public string BloggerAbout { get; set; }
        [StringLength(200)]
        public string BloggerMail { get; set; }
        [StringLength(200)]
        public string BloggerPassword { get; set; }
        [StringLength(50)]

        public ICollection<Heading> Headings { get; set; }

    }
}
