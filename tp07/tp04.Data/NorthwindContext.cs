using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using tp04.Entities;

namespace tp04.Data
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base("name=NorthwindConnection")
        {
        }
    public virtual DbSet<Categories> Categories { get; set; }
      
        public virtual DbSet<Shippers> Shippers { get; set; }
      
    }
}
