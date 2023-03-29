using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC_145___Final_Project___Trey_Hall
{
    internal class Bullet
    {
        static public Form1 mainForm;

        //Fields
        private int _x;
        private int _y;

        private int _xSpeed;
        private int _ySpeed;

        private int _diffX;
        private int _diffY;

        private int _height = 5;
        private int _width = 5;

        private Brush _brush;

        //Properties
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Xspeed { get { return _xSpeed; } }
        public int Yspeed { get { return _ySpeed; } }

        //Constructor
        public Bullet(Point mLoc, Point player)
        {
            _brush = new SolidBrush(Color.Orange);

            _x = player.X;
            _y = player.Y;

            _diffX = player.X - mLoc.X;
            _diffY = player.Y - mLoc.Y;

            if (_diffX < 0 && _diffY < 0)
            {
                if (_diffX > _diffY)
                {
                    _xSpeed = _diffX / _diffY;
                    _xSpeed *= -1;
                    _ySpeed = -1;
                }

                if (_diffX < _diffY)
                {
                    _ySpeed = _diffY / _diffX;
                    _ySpeed *= -1;
                    _xSpeed = -1;
                }

            }

            if (_diffX > _diffY)
            {
                if (_diffY < 0)
                {
                    _xSpeed = _diffX / _diffY;
                    _xSpeed *= -1;
                    _ySpeed = -1;
                }
                else
                {
                    _xSpeed = _diffX / _diffY;
                    _xSpeed *= -1;
                    _ySpeed = 1;
                }

            }

            if (_diffX < _diffY)
            {
                if (_diffX < 0)
                {
                    _ySpeed = _diffY / _diffX;
                    _ySpeed *= -1;
                    _xSpeed = -1;
                }
                else
                {
                    _ySpeed = _diffY / _diffX;
                    _ySpeed *= -1;
                    _xSpeed = 1;
                }
            }
        }

        //Methods
        public void Shoot(Graphics gr)
        {
            gr.FillEllipse(_brush, _x, _y, _width, _height);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            if (_x < 0)
            {
                timer.Stop();
                timer.Dispose();
            }
            if (_y < 0)
            {
                timer.Stop();
                timer.Dispose();
            }
            if(_x > mainForm.ClientSize.Width)
            {
                timer.Stop();
                timer.Dispose();
            }
            if (_y > mainForm.ClientSize.Height)
            {
                timer.Stop();
                timer.Dispose();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _x += _xSpeed;
            _y += _ySpeed;
        }
    }

}