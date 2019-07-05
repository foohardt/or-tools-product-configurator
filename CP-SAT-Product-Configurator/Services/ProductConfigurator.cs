using System;
using System.Collections.Generic;
using System.Linq;
using Google.OrTools.Sat;
using CP_SAT_Product_Configurator.Models;

namespace CP_SAT_Product_Configurator.Services
{
    public enum EngineType
    {
        Gas,
        Electric
    }
    public enum Category
    {
        Compact,
        Sedan,
        Suv,
        Sport
    }
    public class ProductConfigurator
    {
        private readonly EngineService _engineService;
        private readonly GearService _gearService;
        private readonly WheelsService _wheelsService;
        private readonly EquipmentService _equipmentService;

        private List<Engine> feasible_engines_ = new List<Engine>();
        private List<Gear> feasible_gears_ = new List<Gear>();
        private List<Wheels> feasible_wheels_ = new List<Wheels>();
        private List<Equipment> feasible_equipment_ = new List<Equipment>();

        public ProductConfigurator(EngineService engineService,
                                            GearService gearService,
                                            WheelsService wheelsService,
                                            EquipmentService equipmentService)
        {
            _engineService = engineService;
            _gearService = gearService;
            _wheelsService = wheelsService;
            _equipmentService = equipmentService;
        }

        public List<Engine> FeasibleEninges()
        {
            return feasible_engines_;
        }

        public List<Gear> FeasibleGears()
        {
            return feasible_gears_;
        }

        public List<Wheels> FeasibleWheels()
        {
            return feasible_wheels_;
        }

        public List<Equipment> FeasibleEquipment()
        {
            return feasible_equipment_;
        }

        public Product ConfigureProduct(EngineType engine, Category category)
        {
            this.ConfigureFirstDomain(engine);
            this.ConfigureSecondDomain(engine);
            this.ConfigureThirdDomain(category);

            var engines = this.FeasibleEninges();
            var gears = this.FeasibleGears();
            var wheels = this.FeasibleWheels();
            var equipment = this.FeasibleEquipment();

            Product product = new Product(engines, gears, wheels, equipment);

            return product;
        }

        // Configuration for engine / gears combinations
        public void ConfigureFirstDomain(EngineType engine)
        {
            Console.WriteLine("Engine / Gears");
            // Create model
            CpModel model = new CpModel();

            IntVar gas = model.NewBoolVar("gas");
            IntVar electric = model.NewBoolVar("electric");

            IntVar manual = model.NewBoolVar("manual");
            IntVar automatic = model.NewBoolVar("automatic");

            model.AddBoolXor(new[] { electric, gas });
            model.AddBoolOr(new[] { manual, automatic });
            model.Add(electric != manual);

            // Instantiate Solver
            CpSolver solver = new CpSolver();

            // Create SolutionPrinter as callback method
            SolutionPrinter cb =
            new SolutionPrinter(new IntVar[] { gas, electric, manual, automatic });

            solver.SearchAllSolutions(model, cb);
            Console.WriteLine(String.Format("Number of solutions found: {0}",
                    cb.SolutionCount()));

            var firstDomain = cb.FeasibleSolutions();
            var engines = _engineService.Get();
            var gears = _gearService.Get();

            string gearType = null; ;
            string manualGear = null;
            string automaticGear = null;

            if (engine == EngineType.Gas)
            {
                var index = firstDomain.FindIndex(x => x.Identifier == gas.ShortString() && x.State == 1);

                foreach (var s in firstDomain)
                {
                    if (firstDomain[index + 2].State == 1 && firstDomain[index + 3].State == 1)
                    {
                        manualGear = firstDomain[index + 2].Identifier;
                        automaticGear = firstDomain[index + 3].Identifier;
                    }
                }

                List<Gear> feasibleGears = gears.FindAll(x => x.type == manualGear || x.type == automaticGear);
                List<Engine> feasibleEngines = engines.FindAll(x => x.type == gas.ShortString());

                feasible_engines_ = feasibleEngines;
                feasible_gears_ = feasibleGears;
            }

            if (engine == EngineType.Electric)
            {
                var index = firstDomain.FindIndex(x => x.Identifier == electric.ShortString() && x.State == 1);

                if (firstDomain[index + 2].State == 1)
                {
                    gearType = firstDomain[index + 2].Identifier;
                }

                List<Gear> feasibleGears = gears.FindAll(x => x.type == gearType);
                List<Engine> feasibleEngines = engines.FindAll(x => x.type == electric.ShortString());

                feasible_engines_ = feasibleEngines;
                feasible_gears_ = feasibleGears;
            }
        }

        // Configuration for engine / wheels combinations
        public void ConfigureSecondDomain(EngineType engine)
        {
            Console.WriteLine("Engine / Wheels");
            CpModel model = new CpModel();

            IntVar gas = model.NewBoolVar("gas");
            IntVar electric = model.NewBoolVar("electric");

            IntVar w0 = model.NewBoolVar("90/45_17'");
            IntVar w1 = model.NewBoolVar("160/45 12'");
            IntVar w2 = model.NewBoolVar("165/55 15'");
            IntVar w3 = model.NewBoolVar("195/65 16'");
            IntVar w4 = model.NewBoolVar("255/65 17'");
            IntVar w5 = model.NewBoolVar("300/70 20'");
            IntVar w6 = model.NewBoolVar("325/65 24'");

            model.AddBoolXor(new[] { gas, electric });

            model.Add(electric != w1);
            model.Add(electric != w2);
            model.Add(electric != w3);
            model.Add(electric != w4);
            model.Add(electric != w5);
            model.Add(electric != w6);

            model.Add(gas != w0);

            CpSolver solver = new CpSolver();

            SolutionPrinter cb =
            new SolutionPrinter(new IntVar[] { gas, electric,
                                               w0, w1, w2, w3, w4, w5, w6 });
            Console.WriteLine(String.Format("Number of solutions found: {0}",
                                cb.SolutionCount()));

            solver.SearchAllSolutions(model, cb);

            var secondDomain = cb.FeasibleSolutions();
            var wheels = _wheelsService.Get();

            if (engine == EngineType.Gas)
            {
                List<Wheels> feasibleWheels = wheels.FindAll(x => x.type == gas.ShortString());
                feasible_wheels_ = feasibleWheels;
            }

            if (engine == EngineType.Electric)
            {
                List<Wheels> feasibleWheels = wheels.FindAll(x => x.type == electric.ShortString());
                feasible_wheels_ = feasibleWheels;
            }
        }

        // Configuration for category / extra equipment combinations
        public void ConfigureThirdDomain(Category category)
        {
            Console.WriteLine("Category / Extra Equipment");
            CpModel model = new CpModel();

            IntVar compact = model.NewBoolVar("compact");
            IntVar sedan = model.NewBoolVar("sedan");

            IntVar suv = model.NewBoolVar("suv");
            IntVar sport = model.NewBoolVar("sport");

            IntVar ce0 = model.NewBoolVar("toilet roll holder");
            IntVar ce1 = model.NewBoolVar("child seat");
            IntVar ce2 = model.NewBoolVar("wobble dachshund");
            IntVar ce3 = model.NewBoolVar("seat heating");

            IntVar se0 = model.NewBoolVar("keyless go");
            IntVar se1 = model.NewBoolVar("leather seats");
            IntVar se2 = model.NewBoolVar("electric windows");
            IntVar se3 = model.NewBoolVar("skylight");

            IntVar ue0 = model.NewBoolVar("champanger bar");
            IntVar ue1 = model.NewBoolVar("enginge snorkel");
            IntVar ue2 = model.NewBoolVar("ashtray");
            IntVar ue3 = model.NewBoolVar("extra tank");

            IntVar fe0 = model.NewBoolVar("sport steering wheel");
            IntVar fe1 = model.NewBoolVar("nitro injection");
            IntVar fe2 = model.NewBoolVar("ejector seat");
            IntVar fe3 = model.NewBoolVar("spoiler");

            model.AddBoolXor(new[] { compact, sedan, suv, sport });

            model.AddBoolAnd(new[] { ce0, ce1, ce2, ce3 }).OnlyEnforceIf(compact);
            model.AddBoolAnd(new[] { se0, se1, se2, se3 }).OnlyEnforceIf(sedan);
            model.AddBoolAnd(new[] { ue0, ue1, ue2, ue3 }).OnlyEnforceIf(suv);
            model.AddBoolAnd(new[] { fe0, fe1, fe2, fe3 }).OnlyEnforceIf(sport);

            model.AddBoolAnd(new[] { se0.Not(), se1.Not(), se2.Not(), se3.Not() }).OnlyEnforceIf(compact);
            model.AddBoolAnd(new[] { ue0.Not(), ue1.Not(), ue2.Not(), ue3.Not() }).OnlyEnforceIf(compact);
            model.AddBoolAnd(new[] { fe0.Not(), fe1.Not(), fe2.Not(), fe3.Not() }).OnlyEnforceIf(compact);

            model.AddBoolAnd(new[] { ce0.Not(), ce1.Not(), ce2.Not(), ce3.Not() }).OnlyEnforceIf(sedan);
            model.AddBoolAnd(new[] { ue0.Not(), ue1.Not(), ue2.Not(), ue3.Not() }).OnlyEnforceIf(sedan);
            model.AddBoolAnd(new[] { fe0.Not(), fe1.Not(), fe2.Not(), fe3.Not() }).OnlyEnforceIf(sedan);

            model.AddBoolAnd(new[] { ce0.Not(), ce1.Not(), ce2.Not(), ce3.Not() }).OnlyEnforceIf(suv);
            model.AddBoolAnd(new[] { se0.Not(), se1.Not(), se2.Not(), se3.Not() }).OnlyEnforceIf(suv);
            model.AddBoolAnd(new[] { fe0.Not(), fe1.Not(), fe2.Not(), fe3.Not() }).OnlyEnforceIf(suv);

            model.AddBoolAnd(new[] { ce0.Not(), ce1.Not(), ce2.Not(), ce3.Not() }).OnlyEnforceIf(sport);
            model.AddBoolAnd(new[] { se0.Not(), se1.Not(), se2.Not(), se3.Not() }).OnlyEnforceIf(sport);
            model.AddBoolAnd(new[] { ue0.Not(), ue1.Not(), ue2.Not(), ue3.Not() }).OnlyEnforceIf(sport);

            CpSolver solver = new CpSolver();

            SolutionPrinter cb =
            new SolutionPrinter(new IntVar[] { compact, sedan, suv, sport,
                                                        ce0, ce1, ce2, ce3,
                                                        se0, se1, se2, se3,
                                                        ue0, ue1, ue2, ue3,
                                                        fe0, fe1, fe2, fe3 });

            solver.SearchAllSolutions(model, cb);
            Console.WriteLine(String.Format("Number of solutions found: {0}",
                                            cb.SolutionCount()));

            var thirdDomain = cb.FeasibleSolutions();
            var equipment = _equipmentService.Get();

            List<Equipment> feasibleItems = new List<Equipment>();

            if (category == Category.Compact)
            {
                feasibleItems = equipment.FindAll(x => x.category == compact.ShortString());
                feasible_equipment_ = feasibleItems;
            }

            if (category == Category.Sedan)
            {
                feasibleItems = equipment.FindAll(x => x.category == sedan.ShortString());
                feasible_equipment_ = feasibleItems;
            }

            if (category == Category.Suv)
            {
                feasibleItems = equipment.FindAll(x => x.category == suv.ShortString());
                feasible_equipment_ = feasibleItems;
            }

            if (category == Category.Sport)
            {
                feasibleItems = equipment.FindAll(x => x.category == sport.ShortString());
                feasible_equipment_ = feasibleItems;
            }
        }
    }
}











