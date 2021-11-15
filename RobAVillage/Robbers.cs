using System;
using System.Collections.Generic;
using System.Text;

namespace RobAVillage
{
    class Robbers
    {
        public string gangName;

        private int capacity;

        private int[] stolenResources; 

        public Robbers(string gangName, int capacity, int size)
        {
            this.gangName = gangName;
            this.capacity = capacity;
            stolenResources = new int[size];
        }

        public int getCapacity()
        {
            return this.capacity;
        }

        public void setCapacity(int capacity)
        {
            if(capacity >= 0)
                this.capacity = capacity;
        }

        public int[] getStolenResources()
        {
            if (stolenResourcesExists())
                return this.stolenResources;
            else
                throw new Exception("В банде '" + gangName + "' нет украденных ресурсов :(");
        }
        public void setStolenResources(int[] stolenResources)
        {
            this.stolenResources = stolenResources;
        }
        public bool stolenResourcesExists()
        {
            bool flag = false;
            for (int i = 0; i < stolenResources.Length; i++)
            {
                if (stolenResources[i] != 0)
                    flag = true;
            }
            return flag;
        }
        public void robbersInfo()
        {
            Console.WriteLine("Название банды - '" + gangName + "'");
            Console.WriteLine("Ресурсы банды: ");
            foreach (int res in stolenResources)
                Console.WriteLine(res);
        }
    }
}
