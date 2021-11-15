using System;
using System.Collections.Generic;
using System.Text;

namespace RobAVillage
{
    class Village
    {
        public static int resCount = 3;
        public string villageName;
        private int[] resources = new int[resCount];

        public Village(int[] resources, string name)
        {
            this.resources = resources;
            this.villageName = name;
        }

        public Village()
        {
            for (int i = 0; i < resCount; i++)
                resources[i] = 100;
            this.villageName = "Безымянная";
        }
        public int[] getResources()
        {
            if(villageIsNotEmpty())
                return this.resources;
            else
                throw new Exception("В деревне '" + villageName + "' не осталось ресурсов :(");
        }
        public bool villageIsNotEmpty()
        {
            bool flag = false;
            for (int i = 0; i < resCount; i++)
            {
                if (resources[i] != 0)
                    flag = true;
            }
            return flag;
        }

        public void setResources(int[] resources)
        {
            this.resources = resources;
        }

        public void villageInfo()
        {
            Console.WriteLine("Название деревни - '" + villageName + "'");
            Console.WriteLine("Ресурсы деревни: ");
            foreach (int res in resources)
                Console.WriteLine(res);
        }
    }
}
