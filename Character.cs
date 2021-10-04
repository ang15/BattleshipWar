using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipWar
{
    public class Character
    {
        private int[] colship = new int[4] { 4, 3, 2, 1 };
        public Field field = new Field();

        public void SetField(int size)
        {
            int rezultOfParse;
            do
            {
                rezultOfParse = -1;
                int x = CheckAJ();
                int y = Check19();
                if (size == 1)
                {
                    
                    field.PlaceShootOne(x, y, ref rezultOfParse);
                }
                else
                if (size == 2)
                {
                   bool vertcal= PlaceShooWhithOutOme(x, y);
                        field.PlaceShootTwo(x, y,vertcal, ref rezultOfParse);
                }
                else
                if (size == 3)
                {
                    bool vertcal = PlaceShooWhithOutOme(x, y);
                    field.PlaceShootThree(x, y, vertcal, ref rezultOfParse);
                }
                else
                if (size == 4)
                {
                    bool vertcal = PlaceShooWhithOutOme(x, y);
                    field.PlaceShootFour(x, y, vertcal, ref rezultOfParse);
                }
            } while (rezultOfParse ==-1);
        }

        public bool PlaceShooWhithOutOme(int x, int y)
        {
            int a = 0;
            do{
            Console.WriteLine("Куда паставите корабель из 2 клеток");
            Console.WriteLine("1.Вертикально");
            Console.WriteLine("2.Горизонтально");
            bool success = int.TryParse(Console.ReadLine(), out  a);
                if (success)
                {
                  
                }
            }while (a>2&&a<1);
            if (a == 1)
            {
                return true;
            }
            return false;
        }
        public void SetShip()
        {
            int rezultOfParse;
            do {
                rezultOfParse = -1;
                Console.WriteLine("Раставим коробли");
                Console.WriteLine("Какой корабль ширеной будеш ставить?");
                bool success = int.TryParse(Console.ReadLine(), out int size);

                if (success == true && size > 0 && size < 5)
                {
                    int number = size - 1;
                    if (colship[number] != 0)
                    {
                        rezultOfParse = 0;
                        colship[number]--;
                        SetField(size);
                    }
                }
                if (rezultOfParse == -1)
                {
                    Console.WriteLine("ошибка");
                }
            } while (rezultOfParse == -1);
        }
        public int Check19()
        {
            int rezultOfParse;
            do
            {
                rezultOfParse = -1;
                Console.Write("Цифра 1-9: ");
                bool numbers =int.TryParse( Console.ReadLine(),out int number);
                if (number<11 &&number>0)
                {
                    rezultOfParse = number-1;
                }
                else
                {
                    Console.WriteLine("ошибка");

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
                }
            } while (rezultOfParse == -1);
            return rezultOfParse;
        }
        public void Field()
        {
            SetShip();
        }  
        internal void Draw(int y)
        {
          
                Console.Write(y+1);
                if (y != 9)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
                for (int x = 0; x < 10; x++)
                {
                if (field.GetCell(x, y).IsNotEmty == true && field.GetCell(x, y).WasShootedHere == false)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" [0] ");
                    Console.ResetColor();
                }
                else if (field.GetCell(x, y).IsNotEmty == true && field.GetCell(x, y).WasShootedHere == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" [+] ");
                    Console.ResetColor();
                }
                else if (field.GetCell(x, y).IsNotEmty == false && field.GetCell(x, y).WasShootedHere == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" [x] ");
                    Console.ResetColor();

                }
                else if (field.GetCell(x,y).IsNotEmtyNear == true)
                    {
                        Console.Write(" [-] ");
                    }
                    else 
                    {
                        Console.Write(" [ ] ");
                    }
                }
        }
        internal void Logic(Enemy enemy)
        {
            Hit(enemy);
        }
        public void Hit(Enemy enemy)
        {
            int rezultOfParse;
            do
            {
                rezultOfParse = -1;
                Console.WriteLine("Начнем бой");
                Console.WriteLine("Куда будеш стрелять");
                int x = CheckAJ();
                int y = Check19();
                if (enemy.field.GetCell(x, y).IsNotEmty == true)
                {

                    Console.WriteLine("Ранел");
                    enemy.field.ShootAt(x, y);
                }
                else
                {
                    rezultOfParse = 0;
                    Console.WriteLine("мимо");
                    enemy.field.ShootAt(x, y);
                }

            } while (rezultOfParse == -1);
        }
    }

}