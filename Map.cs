using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipWar
{
    public struct Cell
    {
        public bool IsEmty;
        public bool WasShootedHere;
    }
    public class Field{

        private Cell[,] cells = new Cell[10,10];
        public void ShootAt(int x, int y) => cells[ y,x].WasShootedHere = true;

        public void PlaceShootAt(int x,int y)=>cells[y,x].IsEmty = true;
        public Cell GetCell(int x, int y) =>  cells[y, x];
    }

}
