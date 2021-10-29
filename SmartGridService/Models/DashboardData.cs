using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridService.Models
{
    public class DashboardData
    {
        // My incidents
        public int MyIncidentsDrafts { get; set; }
        public int MyIncidentsCancelled { get; set; }
        public int MyIncidentsExecuting { get; set; }
        public int MyIncidentsCompleted { get; set; }

        // MyWorkPlans
        public int MyWorkPlansDrafts { get; set; }
        public int MyWorkPlansCancelled { get; set; }
        public int MyWorkPlansExecuting { get; set; }
        public int MyWorkPlansCompleted { get; set; }

        // MySafetyDocuments
        public int MySafetyDocumentsDrafts { get; set; }
        public int MySafetyDocumentsCancelled { get; set; }
        public int MySafetyDocumentsExecuting { get; set; }
        public int MySafetyDocumentsCompleted { get; set; }

        // Incidents
        public int IncidentsDrafts { get; set; }
        public int IncidentsCancelled { get; set; }
        public int IncidentsExecuting { get; set; }
        public int IncidentsCompleted { get; set; }

        // Documents
        public int DocumentsDrafts { get; set; }
        public int DocumentsCancelled { get; set; }
        public int DocumentsExecuting { get; set; }
        public int DocumentsCompleted { get; set; }

    }
}