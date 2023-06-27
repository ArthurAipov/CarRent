using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DataBase
{
    public partial class Client
    {
        public List<Pass> PassList
        {
            get
            {
                var list = GlobalSettings.DB.Pass.Where(u => u.ClientId == Id).ToList();
                return list;
            }
        }
    }
}
