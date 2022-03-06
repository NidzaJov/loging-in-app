using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogingInApp.Classes
{
    class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Role()
        {

        }

        public int SaveRole(string name)
        {
            return 0;
        }

        public IList<Role> GetAllRoles()
        {
            return new List<Role> ();
        }

    }
}
