using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Art> Arts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blogger> Bloggers { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
