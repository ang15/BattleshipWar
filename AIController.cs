using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipWar
{
    public class AIController : IController
    {
        public int Check19()
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 10);
            return number;
        }

        public int CheckAJ()
        {

            Random rnd = new Random();
            int number = rnd.Next(0, 9);

            return number;
        }
        public int SetShip(ref int[] colship)
        {
            int numberSize;
            do
            {
                numberSize = -1;
                Random rnd = new Random();
                int size = rnd.Next(1, 5);
                int number = size - 1;
                if (colship[number] != 0)
                {
                    colship[number]--;
                    numberSize = size;
                }
            } while (numberSize == -1);
            return numberSize;
        }

        public bool PlaceShooWhithOutOme(int x, int y)
        {
            Random rnd = new Random();
            int a = rnd.Next(1, 2);
            if (a == 1)
            {
                return true;
            }
            return false;
        }
    }
}
