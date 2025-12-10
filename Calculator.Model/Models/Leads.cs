using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Models
{
    public class Leads
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Remarks { get; set; }
        public string message { get; set; }
    }

    public class ICreateLead
    {
        public string FullName { get; set; }
        public string Remarks { get; set; }
    }

    public class SystemResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public Leads data { get; set; }
    }
}

