using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyManager.Shared.Models
{
    class Purchase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public int RentCost { get; set; }

        public int Income { get; set; }
    }
}
