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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            RsaEncryption rsa = new RsaEncryption();
            string cyper = string.Empty;
            textBox3.Text = rsa.GetPublickey();
            stopwatch1.Stop();
            textBox4.Text = stopwatch1.Elapsed.ToString();
            string text = textBox1.Text;
            if (!string.IsNullOrEmpty(text))
            {
                cyper = rsa.Encrypt(text);
                textBox2.Text = cyper;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            RsaEncryption rsa = new RsaEncryption();
            string cyper = string.Empty;
            textBox3.Text = rsa.GetPublickey();
            stopwatch1.Stop();
            textBox4.Text = stopwatch1.Elapsed.ToString();
            string textov = File.ReadAllText("encript.txt");
            byte[] bytes = Encoding.UTF8.GetBytes(textov);
            string text = Encoding.UTF8.GetString(bytes);
            if (!string.IsNullOrEmpty(text))
            {
                cyper = rsa.Encrypt(text);
                textBox2.Text = cyper;
            }
            var plaintext = rsa.Decrypt(cyper);

           textBox1.Text =plaintext;
        }
    }
}
