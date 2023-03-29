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

        private int _height = 22;
        private int _width = 15;

        private Brush _brush;

        //Properties
        public int Xspeed { get { return _xSpeed; } }
        public int Yspeed { get { return _ySpeed; } }

        //Constructor
        public Bullet()
        {
            _brush = new SolidBrush(Color.Orange);
        }

        //Methods
        public void Shoot(Graphics gr, Point mLoc, Point player)
        {
            //find mouse location !
            //almost draw a line from the center of the player to that point
            //fire in that direction

            //Draw the damn bullet

            try
            {
                gr.FillEllipse(_brush, player.X, player.Y, 20, 20);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //add bullets to a list and then have in the paint event draw if there is any?  
    }

}