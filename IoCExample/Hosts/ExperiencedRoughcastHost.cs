using System;
using IoCExample.ThirdParty;

namespace IoCExample.Hosts
{
    /// <summary>
    /// Try to use IoC principle to move dependency creating out of this class.
    /// </summary>
    public class ExperiencedRoughcastHost
    {
        public ExperiencedRoughcastHost()
        {
            Console.WriteLine("I'm the experienced host of roughcast house...");
        }

        private void BuyARoughcastHouse()
        {
            Console.WriteLine("I bought a roughcast house...");
        }

        private void Decorate()
        {
            Console.WriteLine("I want to decorate my house...");
            Console.WriteLine("I call the labor contractor...");
            
            var hardwareWorker = LaborContractor.RecommendWorker("Hardware");
            hardwareWorker.Decorate();
            
            var floorFinisher = LaborContractor.RecommendWorker("Floor");
            floorFinisher.Decorate();

            var kitchenAndBathWorker = LaborContractor.RecommendWorker("KitchenAndBath");
            kitchenAndBathWorker.Decorate();

            var paperhanger = LaborContractor.RecommendWorker("Wall");
            paperhanger.Decorate();
            
            var painter = LaborContractor.RecommendWorker("Paint");
            painter.Decorate();

            Console.WriteLine("Decorate house done...");
        }
        
        public void ToLiveInNewHouse()
        {
            BuyARoughcastHouse();
            Decorate();
            
            Console.WriteLine("Now I can live in new house...");
        }
    }
}