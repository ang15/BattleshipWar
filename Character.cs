using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipWar
{
    public class Character 
    {
        private int[] colship = new int[4] { 1, 2, 3, 4 };

      
        public void CheckAJ()
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
                if(rezultOfParse==-1)
                {
                    Console.WriteLine("ошибка");

                }
            } while (rezultOfParse!=-1);
          //  number2 = rezultOfParse;
        }
    }
}

