using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

using MyCryptography;


namespace Project1_UI
{
    public partial class Enc_Page : Form
    {
        private bool can_openFile = false;
        private string[] pubprikeys = new string[2];
        public Enc_Page()
        {
            InitializeComponent();
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Browse to choose a file to encrypt
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                //fileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = fileDialog.FileName;
                }
            }
        }

        // Export private key
        private void privateKey_exbtn_Click(object sender, EventArgs e)
        {
            string Ks = textBox2.Text;

            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                fileDialog.AddExtension = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(fileDialog.FileName, Ks);
                    MessageBox.Show("Key has been saved successfully !");
                }
            }
        }

        private void Enc_Page_Load(object sender, EventArgs e)
        {

        }

        private void ciphertext_exbtn_Click(object sender, EventArgs e)
        {
            if (can_openFile)
            {
                string iv = AES.GenIV();

                // Read the file to encrypt
                string enc_file = textBox1.Text;
                string contents = File.ReadAllText(enc_file);

                // Generate secret key
                string Ks = AES.GenSecretKey();

                // Encrypt the file
               AES.EncryptFile(enc_file, Ks, iv);
                
                //--------------------------------------------------------------------------------                                             

                // Encrypt secret key
                string Kx = RSA.Encryption(pubprikeys[0], Ks);

                // Hash private key
                string HKprivate = HashFunctions.SHA1_Hash(pubprikeys[1]);

                // Save private key and iv
                string enc_file_name = Path.GetFileNameWithoutExtension(enc_file);
                string enc_file_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), enc_file_name + "_info.txt");
                string extension = Path.GetExtension(enc_file);

                using (StreamWriter sw = new StreamWriter(enc_file_path))
                {
                    sw.WriteLine(Kx);
                    sw.WriteLine(HKprivate);
                    sw.WriteLine(iv);
                    sw.WriteLine(extension);
                }

                MessageBox.Show("Cipher text has been save successfully !");
            }           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string enc_file = textBox1.Text;
                if (File.Exists(enc_file))
                {
                    // Generate public key and private key RSA
                    pubprikeys = RSA.GenerateKeys();
                    textBox2.Text = pubprikeys[1];  
                    can_openFile = true;
                }
                else
                {
                    textBox2.Text = "Could not find the file " + "\"" + enc_file +  "\"";
                    can_openFile = false;
                }

            }
        }
    }
}
