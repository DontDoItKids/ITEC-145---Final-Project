using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Intrinsics.X86;

namespace ITEC_145___Final_Project___Trey_Hall
{
    public partial class Form1 : Form
    {
        Player p1;

        List<Bullet> bullets = new List<Bullet>();
        List<Zombie> zombies = new List<Zombie>();
        List<Powerups> powerUps = new List<Powerups>();

        bool UpOrDown;
        bool LeftOrRight;

        public Point mouseLoc;
        public Point playerLoc;

        int seconds;
        int minutes;
        int score;

        bool power1 = false;
        bool power2 = false;
        bool power3 = false;

        Random rndWidth = new Random();
        Random rndHeight = new Random();

        public enum KeyMove { none = 0, up = 1, down = 2, left = 4, right = 8 }
        KeyMove keyPlayer = KeyMove.none;

        public Form1()
        {
            InitializeComponent();

            Player.mainForm = this;
            Bullet.mainForm = this;
            Zombie.mainForm = this;
            Powerups.mainForm = this;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            p1 = new Player(156, 156);

            //Enable to see player and mouse location
            label1.Enabled = false;
            label1.Visible = false;
        }

        //Events -----
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
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

            foreach (Zombie z in zombies)
            {
                z.Spawn(e.Graphics);
            }

            foreach (Bullet b in bullets)
            {
                b.Shoot(e.Graphics);
            }

            foreach (Powerups p in powerUps)
            {
                p.Spawn(e.Graphics);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (power1 == true)
                {
                    Bullet b1 = new Bullet(mouseLoc, playerLoc);
                    b1.Width = 15;
                    b1.Height = 15;
                    bullets.Add(b1);
                }
                else
                {
                    Bullet b1 = new Bullet(mouseLoc, playerLoc);
                    bullets.Add(b1);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStart.Visible = false;

            lblInstructions.Enabled = false;
            lblInstructions.Visible = false;

            timer1.Enabled = true;
            ZombieSpawn.Enabled = true;
            Clock.Enabled = true;
        }

        //Timers -----
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate(false);

            if ((keyPlayer & KeyMove.up) == KeyMove.up)
            {
                UpOrDown = true;
                p1.MoveY(UpOrDown);
            }
            if ((keyPlayer & KeyMove.down) == KeyMove.down)
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
            catch { }

            try //Wrapping things in try catch to make them work is not a great solution... but Oh Boy does it work.
            {
                foreach (Bullet b in bullets)
                {
                    foreach (Zombie z in zombies)
                    {
                        if (Collision(z, b))
                        {
                            z.Die();
                            zombies.Remove(z);
                            bullets.Remove(b);
                            score++;
                        }
                    }
                }
            }
            catch { }

            foreach (Zombie z in zombies)
            {
                if (Collision(z, p1))
                { GameOver(); }
            }

            try
            {
                foreach (Powerups p in powerUps)
                {
                    if (Collision(p, p1))
                    {
                        int pow;
                        pow = (int)p.YourMother;

                        if (pow == 0)
                        {
                            power1 = true;
                            powerTimer.Enabled = true;
                        }
                        else if (pow == 1)
                        {
                            power2 = true;
                            powerTimer.Enabled = true;
                        }
                        else if (pow == 2)
                        {
                            power3 = true;
                            powerTimer.Enabled = true;
                        }
                        powerUps.Remove(p);
                    }
                }

            }
            catch { }

            if (power2 == true)
            {
                p1.Xspeed = 7;
                p1.Yspeed = 7;
            }

            if (power3 == true)
            {
                p1.Width = 15;
                p1.Height = 15;
            }

            if (score >= 250)
            {
                MessageBox.Show("Get a Life");
            }

            lblScore.Text = $"Score: {score}";
            mouseLoc = this.PointToClient(Cursor.Position);
            //Debug
            //label1.Text = $"X = {mouseLoc.X} Y = {mouseLoc.Y} Player X = {playerLoc.X} Player Y = {playerLoc.Y}";
        }

        private void ZombieSpawn_Tick(object sender, EventArgs e)
        {
            Zombie Zom = new Zombie();
            zombies.Add(Zom);
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
                if (ZombieSpawn.Interval > 800)
                    ZombieSpawn.Interval -= 50;
            }

            if (seconds < 10)
            {
                lblClock.Text = $"{minutes}:0{seconds}";
            }
            else
            {
                lblClock.Text = $"{minutes}:{seconds}";
            }

            if (seconds == 45 && minutes >= 1)
            {
                Powerups powar = new Powerups();
                powerUps.Add(powar);

                if (powar.YourMother == Powerups.Powers.BigBullet)
                {
                    power1 = true;
                }
                else if (powar.YourMother == Powerups.Powers.FasterMove)
                {
                    power2 = true;
                }
                else if (powar.YourMother == Powerups.Powers.Small)
                {
                    power3 = true;
                }
            }
            else if (seconds == 45)
            {
                Powerups powar = new Powerups();
                powerUps.Add(powar);
            }

        }

        private void powerTimer_Tick(object sender, EventArgs e)
        {
            power1 = false;
            power2 = false;
            power3 = false;

            p1.Xspeed = 5;
            p1.Yspeed = 5;
            p1.Width = 30;
            p1.Height = 30;

            powerTimer.Enabled = false;
        }

        //Methods -----
        private bool Collision(Zombie zom, Bullet bul)
        {
            if (zom.X + zom.Width < bul.X)
            {
                return false;
            }
            if (bul.X + bul.Width < zom.X)
            {
                return false;
            }
            if (zom.Y + zom.Height < bul.Y)
            {
                return false;
            }
            if (bul.Y + bul.Height < zom.Y)
            {
                return false;
            }

            return true;
        }

        private bool Collision(Zombie zom, Player ply)
        {
            if (zom.X + zom.Width < ply.X)
            {
                return false;
            }
            if (ply.X + ply.Width < zom.X)
            {
                return false;
            }
            if (zom.Y + zom.Height < ply.Y)
            {
                return false;
            }
            if (ply.Y + ply.Height < zom.Y)
            {
                return false;
            }

            return true;
        }

        private bool Collision(Powerups pow, Player ply)
        {
            if (pow.X + pow.Width < ply.X)
            {
                return false;
            }
            if (ply.X + ply.Width < pow.X)
            {
                return false;
            }
            if (pow.Y + pow.Height < ply.Y)
            {
                return false;
            }
            if (ply.Y + ply.Height < pow.Y)
            {
                return false;
            }

            return true;
        }

        private void GameOver()
        {
            timer1.Stop();
            ZombieSpawn.Stop();

            MessageBox.Show("You Dead");
        }
    }
}