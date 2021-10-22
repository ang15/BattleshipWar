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
            File file = new File();
            file.CreateToFile();

            Player[] players = new Player[2];
            players[0] = Player.CreatePlayerByType(PlayerType.Human);
            players[1] = Player.CreatePlayerByType(PlayerType.AI);

            players[0].SetEnemyField(players[1].field);
            players[1].SetEnemyField(players[0].field);
            players[0].name = "one";
            players[1].name ="two" ;
            Draw(players[0], players[1]);
            
            for (int i = 0; i < 10; i++)
            { Generate(players[0]);
              Console.Clear();
              Draw(players[1], players[0]);
              Generate(players[1]);
              Console.Clear();
              Draw(players[0], players[1]);
            }
              Logic(players);
             DrawFinish(players[0], players[1]);
            Console.WriteLine("Finish");
            Console.Read();
        }

        private void Generate(Player player)
        {
            player.SetShipField();
        }

   
        private void Draw(Player player1, Player player2)
        {
            Console.Write("Играет  ");
            Console.Write(player1.name);
            for (int i = 0; i < alphavit.Length; i++)
            {
                Console.Write("  ");
                Console.Write("  ");
                Console.Write("  ");
            }
            Console.WriteLine(player2.name);
            DrawLeter();
            Console.Write(" ");
            DrawLeter();
            Console.WriteLine();
            for (int y = 0; y < 10; y++)
            {
                player1.Draw(y);
                Console.Write(" ");
                player2.DrawEnemy(y);
                Console.WriteLine();
            }
        }
        private void DrawFinish(Player player1, Player player2)
        {
            Console.Write("Играет" + player1);
            Console.Write(player1.name);
            for (int i = 0; i < alphavit.Length; i++)
            {
                Console.Write("  ");
                Console.Write("  ");
                Console.Write("  ");
            }
            Console.WriteLine(player2.name);
            DrawLeter();
            Console.Write(" ");
            DrawLeter();
            Console.WriteLine();
            for (int y = 0; y < 10; y++)
            {
                player1.Draw(y);
                Console.Write(" ");
                player2.Draw(y);
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
            int rezultOfParse1 = 0;
            int rezultOfParse2 = 0;
            do
            {
                rezultOfParse1 = 0;
                rezultOfParse2 = 0;
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        Console.WriteLine(players[0].field.GetCell(x, y).IsNotEmty);
                        if (players[0].field.GetCell(x, y).IsNotEmty && players[0].field.GetCell(x, y).WasShootedHere==false)
                        { 
                            if (CurrentPlayerIndex == 1)
                            {
                                int rezultOfParse = 0;
                                do
                                {
                                    Console.WriteLine();
                                    players[1].Logic(ref rezultOfParse1);
                                    Console.ReadLine();
                                    Console.Clear();
                                    Draw(players[1], players[0]);
                                } while (rezultOfParse == -1);
                                CurrentPlayerIndex = 0;
                                rezultOfParse1 += 1;
                            }
                            else if (CurrentPlayerIndex == 0)
                            {
                                int rezultOfParse = 0;
                                do
                                {
                                    Console.WriteLine();
                                    players[0].Logic(ref rezultOfParse1);
                                    Console.ReadLine();
                                    Console.Clear();
                                    Draw(players[0], players[1]);
                                } while (rezultOfParse == -1);
                                CurrentPlayerIndex = 1;
                                rezultOfParse2 += 1;
                            }
                            // Console.WriteLine(rezultOfParse);
                        }
                    }
                }
            } while (rezultOfParse1 == 0 && rezultOfParse2 == 0);
        }

    }
}
