using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace prezent
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var cipher = new CaesarCipher();
            string text = File.ReadAllText("encript.txt");
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            string message = Encoding.UTF8.GetString(bytes);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var secretKey1 = textBox3.Text;
            int secretKey = Int32.Parse(secretKey1);
            var encryptedText = cipher.Encrypt(text, secretKey);
            textBox2.Text =(encryptedText);
            stopwatch.Stop();
            textBox4.Text = stopwatch.Elapsed.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cipher = new CaesarCipher();
            var message = textBox1.Text;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var secretKey1 = textBox3.Text;
            int secretKey = Int32.Parse(secretKey1); 
            var encryptedText = cipher.Encrypt(message, secretKey);
            textBox2.Text=(encryptedText);
            stopwatch.Stop();
            textBox4.Text = stopwatch.Elapsed.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cipher = new CaesarCipher();
            var message = textBox2.Text;
            var secretKey1 = textBox3.Text;
            var secretKey = Int32.Parse(secretKey1);
            Stopwatch startwatch = new Stopwatch();
            startwatch.Start();
            var encryptedText = cipher.Encrypt(message, secretKey);
            textBox1.Text= (cipher.Decrypt(encryptedText, secretKey));
            startwatch.Stop();
            textBox4.Text = startwatch.Elapsed.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var cipher = new CaesarCipher();
            string text = File.ReadAllText("decrypt.txt");
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            string message = Encoding.UTF8.GetString(bytes);
            Stopwatch startwatch = new Stopwatch();
            startwatch.Start();
            var secretKey1 = textBox3.Text;
            var secretKey = Int32.Parse(secretKey1);
            var encryptedText = cipher.Encrypt(message, secretKey);
            textBox1.Text = (cipher.Decrypt(encryptedText, secretKey));
            startwatch.Stop();
            textBox4.Text = startwatch.Elapsed.ToString();

        }
    }
}
