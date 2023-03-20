using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC_145___Final_Project___Trey_Hall
{
    internal class Zombie
    {
        //Fields
        private int _x;
        private int _y;
        private int _centerX;
        private int _centerY;

        private int _xSpeed = 4;
        private int _ySpeed = 4;

        private int _height = 30;
        private int _width = 30;

        private Brush _brush;

        //Constructor
        public Zombie(int x, int y)
        {
            _x = x;
            _y = y;

            _brush = new SolidBrush(Color.PaleGreen);

            _centerX = X + (Height / 2);
            _centerY = Y + (Width / 2);
        }

        //Properties
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Height { get { return _height; } }
        public int Width { get { return _width; } }


        //Methods
        public void Draw(Graphics gr)
        {
            gr.FillEllipse(_brush, _x, _y, _width, _height);
        }
        //Method to determine a location and move towards it. A location being the player.
        public void MoveToPlayer(int xP, int yP, int widthP, int heightP)
        {
            int playerCenterX = xP + (heightP / 2);
            int playerCenterY = yP + (widthP / 2);

            if(_centerX > playerCenterX)
            {
                _x += _xSpeed;
            }
            if(_centerX < playerCenterX)
            {
                _x -= _xSpeed;
            }

            //if(_centerY < playerCenterY)
            //{
            //    _y += _ySpeed;
            //}
            //else if(_centerY > playerCenterY)
            //{
            //    _y -= _ySpeed;
            //}

        }

        public void MoveRandom()
        {

        }
        //In the form could randomlly switch between the two move methods
    }
}
