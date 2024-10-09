using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models.DTO
{
    public class OrderDTO
    {
        public int? UserId { get; set; }

        public decimal? Total { get; set; }
    }
}
