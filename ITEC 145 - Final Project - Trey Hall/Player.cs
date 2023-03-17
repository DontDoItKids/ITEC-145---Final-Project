using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC_145___Final_Project___Trey_Hall
{
    internal class Player
    {
        static public Form1 mainForm;

        //Fields
        private int _x;
        private int _y;

        private int _xSpeed = 15;
        private int _ySpeed = 15;

        private int _height = 30;
        private int _width = 30;

        private Brush _brush;

        //Constructor make it take a file path for the image
        public Player(int x, int y)
        {
            _x = x;
            _y = y;

            _brush = new SolidBrush(Color.Black);
        }

        //Properties
        public int X { get { return _x; } }
        public int Y { get { return _y; } }


        //Methods
        public void Draw(Graphics gr)
        {
            gr.FillEllipse(_brush, _x, _y, _width, _height);
        }

        public void MoveY(bool _UpDown)
        {
            if (_UpDown == true)
            {
                _y -= _ySpeed;
                if (_y < 0)
                {
                    _y = 0;
                }
            }

            if (_UpDown == false)
            {
                _y += _ySpeed;
                if (_y + _height > mainForm.ClientSize.Height)
                {
                    _y = mainForm.ClientSize.Height - _height;
                }

            }
        }

        public void MoveX(bool _LeftRight)
        {
            if (_LeftRight == true)
            {
                _x -= _xSpeed;
                if (_x < 0)
                {
                    _x = 0;
                }
            }

            if (_LeftRight == false)
            {
                _x += _xSpeed;
                if (_x + _height > mainForm.ClientSize.Height)
                {
                    _x = mainForm.ClientSize.Height - _height;
                }

            }
        }

    }

}
