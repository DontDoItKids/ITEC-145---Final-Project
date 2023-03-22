using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC_145___Final_Project___Trey_Hall
{
    internal class Bullet
    {
        //Fields
        private int _x;
        private int _y;

        private int _xSpeed;
        private int _ySpeed;

        private int _height = 30;
        private int _width = 30;

        private Brush _brush;

        //Properties
        public int Xspeed { get { return _xSpeed; } }
        public int Yspeed { get { return _ySpeed; } }

        //Constructor
        public Bullet()
        {
            
        }
        //Need to figure out mouse location and than shoot in that direction
        //Methods
        public void Shoot(Point mLoc, int playerCX, int playerCY )
        {
            //find mouse location !
            //almost draw a line from the center of the player to that point
            //fire in that direction
        }

    }
}
