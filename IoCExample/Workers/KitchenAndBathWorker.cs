using System;

namespace IoCExample.Workers
{
    public class KitchenAndBathWorker : Worker
    {
        public override void Decorate()
        {
            Console.WriteLine("Decorate kitchen and bath...");
        }
    }
}