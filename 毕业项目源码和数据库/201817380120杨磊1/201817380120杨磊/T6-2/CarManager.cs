using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T6_2
{
    public class CarManager
    {
        public List<Car> FindCar()
        {
            List<Car> list = new List<Car>()
            {
                new Car(){CarID=1,Carmame="奥迪", Brand="奥迪A3",Picture="ada31.jpg"},
                new Car(){CarID=1,Carmame="宝马",Brand="宝马A3",Picture="bma31.jpg"}
            };
            return list;
        }
    }
}