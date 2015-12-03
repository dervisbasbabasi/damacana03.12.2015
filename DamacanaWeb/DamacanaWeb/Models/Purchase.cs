using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamacanaWeb.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId{ get; set; }
        public DateTime CreatedOn{ get; set; }
        public decimal TotalPrice { get; set; }
        public virtual ICollection<Product> Products { get; set; }


    }
}
