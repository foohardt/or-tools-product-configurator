using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP_SAT_Product_Configurator.Models
{
    public class Product
    {
        public List<Engine> Engines { get; set; }
        public List<Gear> Gears { get; set; }
        public List<Wheels> Wheels { get; set; }
        public List<Equipment> Equipment { get; set; }

        public Product(List<Engine> eninges, List<Gear> gears, List<Wheels> wheels, List<Equipment> equipment)
        {
            Engines = eninges;
            Gears = gears;
            Wheels = wheels;
            Equipment = equipment;
        }
    }
}
