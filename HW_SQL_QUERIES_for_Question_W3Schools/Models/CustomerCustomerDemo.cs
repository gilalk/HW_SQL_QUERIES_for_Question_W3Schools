using System;
using System.Collections.Generic;

#nullable disable

namespace HW_SQL_QUERIES_for_Question_W3Schools.Models
{
    public partial class CustomerCustomerDemo
    {
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerDemographic CustomerType { get; set; }
    }
}
