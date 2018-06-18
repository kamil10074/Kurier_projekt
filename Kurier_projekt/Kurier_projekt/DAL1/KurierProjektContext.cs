using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Kurier_projekt.Models;
namespace Kurier_projekt.DAL1
{
    public class KurierProjektContext : DbContext
    {
        public KurierProjektContext() : base("UniversityContext")
        {
        }
        public DbSet<Kurierzy> Dodajkuriera { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}