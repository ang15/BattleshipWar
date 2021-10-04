using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipWar
{
   public  class Game
    {
        public string alphavit = "ABCDIFGHIJ";
        public void Main()
        {
            Character character = new Character();
            Enemy enemy = new Enemy();

            Draw(character, enemy);
            
            for(int i=0;i<9;i++)
            {
              Generate(character, enemy);
                Console.Clear();
                Draw(character, enemy);
            }
          // Draw(character, enemy);
            int rezultOfParse;
            do {
                rezultOfParse = 0;
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        if (character.field.GetCell(x, y).IsNotEmty || enemy.field.GetCell(x, y).IsNotEmty)
                        {
                            Logic(character, enemy);

                            Console.Clear();
                            Draw(character, enemy);
                            rezultOfParse = 1;
                        }
                    }
                }
            } while ( rezultOfParse==0);

            Console.WriteLine();
            Console.Read();
        }
        private  void Generate(Character character, Enemy enemy)
        {
          //  character.Field();
            enemy.Field();
        }
        private  void Draw(Character character, Enemy enemy)
        {

            DrawLeter();
            Console.Write(" ");
            DrawLeter();
            Console.WriteLine();
            for (int y=0;y<10;y++) {
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

        private  void Logic(Character character, Enemy enemy)
        {
            character.Logic(enemy);
            enemy.Logic(character);
        }
    }
}
