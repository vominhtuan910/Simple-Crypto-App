namespace Project1_UI
{
    partial class Dec_Page
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            plaintext_exbtn = new Button();
            home_btn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 92);
            label1.Name = "label1";
            label1.Size = new Size(118, 25);
            label1.TabIndex = 0;
            label1.Text = "Choose a file:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 154);
            label2.Name = "label2";
            label2.Size = new Size(147, 25);
            label2.TabIndex = 1;
            label2.Text = "Enter private key:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(163, 86);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(488, 31);
            textBox1.TabIndex = 2;
            
            // 
            // textBox2
            // 
            textBox2.Location = new Point(165, 154);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(486, 124);
            textBox2.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(676, 83);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(676, 200);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 5;
            button2.Text = "Browse";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // plaintext_exbtn
            // 
            plaintext_exbtn.Location = new Point(43, 313);
            plaintext_exbtn.Name = "plaintext_exbtn";
            plaintext_exbtn.Size = new Size(258, 61);
            plaintext_exbtn.TabIndex = 6;
            plaintext_exbtn.Text = "Export decrypted file";
            plaintext_exbtn.UseVisualStyleBackColor = true;
            plaintext_exbtn.Click += plaintext_exbtn_Click;
            // 
            // home_btn
            // 
            home_btn.Location = new Point(482, 313);
            home_btn.Name = "home_btn";
            home_btn.Size = new Size(250, 61);
            home_btn.TabIndex = 7;
            home_btn.Text = "Back to Home";
            home_btn.UseVisualStyleBackColor = true;
            home_btn.Click += home_btn_Click;
            // 
            // Dec_Page
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(home_btn);
            Controls.Add(plaintext_exbtn);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Dec_Page";
            Text = "Decryption";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Button plaintext_exbtn;
        private Button home_btn;
    }
}