using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IoCExample.Workers;

namespace IoCExample.ThirdParty
{
    /// <summary>
    /// Abstract Factory
    /// </summary>
    public class HardcoverHouseDeveloper : IWorking
    {
        private readonly List<Worker> _workerTeam = new List<Worker>();

        public HardcoverHouseDeveloper()
        {
            Assembly
                .GetAssembly(typeof(Worker))
                .GetTypes()
                .Where(type => type.IsClass)
                .Where(type => !type.IsAbstract)
                .Where(type => type.IsSubclassOf(typeof(Worker)))
                .ToList()
                .ForEach(workerType => _workerTeam.Add((Worker)Activator.CreateInstance(workerType)));
        }

        public void Decorate()
        {
            Console.WriteLine("Property developer start Decorating...");
            Parallel.ForEach(_workerTeam, worker => worker.Decorate());
            Console.WriteLine("Decorate house done...");
        }
    }
}