using System;
using System.Collections.Generic;

#nullable disable

namespace HW_SQL_QUERIES_for_Question_W3Schools.Models
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
