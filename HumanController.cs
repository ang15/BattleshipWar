using System;

namespace BattleshipWar
{
    public class HumanController : IController
    {
        public int Check19()
        {
            int rezultOfParse;
            do
            {
                rezultOfParse = -1;
                Console.Write("Цифра 1-9: ");
                bool numbers = int.TryParse(Console.ReadLine(), out int number);
                if (number < 11 && number > 0)
                {
                    rezultOfParse = number - 1;
                }
                else
                {
                    Console.WriteLine("ошибка");
                    Console.ReadLine();
                }
            } while (rezultOfParse == -1);
            return rezultOfParse;
        }

        public int CheckAJ()
        {

            int rezultOfParse;
            do
            {

                rezultOfParse = -1;
                Console.Write("Буква A-J: ");
                string str = Console.ReadLine();
                if (str.Length == 1)
                {
                    char lowedFirstChar = Char.ToLower(str[0]);
                    if (lowedFirstChar >= 'a' && lowedFirstChar <= 'j')
                    {
                        rezultOfParse = lowedFirstChar - 'a';
                    }
                }

                if (rezultOfParse == -1)
                {
                    Console.WriteLine("ошибка");
                    Console.ReadLine();
                }
            } while (rezultOfParse == -1);
            return rezultOfParse;
        }
        public int SetShip(ref int[] colship)
        {
            int numberSize;
            do
            {
                numberSize = -1;
                Console.WriteLine("Раставим коробли");
                Console.WriteLine("Какой корабль ширеной будеш ставить?");
                bool success = int.TryParse(Console.ReadLine(), out int size);
                if (success == true && size >=1  && size <=4)
                {
                    if (colship[size - 1] != 0)
                    {
                        numberSize = size;
                        colship[size - 1]--;
                    }
                }
                if (numberSize == -1)
                {
                    Console.WriteLine("ошибка");
                    Console.ReadLine();
                }
            } while (numberSize == -1);
            return numberSize;
        }
        public bool PlaceShooWhithOutOme(int x, int y)
        {
            int a = 0;
            bool finish = true;
            do
            {
                Console.WriteLine("Куда поставите корабель из 2 клеток");
                Console.WriteLine("1.Вертикально");
                Console.WriteLine("2.Горизонтально");
                bool success = int.TryParse(Console.ReadLine(), out a);
                if (success == false || (a < 1 || a > 2))
                {
                    Console.WriteLine("Ошибка");
                    a = 0;
                }
                if (a == 1)
                {
                    finish = true;
                }
                else if (a == 2)
                {
                    finish = false;
                }
                if (a==0)
                {
                    Console.WriteLine("ошибка");
                    Console.ReadLine();
                }
            } while (a == 0);
            return finish;
        }
    }
}