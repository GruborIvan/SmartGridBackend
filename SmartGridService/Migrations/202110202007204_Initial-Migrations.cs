namespace SmartGridService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        IncidentType = c.Int(nullable: false),
                        Prioritet = c.Int(nullable: false),
                        Confirmed = c.Boolean(nullable: false),
                        Status = c.String(nullable: false, maxLength: 255),
                        ETA = c.DateTime(nullable: false),
                        ATA = c.DateTime(nullable: false),
                        ETR = c.DateTime(nullable: false),
                        VremeIncidenta = c.DateTime(nullable: false),
                        VremeRada = c.DateTime(nullable: false),
                        AffectedPeople = c.Int(nullable: false),
                        Pozivi = c.Int(nullable: false),
                        Voltage = c.Int(nullable: false),
                        IdKorisnika = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        EkipaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Opremas",
                c => new
                    {
                        IdOprema = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        OpremaType = c.String(nullable: false, maxLength: 255),
                        CoordinateX = c.Double(nullable: false),
                        CoordinateY = c.Double(nullable: false),
                        Address = c.String(nullable: false),
                        IncidentId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdOprema)
                .ForeignKey("dbo.Incidents", t => t.IncidentId)
                .Index(t => t.IncidentId);
            
            CreateTable(
                "dbo.NalogRadas",
                c => new
                    {
                        IdNaloga = c.String(nullable: false, maxLength: 128),
                        Type = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 255),
                        IdIncidenta = c.String(nullable: false, maxLength: 255),
                        Ulica = c.String(nullable: false, maxLength: 255),
                        PocetakRada = c.DateTime(nullable: false),
                        KrajRada = c.DateTime(nullable: false),
                        Svrha = c.String(nullable: false, maxLength: 255),
                        Beleske = c.String(nullable: false, maxLength: 255),
                        Hitno = c.Boolean(nullable: false),
                        Kompanija = c.String(nullable: false, maxLength: 255),
                        TelefonskiBroj = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(nullable: false, maxLength: 255),
                        CreatedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdNaloga);
            
            CreateTable(
                "dbo.Notifikacijas",
                c => new
                    {
                        IdPoruke = c.String(nullable: false, maxLength: 128),
                        IdKorisnika = c.String(nullable: false),
                        Sadrzaj = c.String(nullable: false),
                        Tip = c.Int(nullable: false),
                        Procitana = c.Boolean(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPoruke);
            
            CreateTable(
                "dbo.PlanRadas",
                c => new
                    {
                        IdPlana = c.String(nullable: false, maxLength: 128),
                        Type = c.Int(nullable: false),
                        IdNalogaRada = c.String(nullable: false, maxLength: 255),
                        Status = c.String(nullable: false, maxLength: 255),
                        IdIncidenta = c.String(nullable: false, maxLength: 255),
                        Ulica = c.String(nullable: false, maxLength: 255),
                        PocetakRada = c.DateTime(nullable: false),
                        KrajRada = c.DateTime(nullable: false),
                        Ekipa = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(nullable: false, maxLength: 255),
                        Svrha = c.String(nullable: false),
                        Detalji = c.String(nullable: false, maxLength: 255),
                        Beleske = c.String(nullable: false, maxLength: 255),
                        Kompanija = c.String(nullable: false, maxLength: 255),
                        TelefonskiBroj = c.String(nullable: false, maxLength: 255),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPlana);
            
            CreateTable(
                "dbo.Pozivs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Razlog = c.String(nullable: false, maxLength: 255),
                        Komentar = c.String(nullable: false, maxLength: 255),
                        Kvar = c.String(nullable: false, maxLength: 255),
                        UsernameKor = c.String(maxLength: 255),
                        IncidentId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resolutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cause = c.String(nullable: false),
                        SubCause = c.String(nullable: false),
                        Construction = c.String(nullable: false),
                        Material = c.String(nullable: false),
                        IncidentId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SafetyDocuments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Type = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(nullable: false, maxLength: 255),
                        IdPlanRada = c.String(nullable: false, maxLength: 255),
                        Ekipa = c.String(nullable: false, maxLength: 255),
                        Detalji = c.String(nullable: false, maxLength: 255),
                        Beleske = c.String(nullable: false, maxLength: 255),
                        TelefonskiBroj = c.String(nullable: false, maxLength: 255),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Opremas", "IncidentId", "dbo.Incidents");
            DropIndex("dbo.Opremas", new[] { "IncidentId" });
            DropTable("dbo.SafetyDocuments");
            DropTable("dbo.Resolutions");
            DropTable("dbo.Pozivs");
            DropTable("dbo.PlanRadas");
            DropTable("dbo.Notifikacijas");
            DropTable("dbo.NalogRadas");
            DropTable("dbo.Opremas");
            DropTable("dbo.Incidents");
        }
    }
}
