using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartGridService.Models
{
    public class SmartGridDbContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<NalogRada> NaloziRada { get; set; }
        public DbSet<Notifikacija> Notifikacije { get; set; }
        public DbSet<Oprema> Oprema { get; set; }
        public DbSet<PlanRada> PlanRada { get; set; }
        public DbSet<Poziv> Pozivi { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }
        public DbSet<SafetyDocument> SafetyDocuments { get; set; }

        public SmartGridDbContext() : base("name=SmartGridContext")
        {

        }
    }
}