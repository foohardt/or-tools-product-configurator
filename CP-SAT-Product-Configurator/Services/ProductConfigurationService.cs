using System;
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

            this.ConfigureFirstDomain(0);
            Console.WriteLine("-------------------------------------");
            this.ConfigureFirstDomain(1);
            //  this.ConfigureSecondDomain(1);
            // Console.WriteLine("-------------------------------------");
            // this.ConfigureThirdDomain(0);
        }

        // Configuration for engine / gears combinations
        public void ConfigureFirstDomain(int engineType)
        {
            // Create model
            CpModel model = new CpModel();

            // Creates variables.
            int numGears = 2;
            int manualGear = 0;

            IntVar gasEngine = model.NewConstant(0, "gas");
            IntVar electroEngine = model.NewConstant(1, "electro");

            IntVar gasAvailableGears = model.NewIntVar(0, numGears - 1, "gasAvailableGears");
            IntVar electroAvailableGears = model.NewConstant(1, "electroAvailableGears");
    
            model.Add(electroEngine != manualGear);

            // Creates a solver and solves the model.
            CpSolver solver = new CpSolver();

            VarArraySolutionPrinter cb =
                new VarArraySolutionPrinter(new IntVar[] { gasEngine, gasAvailableGears,
                                                            electroEngine, electroAvailableGears });
            solver.SearchAllSolutions(model, cb);
            Console.WriteLine(String.Format("Number of solutions found: {0}",
                                            cb.SolutionCount()));

        }

        // Configuration for engine / wheels combinations
        public void ConfigureSecondDomain(int engineType)
        {
            CpModel model = new CpModel();

            int numWheels = 7;
            int idElectroWheels = 0;

            IntVar electroEngine = model.NewConstant(1, "electro");

            IntVar gasAvailableWheels = model.NewIntVar(1, numWheels - 1, "gasAvailableWheels");
            IntVar electroAvailableWheels = model.NewConstant(1, "electroAvailableWheels");

            model.Add(electroEngine != idElectroWheels);

            CpSolver solver = new CpSolver();
            VarArraySolutionPrinter cb =
                new VarArraySolutionPrinter(new IntVar[] {  gasAvailableWheels,  electroAvailableWheels });
            solver.SearchAllSolutions(model, cb);

            Console.WriteLine(String.Format("Number of solutions found: {0}",
                                            cb.SolutionCount()));
        }

        // Configuration for category / bodies combinations
        public void ConfigureThirdDomain(int categoryType)
        {
            CpModel model = new CpModel();

            int numBodies = 16;

            IntVar idCompact = model.NewConstant(0);

            IntVar compactAvailableBodies = model.NewIntVar(0, 3, "compactBodies");
            IntVar sedanAvailableBodies = model.NewIntVar(4, 7, "sedanAvailable");
            IntVar suvAvailableBodies = model.NewIntVar(8, 11, "suvAvailable");
            IntVar sportAvailableBodies = model.NewIntVar(12, 15, "sportAvailable");

            model.Add(idCompact != sedanAvailableBodies);
            model.Add(idCompact != suvAvailableBodies);
            model.Add(idCompact != sportAvailableBodies);

            CpSolver solver = new CpSolver();
            VarArraySolutionPrinter cb =
                new VarArraySolutionPrinter(new IntVar[] { compactAvailableBodies });
            solver.SearchAllSolutions(model, cb);

            Console.WriteLine(String.Format("Number of solutions found: {0}",
                                            cb.SolutionCount()));
        }
    }
}











