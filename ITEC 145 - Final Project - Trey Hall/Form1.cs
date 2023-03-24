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

        Point mouseLoc;
        Point playerLoc;

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

            //Lets figure out the centre point for the Player
            playerLoc = new Point(p1.X + (p1.Width / 2), p1.Y + (p1.Height / 2));
            p1.CentreLoc = playerLoc;


            //Switching between the two modes of zombie movement. Might move to a seperate timer.
            movement = rnd.Next();
            if(movement % 2 == 0)
            {
                z1.MoveToPlayer(playerLoc, p1.Width, p1.Height);
            }

            else if (movement % 2 != 0)
            {
                z1.MoveRandom();
            }


            //Is the mouse move event a better place for this?
            //Probably cause then it fires every time the mouse moves not every time tick.
            //Oh well it stays here for now.
            mouseLoc = this.PointToClient(Cursor.Position);
            label1.Text = $"X = {mouseLoc.X} Y = {mouseLoc.Y} Player X = {playerLoc.X} Player Y = {playerLoc.Y}";

        }






        //Thinking Space

        //Point X(250, 250)
        //Point Y(300, 300)

        //difference of(50, 50)

        //So to get to from x to Y
        //Redraw the bullet at incremental points ie.
        //(251, 251)
        //(252, 252)
        //(253, 253) etc.

        //Need to figure out the math to do this.
        //How to get the value to increment by.

        //Point Player (712, 159)
        //Point Mouse(257, 129)

        //To Figure out the difference do 
        //Player.x - Mouse.X = diffX = 455
        //Player.Y - Mouse.Y = diffY = 30

        //Divde X by the Y to figure out how much to move 455 / 30 = 15.16

        //So move 15 X and 1 Y each increment.
        //Might be Better to figure out Which is the bigger number.
        //Have too actually otherwise due to rounding X could end up being 0.

        //if (diffX > diffY)
        //{
        //	diffX / diffY = moveX
        //    moveY = 1
        //}

        //if (diffX<diffY)
        //{
        //	diffY / diffX = moveY
        //    moveX = 1
        //}

        //if (diffX = diffY)
        //{
        //    moveX = 1

        //    moveY = 1
        //}



    }
}