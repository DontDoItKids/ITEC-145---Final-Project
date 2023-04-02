using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC_145___Final_Project___Trey_Hall
{
    internal class Zombie
    {
        static public Form1 mainForm;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        //Have the the top and left sides of the screen blocked off and zombies come from the bottom and right

        //Could do an enumeration for any special properties.

        //Fields
        private int _x;
        private int _y;
        private int _centerX;
        private int _centerY;

        private Random _rnd = new Random();

        private int _xSpeed = 3;
        private int _ySpeed = 3;

        private int _height = 30;
        private int _width = 30;

        private Brush _brush;

        //Properties
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Height { get { return _height; } }
        public int Width { get { return _width; } }


        //Constructor
        public Zombie()
        {
            _brush = new SolidBrush(Color.PaleGreen);
        }


        //Methods
        public void Spawn(Graphics gr, int x, int y)
        {
            gr.FillEllipse(_brush, _x, _y, _width, _height);

            _x = x;
            _y = y;

            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            timer.Interval = 20;
        }
        //Method to determine a location and move towards it. A location being the player.
        public void MoveToPlayer(Point pointP)
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
            timer.Stop();
            timer.Dispose();
        }

        //Events
        private void timer_Tick(object sender, EventArgs e)
        {
            //Switching between the two modes of zombie movement. Might move to a seperate timer.
            int movement;
            movement = _rnd.Next();
            if (movement % 2 == 0)
            {
                MoveToPlayer(mainForm.playerLoc);
            }

            else if (movement % 2 != 0)
            {
                MoveRandom();
            }
        }
    }
}
