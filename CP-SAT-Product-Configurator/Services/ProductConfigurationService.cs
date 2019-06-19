using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.OrTools.Sat;

namespace CP_SAT_Product_Configurator.Services
{
    public class VarArraySolutionPrinter : CpSolverSolutionCallback
    {
        public VarArraySolutionPrinter(IntVar[] variables)
        {
            variables_ = variables;
        }

        public override void OnSolutionCallback()
        {
            {
                Console.WriteLine(String.Format("Solution #{0}: time = {1:F2} s",
                                                solution_count_, WallTime()));
                foreach (IntVar v in variables_)
                {
                    Console.WriteLine(
                        String.Format("  {0} = {1}", v.ShortString(), Value(v)));
                }
                solution_count_++;
            }
        }

        public int SolutionCount()
        {
            return solution_count_;
        }

        private int solution_count_;
        private IntVar[] variables_;
    }
    public class ProductConfigurationService
    {
        public void ConfigureProduct()
        {
            Console.WriteLine("Configuration started.");
            // Create model.
            CpModel model = new CpModel();

            // Creates variables.
            int num_engines = 3;
            int num_gears = 2;

            int id_electro = 2;
            int id_manual = 0;

            IntVar engines = model.NewIntVar(0, num_engines - 1, "engines");
            IntVar gears = model.NewIntVar(0, num_gears - 1, "gears");

            IntVar electro = model.NewIntVar(id_electro, id_electro, "id_electro");
            IntVar manual = model.NewIntVar(id_manual, id_manual, "id_manual");

            Console.WriteLine("engines: " + engines);
            Console.WriteLine("gears: " + gears);

            // Adds constraints
            model.Add(electro != manual);



            // Creates a solver and solves the model.
            CpSolver solver = new CpSolver();
            VarArraySolutionPrinter cb =
                new VarArraySolutionPrinter(new IntVar[] { engines, gears });
            solver.SearchAllSolutions(model, cb);

            Console.WriteLine(String.Format("Number of solutions found: {0}",
                                            cb.SolutionCount()));
        }
    }
}











