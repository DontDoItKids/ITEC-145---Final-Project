namespace ITEC_145___Final_Project___Trey_Hall
{
    public partial class Form1 : Form
    {
        Player p1;
        Zombie z1;
        //https://stackoverflow.com/questions/55010535/c-sharp-finding-angle-between-2-given-points
        bool UpOrDown;
        bool LeftOrRight;

        Random rnd = new Random();
        int movement;

        //int mouseX;
        //int mouseY;

        Point mouseLoc;

        public enum KeyMove { none = 0, up = 1, down = 2, left = 4, right = 8 }
        KeyMove keyPlayer = KeyMove.none;

        public Form1()
        {
            InitializeComponent();
            Player.mainForm = this;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            p1 = new Player(156, 156);
            z1 = new Zombie(0, 0);

            timer1.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.W:
                    keyPlayer |= KeyMove.up;
                    break;
                case Keys.S:
                    keyPlayer |= KeyMove.down;
                    break;
                case Keys.A:
                    keyPlayer |= KeyMove.left;
                    break;
                case Keys.D:
                    keyPlayer |= KeyMove.right;
                    break;
            }
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.W:
                    keyPlayer &= ~KeyMove.up;
                    break;
                case Keys.S:
                    keyPlayer &= ~KeyMove.down;
                    break;
                case Keys.A:
                    keyPlayer &= ~KeyMove.left;
                    break;
                case Keys.D:
                    keyPlayer &= ~KeyMove.right;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            p1.Draw(e.Graphics);
            z1.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate(false);

            if((keyPlayer & KeyMove.up) == KeyMove.up)
            {
                UpOrDown = true;
                p1.MoveY(UpOrDown);
            }
            if((keyPlayer & KeyMove.down) == KeyMove.down)
            {
                UpOrDown = false;
                p1.MoveY(UpOrDown);
            }
            if ((keyPlayer & KeyMove.left) == KeyMove.left)
            {
                LeftOrRight = true;
                p1.MoveX(LeftOrRight);
            }
            if ((keyPlayer & KeyMove.right) == KeyMove.right)
            {
                LeftOrRight = false;
                p1.MoveX(LeftOrRight);
            }

            //Switching between the two modes of zombie movement. Might move to a seperate timer.
            movement = rnd.Next();
            if(movement % 2 == 0)
            {
                z1.MoveToPlayer(p1.X, p1.Y, p1.Width, p1.Height);
            }

            else if (movement % 2 != 0)
            {
                z1.MoveRandom();
            }

            //mouseX = MousePosition.X;
            //mouseY = MousePosition.Y;

            //label1.Text = $"X = {mouseX} Y = {mouseY}";

            mouseLoc = this.PointToClient(Cursor.Position);
            label1.Text = $"X = {mouseLoc.X} Y = {mouseLoc.Y}";

        }

    }
}