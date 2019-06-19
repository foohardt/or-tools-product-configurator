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
            this.ConfigureFirstDomain(1); ;
        }

        public void ConfigureFirstDomain(int engineType)
        {
            // Create model
            CpModel model = new CpModel();

            // Creates variables.
            int numEngines = 2;
            int numGears = 2;

            int idManualGear = 0;

            IntVar allEngines = model.NewIntVar(0, numEngines - 1, "engines");
            IntVar allGears = model.NewIntVar(0, numGears - 1, "gears");

            IntVar gasEngine = model.NewConstant(0, "gas");
            IntVar electroEngine = model.NewConstant(1, "electro");

            IntVar gasAvailableGears = model.NewIntVar(0, numGears - 1, "gasAvailableGears");
            IntVar electroAvailableGears = model.NewConstant(1, "electroAvailableGears");
    
            model.Add(electroEngine != idManualGear);

            // Creates a solver and solves the model.
            CpSolver solver = new CpSolver();
            VarArraySolutionPrinter cb =
                new VarArraySolutionPrinter(new IntVar[] { gasAvailableGears, electroAvailableGears });
            solver.SearchAllSolutions(model, cb);

            Console.WriteLine(String.Format("Number of solutions found: {0}",
                                            cb.SolutionCount()));                                  
        }
    }
}











