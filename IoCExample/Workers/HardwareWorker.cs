using System;

namespace IoCExample.Workers
{
    public class HardwareWorker : Worker
    {
        public override void Decorate()
        {
            Console.WriteLine("Decorate window and balcony door...");
        }
    }
}