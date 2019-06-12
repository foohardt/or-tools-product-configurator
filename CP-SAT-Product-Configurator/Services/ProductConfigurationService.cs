using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.OrTools.Sat;

namespace CP_SAT_Product_Configurator.Services
{
    public class ProductConfigurationService
    {
        public ProductConfigurationService()
        {

        }

        public string ConfigureProduct()
        {
            Console.WriteLine("Product configuration started.");
            // Create model
            CpModel model = new CpModel();

            // Create Variables with values 1, 2 and 3
            int num_vals = 3;

            IntVar x = model.NewIntVar(0, num_vals - 1, "x");
            IntVar y = model.NewIntVar(0, num_vals - 1, "y");
            IntVar z = model.NewIntVar(0, num_vals - 1, "z");

            // Create Constraint
            model.Add(x != y);

            // Call solver and asign status
            CpSolver solver = new CpSolver();
            CpSolverStatus status = solver.Solve(model);

            // Display feasible solution
                if (status == CpSolverStatus.Feasible)
                {
                    Console.WriteLine("x = " + solver.Value(x));
                    Console.WriteLine("x = " + solver.Value(y));
                    Console.WriteLine("x = " + solver.Value(z));
                }

            return null;
        }
    }
}









