using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Intrinsics.X86;

namespace ITEC_145___Final_Project___Trey_Hall
{
    public partial class Form1 : Form
    {
        Player p1;
        Zombie z1;
        
        List<Bullet> bullets = new List<Bullet>();
        //https://stackoverflow.com/questions/55010535/c-sharp-finding-angle-between-2-given-points
        bool UpOrDown;
        bool LeftOrRight;

        public Point mouseLoc;
        public Point playerLoc;

        public enum KeyMove { none = 0, up = 1, down = 2, left = 4, right = 8 }
        KeyMove keyPlayer = KeyMove.none;

        public Form1()
        {
            InitializeComponent();

            Player.mainForm = this;
            Bullet.mainForm = this;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            
            p1 = new Player(156, 156);
            z1 = new Zombie();
            

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
            z1.Spawn(e.Graphics, 0, 0);

            foreach(Bullet b in bullets)
            {
                b.Shoot(e.Graphics);
            }
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

            //Lets figure out the centre point for the Player
            playerLoc = new Point(p1.X + (p1.Width / 2), p1.Y + (p1.Height / 2));
            p1.CentreLoc = playerLoc;

            //Getting rid of the bullets that go off screen
            try //Putting this in a try catch makes it work for some reason
            {
                foreach (Bullet b in bullets)
                {
                    if (b.X < 0 || b.Y < 0 || b.X > ClientSize.Width || b.Y > ClientSize.Height)
                    {
                        bullets.Remove(b);
                    }
                }
            }
            catch
            { }

            //Debug
            mouseLoc = this.PointToClient(Cursor.Position);
            label1.Text = $"X = {mouseLoc.X} Y = {mouseLoc.Y} Player X = {playerLoc.X} Player Y = {playerLoc.Y}";
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Bullet b1 = new Bullet(mouseLoc, playerLoc);
                bullets.Add(b1);
            }
        }

    }
}