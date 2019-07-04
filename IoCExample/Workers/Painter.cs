using System;

namespace IoCExample.Workers
{
    public class Painter : Worker
    {
        public override void Decorate()
        {
            Console.WriteLine("Decorate door and kick line...");
        }
    }
}