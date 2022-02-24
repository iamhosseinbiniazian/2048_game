using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
namespace Game
{
   public struct MatrixF
    {
        public uint val;
        public bool blocked;

    }
   public class _2048
    {
      public MatrixF[,] Board = new MatrixF[4, 4];
       public bool win, done, moved;
       public uint Score;
      public enum MoveDir { UP, DOWN, LEFT, RIGHT,NOOP };
       public MoveDir MD;
       public _2048() {
         for (int i = 0; i < 4; i++)
           {
               for (int j = 0; j < 4; j++)
               {
                   this.Board[i, j].val = 0;
                   this.Board[i, j].blocked = false;
               }
           }
           win = false;
           done = false;
           moved = false;
           Score = 0;
           MD = MoveDir.NOOP;
           AddRandomNumber();
           AddRandomNumber();
       }
       public uint GetBoard(int i,int j){
           return Board[i, j].val;
       }
/*****************************************************/
       public void AddRandomNumber() {
           for (int i = 0; i < 4; i++)
           {
               for (int j = 0; j < 4; j++)
               {
                   if (!Convert.ToBoolean(Board[i, j].val)) {
                       uint a, b;
                       Random r=new Random();
                       do{
                       a=(uint)r.Next(0,4);
                       b=(uint)r.Next(0,4);
                       }while(Convert.ToBoolean(Board[a,b].val));
                       int s = r.Next(0, 100);
                       if (s > 89)
                           Board[a, b].val = 4;
                       else
                           Board[a, b].val = 2;
                       if (CanMove()) return;
                   }
               }
           }
           done = true;
       }
/***********************************************************/
       public bool CanMove() {
           for (int i = 0; i <4; i++)
           
               for (int j = 0; j <4; j++)
               
                   if (!Convert.ToBoolean(Board[i, j].val)) return true;
                ////////////////////////////////////////////////////////
           for (int y = 0; y <4; y++)
           {
               for (int x = 0; x < 4; x++)
               {
                   if (TeseAdd(x + 1, y, Board[x, y].val)) return true;
                   if (TeseAdd(x - 1, y, Board[x, y].val)) return true;
                   if (TeseAdd(x, y + 1, Board[x, y].val)) return true;
                   if (TeseAdd(x, y - 1, Board[x, y].val)) return true;
               }
           }
           
           return false;
       }
/****************************************************************/
       public bool TeseAdd(int x, int y, uint v) {
           if (x < 0 || x > 3 || y < 0 || y > 3) return false;
           return Board[x, y].val == v;
       }
/******************************************************************/
       public void MoveVert(int x, int y, int d) {

           if ((Convert.ToBoolean( Board[x,y + d].val) )&&( Board[x,y + d].val == Board[x,y].val) && !Board[x,y].blocked && !Board[x,y + d].blocked)
           {
               Board[x,y].val = 0;
               Board[x,y + d].val *= 2;
               Score += Board[x,y + d].val;
               Board[x,y + d].blocked = true;
               moved = true;
           }
           else if (!Convert.ToBoolean(Board[x,y + d].val) &&Convert.ToBoolean( Board[x,y].val))
           {
               Board[x,y + d].val = Board[x,y].val;
               Board[x,y].val = 0;
               moved = true;
           }
           if (d > 0) { if (y + d < 3) MoveVert(x, y + d, 1); }
           else { if (y + d > 0) MoveVert(x, y + d, -1); }
       

       }

/*****************************************************************/
       void MoveHori(int x, int y, int d)
       {
           if (Convert.ToBoolean(Board[x + d,y].val) && Board[x + d,y].val == Board[x,y].val && !Board[x,y].blocked && !Board[x + d,y].blocked)
           {
               Board[x,y].val = 0;
               Board[x + d,y].val *= 2;
               Score += Board[x + d,y].val;
               Board[x + d,y].blocked = true;
               moved = true;
           }
           else if (!Convert.ToBoolean( Board[x + d,y].val) &&Convert.ToBoolean( Board[x,y].val))
           {
               Board[x + d,y].val = Board[x,y].val;
               Board[x,y].val = 0;
               moved = true;
           }
           if (d > 0) { if (x + d < 3) MoveHori(x + d, y, 1); }
           else { if (x + d > 0) MoveHori(x + d, y, -1); }
         
       }
/*****************************************************************/
       void Move()
       {
           switch (MD)
           {
               case MoveDir.UP:
                   for (int x = 0; x < 4; x++)
                   {
                       int y = 1;
                       while (y < 4)
                       { if (Convert.ToBoolean(Board[x,y].val)) MoveVert(x, y, -1); y++; }
                   }
                   break;
               case MoveDir.DOWN:
                   for (int x = 0; x < 4; x++)
                   {
                       int y = 2;
                       while (y >= 0)
                       { if (Convert.ToBoolean(Board[x, y].val)) MoveVert(x, y, 1); y--; }
                   }
                   break;
               case MoveDir.LEFT:
                   for (int y = 0; y < 4; y++)
                   {
                       int x = 1;
                       while (x < 4)
                       { if (Convert.ToBoolean(Board[x, y].val)) MoveHori(x, y, -1); x++; }
                   }
                   break;
               case MoveDir.RIGHT:
                   for (int y = 0; y < 4; y++)
                   {
                       int x = 2;
                       while (x >= 0)
                       { if (Convert.ToBoolean(Board[x, y].val)) MoveHori(x, y, 1); x--; }
                   }
                   break;
           }
           if (moved)
           {
               AddRandomNumber();
               moved = false;
           }
           MD = MoveDir.NOOP;
           MD = MoveDir.NOOP;
           moved = false;
       }
/****************************************************************/
     public  void waitKey(Keys key)
       {
           moved = false; 
           switch (key)
           {
               case Keys.Left:
                   MD = MoveDir.LEFT;
                   break;
               case Keys.Right:
                   MD=MoveDir.RIGHT;
                   break;
               case Keys.Up:
                   MD = MoveDir.UP;
                   break;
               case Keys.Down:
                   MD = MoveDir.DOWN;
                       break;
               default:
                   MD=MoveDir.NOOP;
                   break;
           }
           Move();
           MD = MoveDir.NOOP;
           moved = false;
           for (int y = 0; y < 4; y++)
               for (int x = 0; x < 4; x++)
                   Board[x,y].blocked = false;
       }
/****************************************************************/
    }
}
