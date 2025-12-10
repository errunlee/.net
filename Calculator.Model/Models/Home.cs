using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Models
{
    public class Home
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class HomePayload
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
