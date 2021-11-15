using System;

namespace RobAVillage
{
    class Game
    {
        static void Main(string[] args)
        {
            int[] startResources = { 100, 300, 200 };
            Robbers hunters = new Robbers("Охотники", 120, startResources.Length);
            Village birches = new Village(startResources, "Берёзки");
            Console.WriteLine("Добро пожаловать в игру 'RobAVillage'!!!!");
            Console.WriteLine("Ресурсы до игры:");
            birches.villageInfo();
            hunters.robbersInfo();
            Play(hunters, birches);
            Console.WriteLine("Ресурсы после игры:");
            birches.villageInfo();
            hunters.robbersInfo();
        }

        static int[] Play(Robbers rob, Village vil)
        {
            int[] resources = vil.getResources();
            double[] ratio = new double[resources.Length];
            int[] stolen = new int[resources.Length];
            double sum = 0;
            int capacity = rob.getCapacity();
            foreach (int res in resources)
                sum += res;
            for (int i = 0; i < resources.Length; i++)
                ratio[i] = Math.Round(resources[i] / sum, 3);
            for (int i = 0; i < resources.Length; i++)
            {
                stolen[i] = (int)Math.Round(capacity * ratio[i]);
                rob.setStolenResources(stolen);
            }
            for (int i = 0; i < resources.Length; i++)
            {
                resources[i] -= stolen[i];
                vil.setResources(resources);
            }
            return stolen;
        }
    }
}
