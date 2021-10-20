using SmartGridService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGridService.Repository.Interfaces
{
    public interface IPlanRadaRepository
    {
        IQueryable<PlanRada> SortByColumn(string columnName);
        void AddPlanRada(PlanRada planRada);
    }
}
