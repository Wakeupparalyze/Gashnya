using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GashnyaLohotron
{
    public static class DB
    {
        private static User13Context _context;
        public static User13Context Instance
        {
            get
            {
                if (_context == null)
                    _context = new User13Context();
                return _context;
            }
        }
    }
}
