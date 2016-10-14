using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Metier
{
    public class Role
    {
        public int RoleId { get; set; }
        public string NomRole { get; set; }

        public ICollection<UserAccount> UserAccount { get; set; }
    }
}