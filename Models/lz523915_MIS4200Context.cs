using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lz523915_MIS4200.Models
{
    public class lz523915_MIS4200Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public lz523915_MIS4200Context() : base("name=lz523915_MIS4200Context")
        {
        }

        public System.Data.Entity.DbSet<lz523915_MIS4200.Models.Vet> Vets { get; set; }

        public System.Data.Entity.DbSet<lz523915_MIS4200.Models.Pet> Pets { get; set; }

        public System.Data.Entity.DbSet<lz523915_MIS4200.Models.Treatment> Treatments { get; set; }

        public System.Data.Entity.DbSet<lz523915_MIS4200.Models.VisitDetail> VisitDetails { get; set; }
    }
}
