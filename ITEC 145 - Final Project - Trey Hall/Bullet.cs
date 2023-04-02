using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITEC_145___Final_Project___Trey_Hall
{
    internal class Bullet
    {
        static public Form1 mainForm;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        //Fields
        private int _x;
        private int _y;

        private int _xSpeed;
        private int _ySpeed;

        private double _tempX;
        private double _tempY;

        private double _diffX;
        private double _diffY;

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

            _diffX = mLoc.X - player.X;
            _diffY = mLoc.Y - player.Y;

            if (_diffX < 0 && _diffY < 0)
            {
                if (_diffX > _diffY)
                {
                    _tempX = _diffX / _diffY;
                    _ySpeed = -1;

                    if (_tempX <= -0.6 && _tempX > -1)
                    {
                        _xSpeed = -1;
                    }
                    else if (_tempX >= 0.6 && _tempX < 1)
                    {
                        _xSpeed = 1;
                    }
                    else if (_tempX > -0.6 && _tempX < 0.6)
                    {
                        _xSpeed = 0;
                    }
                    else
                    {
                        _xSpeed = (int)_tempX;
                    }
                    _xSpeed *= -1;

                }
                else if (_diffX < _diffY)
                {
                    _tempY = _diffY / _diffX;
                    _xSpeed = -1;

                    if (_tempY <= -0.6 && _tempY > -1)
                    {
                        _ySpeed = -1;
                    }
                    else if (_tempY >= 0.6 && _tempY < 1)
                    {
                        _ySpeed = 1;
                    }
                    else if (_tempY > -0.6 && _tempY < 0.6)
                    {
                        _ySpeed = 0;
                    }
                    else
                    {
                        _ySpeed = (int)_tempY;
                    }
                    _ySpeed *= -1;

                }

            }

            else if (_diffX > _diffY)
            {
                if (_diffY < 0)
                {
                    _tempX = _diffX / _diffY;
                    _ySpeed = -1;

                    if (_tempX <= -0.6 && _tempX > -1)
                    {
                        _xSpeed = -1;
                    }
                    else if (_tempX >= 0.6 && _tempX < 1)
                    {
                        _xSpeed = 1;
                    }
                    else if(_tempX > -0.6 && _tempX < 0.6)
                    {
                        _xSpeed = 0;
                    }
                    else
                    {
                        _xSpeed = (int)_tempX;
                    }

                    _xSpeed *= -1;

                }
                else
                {
                    _tempX = _diffX / _diffY;
                    _ySpeed = 1;

                    if (_tempX <= -0.6 && _tempX > -1)
                    {
                        _xSpeed = -1;
                    }
                    else if (_tempX >= 0.6 && _tempX < 1)
                    {
                        _xSpeed = 1;
                    }
                    else if (_tempX > -0.6 && _tempX < 0.6)
                    {
                        _xSpeed = 0;
                    }
                    else
                    {
                        _xSpeed = (int)_tempX;
                    }

                }

            }

            else if (_diffX < _diffY)
            {
                if (_diffX < 0)
                {
                    _tempY = _diffY / _diffX;
                    _xSpeed = -1;

                    if (_tempY <= -0.6 && _tempY > -1)
                    {
                        _ySpeed = -1;
                    }
                    else if (_tempY >= 0.6 && _tempY < 1)
                    {
                        _ySpeed = 1;
                    }
                    else if (_tempY > -0.6 && _tempY < 0.6)
                    {
                        _ySpeed = 0;
                    }
                    else
                    {
                        _ySpeed = (int)_tempY;
                    }
                    _ySpeed *= -1;

                }
                else
                {
                    _tempY = _diffY / _diffX;
                    _xSpeed = 1;

                    if (_tempY <= -0.6 && _tempY > -1)
                    {
                        _ySpeed = -1;
                    }
                    else if (_tempY >= 0.6 && _tempY < 1)
                    {
                        _ySpeed = 1;
                    }
                    else if(_tempY > -0.6 && _tempY < 0.6)
                    {
                        _ySpeed = 0;
                    }
                    else
                    {
                        _ySpeed = (int)_tempY;
                    }

                }
            }
        }

        //Methods
        public void Shoot(Graphics gr)
        {
            gr.FillEllipse(_brush, _x, _y, _width, _height);

            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            timer.Interval = 20;

            if (_x < 0 || _y < 0 || _x > mainForm.ClientSize.Width || _y > mainForm.ClientSize.Height)
            {
                timer.Stop();
                timer.Dispose();
            }

        }

        //Events
        private void timer_Tick(object sender, EventArgs e)
        {
            _x += _xSpeed;
            _y += _ySpeed;
        }

    }

}