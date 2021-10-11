using System;

namespace BattleshipWar
{
    public class HumanController:IController
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
                numberSize= -1;
                Console.WriteLine("Раставим коробли");
                Console.WriteLine("Какой корабль ширеной будеш ставить?");
                int size = 1;
                bool success = int.TryParse(Console.ReadLine(), out size);
                Console.WriteLine("size =" + size);
                if (success == true && size >0 && size <5 )
                {
                    Console.WriteLine("size =" + size);
                    if (colship[size-1] != 0)
                    {
                        Console.WriteLine("size =" + size);
                        numberSize = size;
                        Console.WriteLine("size =" + size);
                        colship[size-1]--;
                        Console.WriteLine("size =" + size);
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
    }
}