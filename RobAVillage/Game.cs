using System;

namespace RobAVillage
{
    class Game
    {
        static void Main(string[] args)
        {
            int[] startResources = { 1, 2, 1 };
            Robbers hunters = new Robbers("Охотники", 2, startResources.Length);
            Village birches = new Village(startResources, "Берёзки");
            Console.WriteLine("Добро пожаловать в игру 'RobAVillage'!!!!");
            Console.WriteLine("Ресурсы до игры:");
            birches.villageInfo();
            hunters.robbersInfo();
            hunters.setStolenResources(Play(hunters, birches));
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
            int alreadyStoled = 0;
            foreach (int res in resources)
                sum += res;
            if (capacity > sum)
                for (int i = 0; i < resources.Length; i++)
                    stolen[i] = resources[i];
            else
            {
                for (int i = 0; i < resources.Length; i++)
                    ratio[i] = Math.Round(capacity * (resources[i] / sum), 3);
                for (int i = 0; i < resources.Length; i++)
                {
                    stolen[i] = (int)Math.Round(ratio[i], MidpointRounding.AwayFromZero);
                    if (stolen[i] != 0)
                        alreadyStoled += stolen[i];
                    if (alreadyStoled == capacity)
                        break;
                }
            }
            if (capacity == 1 && alreadyStoled == 0)
                for (int i = 0; i < resources.Length; i++)
                {
                    if (resources[i] != 0)
                    {
                        stolen[i] = 1;
                        break;
                    }
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
