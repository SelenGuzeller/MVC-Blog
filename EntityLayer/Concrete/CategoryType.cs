using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CategoryType
    {
        [Key]
        public int TypeID { get; set; }
        [StringLength(50)]
        public string TypeName { get; set; }
        [StringLength(200)]
        public string TypeDescription { get; set; }
        public string TypeImage { get; set; }
        public bool TypeStatus { get; set; }
        //public int CategoryID { get; set; }
        //public virtual Category Category { get; set; }
        public ICollection<Art> Arts { get; set; }
    }
}
