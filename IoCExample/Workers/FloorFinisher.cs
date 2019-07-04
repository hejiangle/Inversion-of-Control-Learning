using System;

namespace IoCExample.Workers
{
    public class FloorFinisher : Worker
    {
        public override void Decorate()
        {
            Console.WriteLine("Decorate floor...");
        }
    }
}