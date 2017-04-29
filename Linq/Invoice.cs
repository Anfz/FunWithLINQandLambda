using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Invoice
    {
        public string InvoiceNumber { get; set; }
        public double InvoiceAmount { get; set; }
        public Contact Contact { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
    }
}
