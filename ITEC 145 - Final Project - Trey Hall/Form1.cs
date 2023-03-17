namespace ITEC_145___Final_Project___Trey_Hall
{
    public partial class Form1 : Form
    {
        Player p1;

        bool UpOrDown;
        bool LeftOrRight;

        public enum KeyMove { none, up, down, left, right }
        KeyMove keyPlayer = KeyMove.none;

        public Form1()
        {
            InitializeComponent();
            Player.mainForm = this;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            p1 = new Player(155, 155);

            timer1.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                UpOrDown = true;
                keyPlayer = KeyMove.up;
            }
            else if (e.KeyCode == Keys.S)
            {
                UpOrDown = false;
                keyPlayer = KeyMove.down;
            }
            else if (e.KeyCode == Keys.A)
            {
                LeftOrRight = true;
                keyPlayer = KeyMove.left;
            }
            else if (e.KeyCode == Keys.D)
            {
                LeftOrRight= false;
                keyPlayer = KeyMove.right;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) keyPlayer = KeyMove.none;
            else if (e.KeyCode == Keys.S) keyPlayer = KeyMove.none;
            else if (e.KeyCode == Keys.A) keyPlayer = KeyMove.none;
            else if (e.KeyCode == Keys.D) keyPlayer = KeyMove.none;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            p1.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate(false);

            if(keyPlayer == KeyMove.up)
            {
                p1.MoveY(UpOrDown);
            }
            if(keyPlayer == KeyMove.down)
            {
                p1.MoveY(UpOrDown);
            }
            if (keyPlayer == KeyMove.left)
            {
                p1.MoveX(LeftOrRight);
            }
            if (keyPlayer == KeyMove.right)
            {
                p1.MoveX(LeftOrRight);
            }
        }

    }
}