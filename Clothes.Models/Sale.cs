using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Models
{
    public class Sale
    {
        public Sale()
        {
        }

        public int Id { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual DailyReport DailyReport { get; set; }
    }
}
