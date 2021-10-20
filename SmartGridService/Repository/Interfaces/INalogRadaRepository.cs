using SmartGridService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGridService.Repository.Interfaces
{
    public interface INalogRadaRepository
    {
        IQueryable<NalogRada> SortByColumn(string columnName);
        void AddNalogRada(NalogRada nalogRada);
    }
}
