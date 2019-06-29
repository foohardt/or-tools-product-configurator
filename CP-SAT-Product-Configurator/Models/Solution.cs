using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP_SAT_Product_Configurator.Models
{
    public class Solution
    {
        public string Identifier { get; set; }
        public float State { get; set; }

        public override string ToString()
        {
            return Identifier + " " + State;
        }
    }
}
