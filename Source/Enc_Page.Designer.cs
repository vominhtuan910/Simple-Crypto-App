namespace Project1_UI
{
    partial class Enc_Page
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
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            privateKey_exbtn = new Button();
            ciphertext_exbtn = new Button();
            home_btn = new Button();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(12, 46);
            label1.Name = "label1";
            label1.Size = new Size(118, 25);
            label1.TabIndex = 0;
            label1.Text = "Choose a file:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(149, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(521, 31);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged_1;
            textBox1.ReadOnly = true;
            // 
            // button1
            // 
            button1.Location = new Point(676, 37);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 2;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 113);
            label2.Name = "label2";
            label2.Size = new Size(159, 25);
            label2.TabIndex = 3;
            label2.Text = "Your private key is:";
            // 
            // privateKey_exbtn
            // 
            privateKey_exbtn.Location = new Point(33, 307);
            privateKey_exbtn.Name = "privateKey_exbtn";
            privateKey_exbtn.Size = new Size(245, 64);
            privateKey_exbtn.TabIndex = 5;
            privateKey_exbtn.Text = "Export private key";
            privateKey_exbtn.UseVisualStyleBackColor = true;
            privateKey_exbtn.Click += privateKey_exbtn_Click;
            // 
            // ciphertext_exbtn
            // 
            ciphertext_exbtn.Location = new Point(328, 307);
            ciphertext_exbtn.Name = "ciphertext_exbtn";
            ciphertext_exbtn.Size = new Size(238, 64);
            ciphertext_exbtn.TabIndex = 6;
            ciphertext_exbtn.Text = "Export encrypted file";
            ciphertext_exbtn.UseVisualStyleBackColor = true;
            ciphertext_exbtn.Click += ciphertext_exbtn_Click;
            // 
            // home_btn
            // 
            home_btn.Location = new Point(599, 311);
            home_btn.Name = "home_btn";
            home_btn.Size = new Size(267, 56);
            home_btn.TabIndex = 7;
            home_btn.Text = "Back to Home";
            home_btn.UseVisualStyleBackColor = true;
            home_btn.Click += home_btn_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(24, 157);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(829, 121);
            textBox2.TabIndex = 8;
            // 
            // Enc_Page
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 450);
            Controls.Add(textBox2);
            Controls.Add(home_btn);
            Controls.Add(ciphertext_exbtn);
            Controls.Add(privateKey_exbtn);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Enc_Page";
            Text = "Encryption";
            Load += Enc_Page_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private Button privateKey_exbtn;
        private Button ciphertext_exbtn;
        private Button home_btn;
        private TextBox textBox2;
    }
}