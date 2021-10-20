using SmartGridService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGridService.Repository.Interfaces
{
    public interface ISafetyDocumentRepository
    {
        IQueryable<SafetyDocument> SortByColumn(string columnName);

        SafetyDocument GetById(int id);
        void AddSafetyDocument(SafetyDocument safetyDocument);
    }
}
