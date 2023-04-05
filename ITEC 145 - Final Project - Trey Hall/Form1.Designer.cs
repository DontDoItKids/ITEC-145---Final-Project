namespace ITEC_145___Final_Project___Trey_Hall
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            ZombieSpawn = new System.Windows.Forms.Timer(components);
            btnStart = new Button();
            lblInstructions = new Label();
            Clock = new System.Windows.Forms.Timer(components);
            lblClock = new Label();
            lblScore = new Label();
            powerTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 20;
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // ZombieSpawn
            // 
            ZombieSpawn.Interval = 1500;
            ZombieSpawn.Tick += ZombieSpawn_Tick;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Azure;
            btnStart.FlatAppearance.BorderColor = Color.Black;
            btnStart.FlatAppearance.MouseDownBackColor = Color.FromArgb(215, 214, 244);
            btnStart.FlatAppearance.MouseOverBackColor = Color.White;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location = new Point(264, 135);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(300, 150);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblInstructions.Location = new Point(275, 288);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(267, 14);
            lblInstructions.TabIndex = 3;
            lblInstructions.Text = "W,A,S,D for Movement - Mouse to Aim and Shoot";
            // 
            // Clock
            // 
            Clock.Interval = 1000;
            Clock.Tick += Clock_Tick;
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.Font = new Font("Segoe UI", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point);
            lblClock.Location = new Point(382, 9);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(49, 21);
            lblClock.TabIndex = 4;
            lblClock.Text = "00:00";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 11.7818184F, FontStyle.Regular, GraphicsUnit.Point);
            lblScore.Location = new Point(744, 9);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(65, 21);
            lblScore.TabIndex = 5;
            lblScore.Text = "Score: 0";
            // 
            // powerTimer
            // 
            powerTimer.Interval = 5000;
            powerTimer.Tick += powerTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 461);
            Controls.Add(lblScore);
            Controls.Add(lblClock);
            Controls.Add(lblInstructions);
            Controls.Add(btnStart);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            MouseClick += Form1_MouseClick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private System.Windows.Forms.Timer ZombieSpawn;
        private Button btnStart;
        private Label lblInstructions;
        private System.Windows.Forms.Timer Clock;
        private Label lblClock;
        private Label lblScore;
        private System.Windows.Forms.Timer powerTimer;
    }
}