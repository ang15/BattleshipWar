using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipWar
{

    public class Enemy
    {
        public Field field = new Field();
        private int[] colship = new int[4] { 4, 3, 2, 1 };

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
                    bool vertcal = PlaceShooWhithOutOme(x, y);
                    field.PlaceShootTwo(x, y, vertcal, ref rezultOfParse);
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
            } while (rezultOfParse == -1);
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
        public void SetShip()
        {
            int rezultOfParse;
            do
            {
                rezultOfParse = -1;
                Random rnd = new Random();
                int size = rnd.Next(1, 5);
                    int number = size - 1;
                    if (colship[number] != 0)
                    {
                        rezultOfParse = 0;
                        colship[number]--;
                        SetField(size);
                    }
            } while (rezultOfParse == -1);
        }
        public int Check19()
        {
                Random rnd = new Random();
                int number = rnd.Next(0, 9);
                    return number;
        }

        public int CheckAJ()
        {

            Random rnd = new Random();
            int number = rnd.Next(0, 9);

            return number;
        }
        public void Field()
        {
            SetShip();
        }
        internal void Draw(int y)
        {

            Console.Write(y + 1);
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
                else if (field.GetCell(x, y).IsNotEmtyNear == true)
                {
                    Console.Write(" [-] ");
                }
                else
                {
                    Console.Write(" [ ] ");
                }
            }
        }
        internal void Logic(Character character)
        {
            Hit(character);
        }
        public void Hit(Character character)
        {
            int rezultOfParse;
            do
            {
                rezultOfParse = -1;
                Console.WriteLine("Начнем бой");
                Console.WriteLine("Куда будеш стрелять");
                int x = CheckAJ();
                int y = Check19();
                if (character.field.GetCell(x, y).IsNotEmty == true)
                {
                    Console.WriteLine("Ранел");
                    character.field.ShootAt(x, y);
                }
                else
                {
                    rezultOfParse = 0;
                    Console.WriteLine("мимо");
                    character.field.ShootAt(x, y);
                }
            } while (rezultOfParse == -1);
        }

    }
}


