using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DataBase
{
    public partial class Car
    {
        public string CarModelType
        {
            get
            {
                var modelType = Model.ModelType.Name;
                return modelType;
            }
        }
        public string CarModelName
        {
            get
            {
                var carModelName = Model.Name;
                return carModelName;
            }
        }




    }
}
