using Calculator.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculations.Business
{
    public interface ILeads
    {
         Task<IEnumerable<Leads>> GetLeads();
         Task<int> Create(ICreateLead lead);

        Task<int> Delete(Guid id);
    }
}
