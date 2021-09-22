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
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Shippers>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Shippers)
                .HasForeignKey(e => e.ShipVia);

        }

          public override int SaveChanges()
         {
            try
             {
                 return base.SaveChanges();
             }
             catch (DbEntityValidationException ex)
             {
                 var errorMessages = ex.EntityValidationErrors
                         .SelectMany(x => x.ValidationErrors)
                         .Select(x => x.ErrorMessage);


                 var fullErrorMessage = string.Join("\n", errorMessages);
                 throw new DbEntityValidationException(fullErrorMessage, ex.EntityValidationErrors);
             }


         }
    }
}
