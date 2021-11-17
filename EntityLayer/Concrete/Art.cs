using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Art
    {
        [Key]
        public int ArtID { get; set; }
       
        public string ArtName { get; set; }
       
        public string ArtDescription { get; set; }
        public string ArtImage { get; set; }
        public bool ArtStatus { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int TypeID { get; set; }
        public virtual CategoryType CategoryType { get; set; }
        public ICollection<Content> Contents { get; set; }


    }
}
