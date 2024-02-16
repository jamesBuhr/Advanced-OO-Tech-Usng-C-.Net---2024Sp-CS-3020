namespace WinFormsApp_1
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
            monthCalendar1 = new MonthCalendar();
            progressBar1 = new ProgressBar();
            checkedListBox1 = new CheckedListBox();
            checkedListBox2 = new CheckedListBox();
            checkedListBox3 = new CheckedListBox();
            checkedListBox4 = new CheckedListBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolStrip1 = new ToolStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog2 = new SaveFileDialog();
            fontDialog1 = new FontDialog();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar2 = new ToolStripProgressBar();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            sAVEToolStripMenuItem = new ToolStripMenuItem();
            iMPORTToolStripMenuItem = new ToolStripMenuItem();
            eXPORTToolStripMenuItem = new ToolStripMenuItem();
            eMAILToolStripMenuItem = new ToolStripMenuItem();
            eMAILAGENDAToolStripMenuItem = new ToolStripMenuItem();
            eXITToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            richTextBox1 = new RichTextBox();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(907, 79);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(47, 50);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(826, 52);
            progressBar1.TabIndex = 1;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(58, 126);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(815, 76);
            checkedListBox1.TabIndex = 3;
            // 
            // checkedListBox2
            // 
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Location = new Point(58, 229);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(815, 76);
            checkedListBox2.TabIndex = 4;
            // 
            // checkedListBox3
            // 
            checkedListBox3.FormattingEnabled = true;
            checkedListBox3.Location = new Point(58, 320);
            checkedListBox3.Name = "checkedListBox3";
            checkedListBox3.Size = new Size(815, 76);
            checkedListBox3.TabIndex = 5;
            // 
            // checkedListBox4
            // 
            checkedListBox4.FormattingEnabled = true;
            checkedListBox4.Location = new Point(58, 416);
            checkedListBox4.Name = "checkedListBox4";
            checkedListBox4.Size = new Size(815, 76);
            checkedListBox4.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(391, 59);
            label1.Name = "label1";
            label1.Size = new Size(110, 32);
            label1.TabIndex = 7;
            label1.Text = "daily EXP";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(907, 409);
            button1.Name = "button1";
            button1.Size = new Size(404, 59);
            button1.TabIndex = 8;
            button1.Text = "Add event ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += label1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(907, 474);
            button2.Name = "button2";
            button2.Size = new Size(404, 62);
            button2.TabIndex = 9;
            button2.Text = "Remove event ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1 });
            toolStrip1.Location = new Point(0, 40);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1786, 25);
            toolStrip1.TabIndex = 10;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 19);
            // 
            // fontDialog1
            // 
            fontDialog1.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(32, 32);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar2 });
            statusStrip1.Location = new Point(0, 783);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1786, 27);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar2
            // 
            toolStripProgressBar2.Name = "toolStripProgressBar2";
            toolStripProgressBar2.Size = new Size(100, 15);
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1786, 40);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { sAVEToolStripMenuItem, iMPORTToolStripMenuItem, eXPORTToolStripMenuItem, eMAILToolStripMenuItem, eXITToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(102, 36);
            toolStripMenuItem1.Text = "MENU";
            // 
            // sAVEToolStripMenuItem
            // 
            sAVEToolStripMenuItem.Name = "sAVEToolStripMenuItem";
            sAVEToolStripMenuItem.Size = new Size(232, 44);
            sAVEToolStripMenuItem.Text = "SAVE";
            // 
            // iMPORTToolStripMenuItem
            // 
            iMPORTToolStripMenuItem.Name = "iMPORTToolStripMenuItem";
            iMPORTToolStripMenuItem.Size = new Size(232, 44);
            iMPORTToolStripMenuItem.Text = "IMPORT";
            // 
            // eXPORTToolStripMenuItem
            // 
            eXPORTToolStripMenuItem.Name = "eXPORTToolStripMenuItem";
            eXPORTToolStripMenuItem.Size = new Size(232, 44);
            eXPORTToolStripMenuItem.Text = "EXPORT";
            // 
            // eMAILToolStripMenuItem
            // 
            eMAILToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { eMAILAGENDAToolStripMenuItem });
            eMAILToolStripMenuItem.Name = "eMAILToolStripMenuItem";
            eMAILToolStripMenuItem.Size = new Size(232, 44);
            eMAILToolStripMenuItem.Text = "EMAIL";
            // 
            // eMAILAGENDAToolStripMenuItem
            // 
            eMAILAGENDAToolStripMenuItem.Name = "eMAILAGENDAToolStripMenuItem";
            eMAILAGENDAToolStripMenuItem.Size = new Size(312, 44);
            eMAILAGENDAToolStripMenuItem.Text = "EMAIL AGENDA";
            // 
            // eXITToolStripMenuItem
            // 
            eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            eXITToolStripMenuItem.Size = new Size(232, 44);
            eXITToolStripMenuItem.Text = "EXIT ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.RosyBrown;
            panel1.Location = new Point(911, 564);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 200);
            panel1.TabIndex = 13;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(47, 564);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(718, 121);
            richTextBox1.TabIndex = 14;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // button3
            // 
            button3.Location = new Point(47, 718);
            button3.Name = "button3";
            button3.Size = new Size(150, 46);
            button3.TabIndex = 15;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(233, 718);
            button4.Name = "button4";
            button4.Size = new Size(150, 46);
            button4.TabIndex = 16;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(421, 718);
            button5.Name = "button5";
            button5.Size = new Size(150, 46);
            button5.TabIndex = 17;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(609, 718);
            button6.Name = "button6";
            button6.Size = new Size(150, 46);
            button6.TabIndex = 18;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            button6.MouseClick += button6_MouseClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1786, 810);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(richTextBox1);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(checkedListBox4);
            Controls.Add(checkedListBox3);
            Controls.Add(checkedListBox2);
            Controls.Add(checkedListBox1);
            Controls.Add(progressBar1);
            Controls.Add(monthCalendar1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private ProgressBar progressBar1;
        private CheckedListBox checkedListBox1;
        private CheckedListBox checkedListBox2;
        private CheckedListBox checkedListBox3;
        private CheckedListBox checkedListBox4;
        private Label label1;
        private Button button1;
        private Button button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolStrip toolStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private SaveFileDialog saveFileDialog1;
        private SaveFileDialog saveFileDialog2;
        private FontDialog fontDialog1;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem sAVEToolStripMenuItem;
        private ToolStripMenuItem iMPORTToolStripMenuItem;
        private ToolStripMenuItem eXPORTToolStripMenuItem;
        private ToolStripMenuItem eMAILToolStripMenuItem;
        private ToolStripMenuItem eMAILAGENDAToolStripMenuItem;
        private ToolStripMenuItem eXITToolStripMenuItem;
        private Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private RichTextBox richTextBox1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}