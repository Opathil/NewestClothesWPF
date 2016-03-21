using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Models
{
    public class DailyReport
    {
        private ICollection<Sale> sales;

        public DailyReport()
        {
            this.sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }


    }
}
