using CarRent.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public static class GlobalSettings
    {
        public static CarRentEntities DB = new CarRentEntities();
        public static Client MainClient;
    }
}
