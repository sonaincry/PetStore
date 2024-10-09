using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models.DTO
{
    public class UserUpdateDTO
    {
        public string? FullName { get; set; }

        public string? Address { get; set; }

        public int? Phone { get; set; }
    }       
}
