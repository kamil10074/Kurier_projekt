using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Kurier_projekt.Models;

namespace Kurier_projekt.DAL
{
    public class KurierContext : DbContext
    {
        public KurierContext() : base("KurierContext")
        {
        }
        public DbSet<Kurierzy> Kurierzy { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}