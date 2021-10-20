using SmartGridService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGridService.Repository.Interfaces
{
    public interface IIncidentRepository
    {
        IQueryable<Incident> GetIncidenti();
        IQueryable<Incident> GetMyIncidenti(string username);
        Incident GetIncidentById(string id);
        void AddIncident(Incident incident);
        void UpdateIncident(Incident incident);
        IQueryable<Incident> SortByColumn(string columnName);
        void AssignCrewToIncident(int crewId, string incidentId);
    }
}
