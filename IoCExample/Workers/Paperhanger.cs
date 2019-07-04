using System;

namespace IoCExample.Workers
{
    public class Paperhanger : Worker
    {
        public override void Decorate()
        {
            Console.WriteLine("Decorate wall...");
        }
    }
}