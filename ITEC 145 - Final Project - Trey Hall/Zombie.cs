using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC_145___Final_Project___Trey_Hall
{
    internal class Zombie
    {
        //Have the the top and left sides of the screen blocked off and zombies come from the bottom and right

        //Could do an enumeration for any special properties.

        //Fields
        private int _x;
        private int _y;
        private int _centerX;
        private int _centerY;

        private int _xSpeed = 3;
        private int _ySpeed = 3;

        private int _height = 30;
        private int _width = 30;

        private Brush _brush;

        private Random _rnd;

        //Properties
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Height { get { return _height; } }
        public int Width { get { return _width; } }


        //Constructor
        public Zombie(int x, int y)
        {
            _x = x;
            _y = y;

            _brush = new SolidBrush(Color.PaleGreen);

        }


        //Methods
        public void Draw(Graphics gr)
        {
            gr.FillEllipse(_brush, _x, _y, _width, _height);
        }
        //Method to determine a location and move towards it. A location being the player.
        public void MoveToPlayer(Point pointP, int widthP, int heightP)
        {
            _centerX = X + (Width / 2);
            _centerY = Y + (Height / 2);

            if(_centerX > pointP.X)
            {
                _x -= _xSpeed;
            }
            else if(_centerX < pointP.X)
            {
                _x += _xSpeed;
            }

            if (_centerY < pointP.Y)
            {
                _y += _ySpeed;
            }
            else if (_centerY > pointP.Y)
            {
                _y -= _ySpeed;
            }

        }

        public void MoveRandom()
        {
            _rnd = new Random();
            int xOrY = _rnd.Next();
            int uOrD = _rnd.Next();
            int lOrR = _rnd.Next();

            if(xOrY % 2 == 0)
            {
                if (uOrD % 2 == 0)
                {
                    _x -= _xSpeed;
                }

                else if (uOrD % 2 != 0)
                {
                    _x += _xSpeed;
                }
            }

            if(xOrY % 2 != 0)
            {
                if (lOrR % 2 == 0)
                {
                    _y -= _ySpeed;
                }

                else if (lOrR % 2 != 0)
                {
                    _y += _ySpeed;
                }
            }
        }
        //In the form could randomly switch between the two move methods

        private void Die()
        {

        }

    }
}
