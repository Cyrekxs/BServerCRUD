using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class UserEntity
    {
        public int UserID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
