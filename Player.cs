using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipWar
{
    public enum PlayerType
    {
        Human,
        AI
    }

    public class Player
    {

        File file = new File();
        public string name;
        private int[] colship = new int[4] { 4, 3, 2, 1 };
        public Field field;
        private Field enemy;

        private IController controller;

        private Player(IController controller)
        {
            this.controller = controller;
            field = new Field();
        }

        public static Player CreatePlayerByType(PlayerType type)
        {
            IController controller = null;
            switch (type)
            {
                case PlayerType.Human:
                    controller = new HumanController();
                    break;
                case PlayerType.AI:
                    controller = new AIController();
                    break;
                default:
                    break;
            }

            return new Player(controller);
        }

        public void SetEnemyField(Field enemy)
            => this.enemy = enemy;

        public void SetField(int size)
        {
            int rezultOfParse;
            do
            {
                rezultOfParse = -1;
                int x = controller.CheckAJ();
                int y = controller.Check19();
                file.AddToFile($""+size);
                if (size == 1)
                {
                    field.PlaceShootOne(x, y, ref rezultOfParse);
                }
                else
                if (size == 2)
                {
                    bool vertcal = controller.PlaceShooWhithOutOme(x, y);
                    field.PlaceShootTwo(x, y, vertcal, ref rezultOfParse);
                }
                else
                if (size == 3)
                {
                    bool vertcal = controller.PlaceShooWhithOutOme(x, y);
                    field.PlaceShootThree(x, y, vertcal, ref rezultOfParse);
                }
                else
                if (size == 4)
                {
                    bool vertcal = controller.PlaceShooWhithOutOme(x, y);
                    field.PlaceShootFour(x, y, vertcal, ref rezultOfParse);
                }
            } while (rezultOfParse == -1);

        }


        public void SetShipField()
        {
            int size = controller.SetShip(ref colship);
            SetField(size);
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
        internal void DrawEnemy(int y)
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
                    // Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" [ ] ");
                    //  Console.ResetColor();
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
                    Console.Write(" [ ] ");
                }
                else
                {
                    Console.Write(" [ ] ");
                }
            }
        }
        internal void Logic(ref int rezultOfParse1)
        {
            Hit(ref rezultOfParse1);
        }
        public void Hit(ref int rezultOfParse1)
        {
            rezultOfParse1 = -1;
            Console.WriteLine("Начнем бой");
            Console.WriteLine("Куда будеш стрелять");
            int x = controller.CheckAJ();
            int y = controller.Check19();
            if (enemy.GetCell(x, y).IsNotEmty == true)
            {

                Console.WriteLine("Ранел");
                enemy.ShootAt(x, y);
            }
            else
            {
                rezultOfParse1 = 0;
                Console.WriteLine("мимо");
                enemy.ShootAt(x, y);
            }
        }
    }
}