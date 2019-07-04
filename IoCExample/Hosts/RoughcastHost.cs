using System;
using IoCExample.Workers;

namespace IoCExample.Hosts
{
    /// <summary>
    /// Tightly coupled class
    /// </summary>
    public class RoughcastHost
    {
        public RoughcastHost()
        {
            Console.WriteLine("I'm the host of roughcast house...");
        }

        private void BuyARoughcastHouse()
        {
            Console.WriteLine("I bought a roughcast house...");
        }

        private void Decorate()
        {
            Console.WriteLine("I want to decorate my house...");
            
            var hardwareWorker = FindHardwareWorker();
            hardwareWorker.Decorate();
            
            var floorFinisher = FindFloorFinisher();
            floorFinisher.Decorate();

            var kitchenAndBathWorker = FindKitchenAndBathWorker();
            kitchenAndBathWorker.Decorate();

            var paperhanger = FindPaperhanger();
            paperhanger.Decorate();
            
            var painter = FindPainter();
            painter.Decorate();

            Console.WriteLine("Decorate house done...");
        }

        public void ToLiveInNewHouse()
        {
            BuyARoughcastHouse();
            Decorate();
            
            Console.WriteLine("Now I can live in new house...");
        }

        private HardwareWorker FindHardwareWorker()
        {
            Console.WriteLine("Find HardwareWorker...");
            return new HardwareWorker();
        }

        private KitchenAndBathWorker FindKitchenAndBathWorker()
        {
            Console.WriteLine("Find KitchenAndBathWorker...");
            return new KitchenAndBathWorker();
        }

        private Painter FindPainter()
        {
            Console.WriteLine("Find Painter...");
            return new Painter();
        }

        private Paperhanger FindPaperhanger()
        {
            Console.WriteLine("Find Paperhanger...");
            return new Paperhanger();
        }

        private FloorFinisher FindFloorFinisher()
        {
            Console.WriteLine("Find FloorFinisher...");
            return new FloorFinisher();
        }
    }
}
