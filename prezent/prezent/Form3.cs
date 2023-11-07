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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText("encript.txt");
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            string m = Encoding.UTF8.GetString(bytes);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int y = 0;
            int j = 0;
            int b = 0;
            int a = m.Length;
            int[] notreal = new int[a];
            char[] massage = m.ToCharArray();
            char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', ',', '.', '?', '!', '<', '>', ' ' };
            for (int i = 0; i < massage.Length; i++)
            {
                for (j = 0; j < alfavit.Length; j++)
                {
                    y++;
                    if (massage[i] == alfavit[j])
                    {
                        notreal[b] = y;
                        b++;
                        y = 0;
                        break;
                    }
                }
            }
            textBox2.Text = (string.Join(" ", notreal));
            stopwatch.Stop();
            textBox4.Text = stopwatch.Elapsed.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText("decrypt.txt");
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            string message = Encoding.UTF8.GetString(bytes);
            int[] arr = message.Split().Select(i => int.Parse(i)).ToArray();
            int y = arr.Length;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int t = 0;
            int r = 0;
            char[] wow = new char[y];
            char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', ',', '.', '?', '!', '<', '>', ' ' };
            for (int i = 0; i < arr.Length; i++)
            {
                for (t = 0; arr[i] > t; t++)
                {
                    r++;
                }
                r = r - 1;
                wow[i] = alfavit[r];
                r = 0;
                t = 0;

            }
           textBox1.Text = (string.Join(" ", wow));
            stopwatch.Stop();
            textBox4.Text = stopwatch.Elapsed.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string m = textBox1.Text;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int y = 0;
            int b = 0;
            int j = 0;
            int a = m.Length;
            int[] notreal = new int[a];
            char[] massage = m.ToCharArray();
            char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', ',', '.', '?', '!', '<', '>', ' ' };
            for (int i = 0; i < massage.Length; i++)
            {
                for (j = 0; j < alfavit.Length; j++)
                {
                    y++;
                    if (massage[i] == alfavit[j])
                    {
                        notreal[b] = y;
                        b++;
                        y = 0;
                        break;
                    }
                }
            }
            textBox2.Text = (string.Join(" ", notreal));
            stopwatch.Stop();
            textBox4.Text = stopwatch.Elapsed.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] arr = textBox2.Text.Split().Select(i => int.Parse(i)).ToArray();
            int y = arr.Length;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int t = 0;
            int r = 0;
            char[] wow = new char[y];
            char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', ',', '.', '?', '!', '<', '>', ' ' };
            for (int i = 0; i < arr.Length; i++)
            {
                for (t = 0; arr[i] > t; t++)
                {
                    r++;
                }
                r = r - 1;
                wow[i] = alfavit[r];
                r = 0;
                t = 0;
            }
            textBox1.Text = (string.Join("", wow));
            stopwatch.Stop();
            textBox4.Text = stopwatch.Elapsed.ToString();
        }
    }
}
