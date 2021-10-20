using SmartGridService.Models;
using SmartGridService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridService.Repository.Repository
{
    public class SafetyDocumentsRepository : ISafetyDocumentRepository
    {
        SmartGridDbContext db;

        public SafetyDocumentsRepository()
        {
            db = new SmartGridDbContext();
        }

        public void AddSafetyDocument(SafetyDocument safetyDocument)
        {
            db.SafetyDocuments.Add(safetyDocument);
            db.SaveChangesAsync();
        }

        public SafetyDocument GetById(int id)
        {
            return db.SafetyDocuments.Find(id);
        }

        public IQueryable<SafetyDocument> SortByColumn(string columnName)
        {
            switch (columnName)
            {
                case "ID":
                    return db.SafetyDocuments.OrderBy(x => x.Id);
                case "PhoneNumber":
                    return db.SafetyDocuments.OrderBy(x => x.TelefonskiBroj);
                case "Tip":
                    return db.SafetyDocuments.OrderBy(x => x.Type);
                case "CreatedTime":
                    return db.SafetyDocuments.OrderBy(x => x.CreatedOn);
                default:
                    return db.SafetyDocuments;
            }
        }
    }
}