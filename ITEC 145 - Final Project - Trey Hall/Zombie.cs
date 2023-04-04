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
        private int _xSpawn;
        private int _ySpawn;

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

            spawnLocation();

            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            timer.Interval = 20;
        }


        //Methods
        public void Spawn(Graphics gr)
        {
            gr.FillEllipse(_brush, _x, _y, _width, _height);
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

            // = 1 Should work perfectly but != 0 is Funnier
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

        public void Die()
        {
            timer.Stop();
            timer.Dispose();
        }
        
        public void spawnLocation()
        {
            //Wanted to spawn only bottom and right but I changed my mind;
            //Dont want to bother changing the variable name
            int xORy = _rnd.Next(0,4);
            if (xORy == 0)
            {
                _xSpawn = _rnd.Next(mainForm.ClientSize.Width - _width, mainForm.ClientSize.Width);
                _ySpawn = _rnd.Next(0, mainForm.ClientSize.Height);
            }
            else if(xORy == 1)
            {
               _ySpawn = _rnd.Next(mainForm.ClientSize.Height - _height, mainForm.ClientSize.Height);
               _xSpawn = _rnd.Next(0, mainForm.ClientSize.Width);
            }
            else if (xORy == 2)
            {
                _xSpawn = _rnd.Next(0 - _width, 0);
                _ySpawn = _rnd.Next(0, mainForm.ClientSize.Height);
            }
            else if (xORy == 3)
            {
                _ySpawn = _rnd.Next(0 - _height, 0);
                _xSpawn = _rnd.Next(0, mainForm.ClientSize.Width);
            }
            _x = _xSpawn;
            _y = _ySpawn;
        }
        
        //Events
        private void timer_Tick(object sender, EventArgs e)
        {
            int movement;
            movement = _rnd.Next(1, 4);
            if (movement == 1 || movement == 2)
            {
                MoveToPlayer(mainForm.playerLoc);
            }

            else if (movement == 3)
            {
                MoveRandom();
            }
        }
    }
}
