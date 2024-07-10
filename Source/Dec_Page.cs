using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyCryptography;

namespace Project1_UI
{
    public partial class Dec_Page : Form
    {
        
        public Dec_Page()
        {
            InitializeComponent();
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Browse to choose a file to decrypt
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Metadata files (*.metadata)|*.metadata|All files (*.*)|*.*";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Assign file path to the textbox
                    textBox1.Text = fileDialog.FileName;
                }
            }
        }

        // Browse to choose a file containing key
        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(fileDialog.FileName))
                    {
                        textBox2.Text = reader.ReadToEnd();
                    }
                }
            }
        }

        // Export decrypted file
        private void plaintext_exbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please choose a file to decrypt !");
                return;
            }
            
            if(string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please provide the private key !");
                return;
            }

            // find _info.txt file
            string origin_file_name = Path.GetFileNameWithoutExtension(textBox1.Text); 
            string info_file_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + origin_file_name + "_info.txt";

            if(!File.Exists(info_file_path))
            {
                MessageBox.Show("Cannot find the info file !");
                return;
            }

            // Read info file
            string[] info = new string[4];
            using (var fileStream = File.OpenRead(info_file_path))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        info[i] = reader.ReadLine();
                    }
                }
            }

            // Extract information
            string Kx = info[0];
            string HKprivate = info[1];
            string iv = info[2];
            string origin_file_extension = info[3];

            string Kprivate = textBox2.Text;

            // Check if the private key is correct
            if (HKprivate != HashFunctions.SHA1_Hash(Kprivate))
            {
                MessageBox.Show("Decryption failed !");
                return;
            }

            // Decrypt the file
            string cipher_file_path = textBox1.Text;
            string Ks = RSA.Decryption(Kprivate, Kx);
            AES.DecryptFile(cipher_file_path, Ks, iv, origin_file_extension);

            MessageBox.Show("Decrypted file has been saved successfully !");
        }
    }
}
