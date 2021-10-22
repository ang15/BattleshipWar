namespace BattleshipWar
{
    internal interface IController
    {
        int Check19();
        int CheckAJ();
        int SetShip(ref int[] colship);
        bool  PlaceShooWhithOutOme(int x, int y);
    }
}