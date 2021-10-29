using SmartGridService.Models;
using SmartGridService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridService.Repository.Repository
{
    public class DashboardDataRepository : IDashboardDataRepository
    {
        SmartGridDbContext db;

        public DashboardDataRepository()
        {
            db = new SmartGridDbContext();
        }

        public DashboardData CalculateDashboardData()
        {
            return new DashboardData()
            {
                MyIncidentsDrafts = 1,
                MyIncidentsCancelled = 0,
                MyIncidentsExecuting = 1,
                MyIncidentsCompleted = 2,

                MyWorkPlansDrafts = 1,
                MyWorkPlansCancelled = 0,
                MyWorkPlansExecuting = 3,
                MyWorkPlansCompleted = 4,

                MySafetyDocumentsDrafts = 2,
                MySafetyDocumentsCancelled = 0,
                MySafetyDocumentsExecuting = 1,
                MySafetyDocumentsCompleted = 4,

                IncidentsDrafts = 1,
                IncidentsCancelled = 0,
                IncidentsExecuting = 2,
                IncidentsCompleted = 4,

                DocumentsDrafts = 2,
                DocumentsCancelled = 1,
                DocumentsExecuting = 1,
                DocumentsCompleted = 0
            };
        }
    }
}