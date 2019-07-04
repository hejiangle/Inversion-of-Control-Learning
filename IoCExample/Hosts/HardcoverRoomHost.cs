using System;
using IoCExample.ThirdParty;
using IoCExample.Workers;

namespace IoCExample.Hosts
{
    /// <summary>
    /// Try to use IoC and DIP to make this class looser coupled with Dependency.
    /// </summary>
    public class HardcoverRoomHost
    {
        private IWorking _hardcoverHouseDeveloper;

        public HardcoverRoomHost()
        {
            Console.WriteLine("I'm the host of hardcover house...");
        }

        private void BuyAHardCoverHouse(IWorking proxy)
        {
            Console.WriteLine("I bought a hardcover house...");
            _hardcoverHouseDeveloper = proxy;
        }

        public void ToLiveInNewHouse()
        {
            BuyAHardCoverHouse(new HardcoverHouseDeveloper());
            _hardcoverHouseDeveloper.Decorate();
            
            Console.WriteLine("Now I can live in new house...");
        }
    }
}