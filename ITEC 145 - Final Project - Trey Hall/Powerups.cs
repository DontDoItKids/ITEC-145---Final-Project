using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC_145___Final_Project___Trey_Hall
{
    internal class Powerups
    {
        static public Form1 mainForm;

        //Fields
        private int _height = 20;
        private int _width = 35;

        private int _x;
        private int _y;

        private int _power;

        private Random _rnd = new Random();

        private Brush _brush;

        public enum Powers {BigBullet, FasterMove, Small}
        Powers powerUp;

        //Properties
        public Powers YourMother { get { return powerUp; } }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Height { get { return _height; } }
        public int Width { get { return _width; } }

        //Constructor
        public Powerups()
        {
            _brush = new SolidBrush(Color.Gray);

            _x = _rnd.Next(_width, mainForm.ClientSize.Width - (int)(_width * 1.5));
            _y = _rnd.Next(_height, mainForm.ClientSize.Height - (int)(_height * 1.5));

            _power = _rnd.Next(0,3);

            if (_power == 0)
            {
                powerUp = Powers.BigBullet;
            }
            else if (_power == 1)
            {
                powerUp = Powers.FasterMove;
            }
            else if (_power == 2)
            {
                powerUp = Powers.Small;
            }
        }

        //Methods
        public void Spawn(Graphics gr)
        {
            gr.FillRectangle(_brush, _x, _y, _width, _height);
        }

    }
}
