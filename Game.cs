using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipWar
{
    public class Game
    {
        public string alphavit = "ABCDIFGHIJ";
        public void Main()
        {
            //  Character character = new Character();
            //  Enemy enemy = new Enemy();

            Player[] players = new Player[2];
            players[0] = Player.CreatePlayerByType(PlayerType.Human);
            players[1] = Player.CreatePlayerByType(PlayerType.AI);

            players[0].SetEnemyField(players[1].field);
            players[1].SetEnemyField(players[0].field);
            Draw(players[0], players[1]);
            
            for (int i = 0; i < 10; i++)
            {
                Generate(players[0], players[1]);
                Console.Clear();
                Draw(players[0], players[1]);
            }
            Logic(players);


            Console.WriteLine("Finish");
            Console.Read();
        }

        private void Generate(Player character, Player enemy)
        {
            character.SetShipField();
            enemy.SetShipField();
        }

        private void Draw(Player character, Player enemy)
        {

            DrawLeter();
            Console.Write(" ");
            DrawLeter();
            Console.WriteLine();
            for (int y = 0; y < 10; y++)
            {
                character.Draw(y);
                Console.Write(" ");
                enemy.Draw(y);
                Console.WriteLine();
            }
        }

        private void DrawLeter()
        {

            Console.Write("   ");
            for (int i = 0; i < alphavit.Length; i++)
            {
                Console.Write("  ");
                Console.Write(alphavit[i]);
                Console.Write("  ");
            }
        }
        private void Logic(Player[] players)
        {
            int CurrentPlayerIndex = 0;
            int rezultOfParse;
            do
            {
                rezultOfParse = 0;
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        if (players[0].field.GetCell(x, y).IsNotEmty || players[1].field.GetCell(x, y).IsNotEmty)
                        {
                            if (CurrentPlayerIndex == 1)
                            {
                                CurrentPlayerIndex = (CurrentPlayerIndex - 1) % 2;
                                players[0].SetShipField();
                            }
                            else
                            {
                                CurrentPlayerIndex = (CurrentPlayerIndex - 1) % 2;
                                players[1].SetShipField();
                            }
                            Console.Clear();
                            Draw(players[0], players[1]);

                            rezultOfParse += 1;
                        }
                    }
                }

            } while (rezultOfParse < 10);
        }
    }
}
