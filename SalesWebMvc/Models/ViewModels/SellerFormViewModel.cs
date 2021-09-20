using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModel //Model composto que posso colocar o que eu quiser
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
