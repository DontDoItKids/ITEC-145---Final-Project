using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC_145___Final_Project___Trey_Hall
{
    internal class Player
    {
        //Fields
        private int _x;
        private int _y;

        private int _xSpeed = 15;
        private int _ySpeed = 15;

        private int _height = 30;
        private int _width = 30;

        private Pen _pen;
        private Brush _brush;

        //Constructor make it take a file path for the image
        public Player(int x, int y)
        {
            _x = x;
            _y = y;

            _brush = new SolidBrush(Color.Black);
        }

        //Properties


        //Methods
        public void Draw(Graphics gr)
        {
            gr.FillEllipse(_brush, _x, _y, _width, _height);
        }

    }

}
