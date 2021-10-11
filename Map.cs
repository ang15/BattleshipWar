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
        public bool IsNotEmty;
        public bool WasShootedHere;
        public bool IsNotEmtyNear;
    }
    public class Field
    {

        private Cell[,] cells = new Cell[10, 10];
        public void ShootAt(int x, int y) => cells[y, x].WasShootedHere = true;

        public void PlaceShootAt(int x, int y) => cells[y, x].IsNotEmty = true;

        public Cell GetCell(int x, int y) => cells[y, x];
        public void PlaceShootAtNear(int x, int y)
        {
            if (cells[y, x].IsNotEmty == false)
            {
                cells[y, x].IsNotEmtyNear = true;
            }
        }
        public void TryPlace(int x, int y)
        {
            if (IsScope(x, y))
            {
                PlaceShootAtNear(x, y);
            }
        }

        public void PlaceShootAtNearX0(int x, int y)
        {
            TryPlace(x - 1, y);
            TryPlace(x + 1, y);

            TryPlace(x, y + 1);
            TryPlace(x - 1, y + 1);
            TryPlace(x + 1, y + 1);

            TryPlace(x, y - 1);
            TryPlace(x + 1, y - 1);

        }
     
        
        public void PlaceShootOne(int x, int y, ref int rezultOfParse)
        {
            if (IsNotEmtyAndIsNotEmtyNear(x, y))
            {
                RezultPlaceShootAt( x,  y);
            }
        }
        public void PlaceShootTwo(int x, int y, bool vertical, ref int rezultOfParse)
        {
            if (vertical) PlaceShootTwoVertical(x, y, ref rezultOfParse);
            else PlaceShootTwoHorizontal(x, y, ref rezultOfParse);

        }
        public void PlaceShootThree(int x, int y, bool vertical, ref int rezultOfParse)
        {
            if (vertical) PlaceShootThreeVertical(x, y, ref rezultOfParse);
            else PlaceShootThreeHorizontal(x, y, ref rezultOfParse);
        }
        public void PlaceShootFour(int x, int y, bool vertical, ref int rezultOfParse)
        {
            if (vertical) PlaceShootFourVertical(x, y, ref rezultOfParse);
            else PlaceShootFourHorizontal(x, y, ref rezultOfParse);
        }
        public void PlaceShootTwoVertical(int x, int y, ref int rezultOfParse)
        {
            if (IsScope(x, y) && IsScope(x, y + 1))
            {
                if (IsNotEmtyAndIsNotEmtyNear(x, y) && IsNotEmtyAndIsNotEmtyNear(x, y + 1))
                {

                    for (int i = 0; i < 2; i++)
                    {
                        rezultOfParse = RezultPlaceShootAt(x, y);
                        y++;
                    }
                }
            }
        }
        public void PlaceShootThreeVertical(int x, int y, ref int rezultOfParse)
        {
            if (IsScope(x, y) && IsScope(x, y + 1) && IsScope(x, y + 2))
            {
                if (IsNotEmtyAndIsNotEmtyNear(x, y) && IsNotEmtyAndIsNotEmtyNear(x, y + 1) && IsNotEmtyAndIsNotEmtyNear(x, y + 2))
                {

                    for (int i = 0; i < 3; i++)
                    {
                        rezultOfParse = RezultPlaceShootAt(x, y);
                        y++;
                    }
                }
            }
        }
        public void PlaceShootFourVertical(int x, int y, ref int rezultOfParse)
        {
            if (IsScope(x, y) && IsScope(x, y + 1) && IsScope(x, y + 2) && IsScope(x, y + 3))
            {
                if (IsNotEmtyAndIsNotEmtyNear(x, y) && IsNotEmtyAndIsNotEmtyNear(x, y + 1) && IsNotEmtyAndIsNotEmtyNear(x, y + 2) && IsNotEmtyAndIsNotEmtyNear(x, y + 3))
                {

                    for (int i = 0; i < 4; i++)
                    {
                        rezultOfParse = RezultPlaceShootAt(x, y);
                        y++;
                    }
                }
            }
        }
        public void PlaceShootTwoHorizontal(int x, int y, ref int rezultOfParse)
        {
            if (IsScope(x, y) && IsScope(x + 1, y))
            {
                if (IsNotEmtyAndIsNotEmtyNear(x, y) && IsNotEmtyAndIsNotEmtyNear(x, y + 1))
                {

                    for (int i = 0; i < 2; i++)
                    {
                        rezultOfParse = RezultPlaceShootAt(x, y);
                        x++;
                    }
                }
            }
        }
        public void PlaceShootThreeHorizontal(int x, int y, ref int rezultOfParse)
        {
            if (IsScope(x, y) && IsScope(x + 1, y) && IsScope(x + 2, y))
            {
                if (IsNotEmtyAndIsNotEmtyNear(x, y) && IsNotEmtyAndIsNotEmtyNear(x, y + 1) && IsNotEmtyAndIsNotEmtyNear(x, y + 2))
                {

                    for (int i = 0; i < 3; i++)
                    {
                        rezultOfParse = RezultPlaceShootAt(x,y);
                        x++;
                    }
                }
            }
        }
        public void PlaceShootFourHorizontal(int x, int y, ref int rezultOfParse)
        {
            if (IsScope(x, y) && IsScope(x + 1, y) && IsScope(x + 2, y) && IsScope(x + 3, y))
            {
                if (IsNotEmtyAndIsNotEmtyNear(x, y) && IsNotEmtyAndIsNotEmtyNear(x, y + 1) && IsNotEmtyAndIsNotEmtyNear(x, y + 2) && IsNotEmtyAndIsNotEmtyNear(x, y + 3))
                {

                    for (int i = 0; i < 4; i++)
                    {
                        rezultOfParse = RezultPlaceShootAt(x, y);
                        x++;
                    }
                }
            }

        }
        public bool IsNotEmtyAndIsNotEmtyNear(int x, int y)
        {
            if (cells[y, x].IsNotEmty == false && cells[y, x].IsNotEmtyNear == false)
            {
                return true;
            }
            return false;
        }
        public bool IsScope(int x, int y)
        {
            return x <= 9 && x >= 0 && y <= 9 && y >= 0;
          
        }
        public int RezultPlaceShootAt(int x, int y)
        {
           
            PlaceShootAt(x, y);
            PlaceShootAtNearX0(x, y);
            return 0;
        }
    }
}
