using System;
using IoCExample.Workers;

namespace IoCExample.ThirdParty
{
    /// <summary>
    /// Static Factory
    /// </summary>
    public static class LaborContractor
    {
        public static Worker RecommendWorker(string workType)
        {
            Worker worker;
            switch (workType)
            {
                case "Hardware": worker = RecommendHardwareWorker();
                    break;
                case "Floor": worker = RecommendFloorFinisher();
                    break;
                case "KitchenAndBath": worker = RecommendKitchenAndBathWorker();
                    break;
                case "Wall": worker = RecommendPaperhanger();
                    break;
                case "Paint": worker = RecommendPainter();
                    break;
                default:
                    throw new NotSupportedException("No this type worker in our labor market.");
            }

            return worker;
        }

        private static HardwareWorker RecommendHardwareWorker()
        {
            Console.WriteLine("HardwareWorker connect to me...");
            return new HardwareWorker();
        }

        private static FloorFinisher RecommendFloorFinisher()
        {
            Console.WriteLine("FloorFinisher connect to me...");
            return new FloorFinisher();
        }

        private static KitchenAndBathWorker RecommendKitchenAndBathWorker()
        {
            Console.WriteLine("KitchenAndBathWorker connect to me...");
            return new KitchenAndBathWorker();
        }

        private static Paperhanger RecommendPaperhanger()
        {
            Console.WriteLine("Paperhanger connect to me...");
            return new Paperhanger();
        }

        private static Painter RecommendPainter()
        {
            Console.WriteLine("Painter connect to me...");
            return new Painter();
        }
    }
}