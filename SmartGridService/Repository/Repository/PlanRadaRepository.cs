using SmartGridService.Models;
using SmartGridService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridService.Repository.Repository
{
    public class PlanRadaRepository : IPlanRadaRepository
    {
        SmartGridDbContext db;

        public PlanRadaRepository()
        {
            db = new SmartGridDbContext();
        }

        public void AddPlanRada(PlanRada planRada)
        {
            db.PlanRada.Add(planRada);
            db.SaveChangesAsync();
        }

        public IQueryable<PlanRada> SortByColumn(string columnName)
        {

            switch (columnName)
            {
                case "ID":
                    return db.PlanRada.OrderBy(x => x.IdPlana);
                case "Tip":
                    return db.PlanRada.OrderBy(x => x.Type);
                case "CreatedTime":
                    return db.PlanRada.OrderBy(x => x.CreatedOn);
                case "StartDate":
                    return db.PlanRada.OrderBy(x => x.PocetakRada);
                case "EndDate":
                    return db.PlanRada.OrderBy(x => x.KrajRada);
                default:
                    return db.PlanRada;
            }

        }

    }
}