using System;
using System.Collections.Generic;
using Google.OrTools.Sat;
using CP_SAT_Product_Configurator.Models;

namespace CP_SAT_Product_Configurator.Services
{
    public class SolutionPrinter : CpSolverSolutionCallback
    {
        private int solution_count_;
        private IntVar[] variables_;
        private List<Solution> feasible_solutions_ = new List<Solution>();

        public SolutionPrinter(IntVar[] variables)
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

                    feasible_solutions_.Add(new Solution() { Identifier = v.ShortString(), State = Value(v) });
                }

                solution_count_++;
            }
        }

        public List<Solution> FeasibleSolutions()
        {
            return feasible_solutions_;
        }

        public int SolutionCount()
        {
            return solution_count_;
        }
    }
}
