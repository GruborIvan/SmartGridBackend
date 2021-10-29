using SmartGridService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridService.Repository.Interfaces
{
    public interface IPrioritetRepository
    {
        void AddPrioritet(Prioritet prioritet);
        Prioritet GetPrioritetForStreet(string streetName);
    }
}