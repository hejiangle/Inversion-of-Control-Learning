using System;
using IoCExample.Hosts;

namespace IoCExample
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var roughcastHost = new RoughcastHost();
            roughcastHost.ToLiveInNewHouse();
            
            Console.WriteLine("***************************");
            
            var smartRoughcastHost = new ExperiencedRoughcastHost();
            smartRoughcastHost.ToLiveInNewHouse();

            Console.WriteLine("***************************");
            
            var hardcoverHost = new HardcoverRoomHost();
            hardcoverHost.ToLiveInNewHouse();
        }
    }
}