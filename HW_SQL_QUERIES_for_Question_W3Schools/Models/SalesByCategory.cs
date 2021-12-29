using System;
using System.Collections.Generic;

#nullable disable

namespace HW_SQL_QUERIES_for_Question_W3Schools.Models
{
    public partial class SalesByCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductSales { get; set; }
    }
}
