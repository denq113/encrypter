using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
public class CaesarCipher
{
    //символы русской азбуки
    const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

    private string CodeEncode(string text, int k)
    {
        //добавляем в алфавит маленькие буквы
        var fullAlfabet = alfabet + alfabet.ToLower();
        var letterQty = fullAlfabet.Length;
        var retVal = "";
        for (int i = 0; i < text.Length; i++)
        {
            var c = text[i];
            var index = fullAlfabet.IndexOf(c);
            if (index < 0)
            {
                //если символ не найден, то добавляем его в неизменном виде
                retVal += c.ToString();
            }
            else
            {
                var codeIndex = (letterQty + index + k) % letterQty;
                retVal += fullAlfabet[codeIndex];
            }
        }

        return retVal;
    }
    //шифрование текста
    public string Encrypt(string plainMessage, int key)
        => CodeEncode(plainMessage, key);

    //дешифрование текста
    public string Decrypt(string encryptedMessage, int key)
        => CodeEncode(encryptedMessage, -key * 2);
}
internal class RsaEncryption
{
    private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
    private RSAParameters _privateKey;
    private RSAParameters _publicKey;
    public RsaEncryption()
    {
        _privateKey = csp.ExportParameters(true);
        _publicKey = csp.ExportParameters(false);
    }
    public string GetPublickey()
    {
        var sw = new StringWriter();
        var xs = new XmlSerializer(typeof(RSAParameters));
        xs.Serialize(sw, _publicKey);
        return sw.ToString();
    }
    public string Encrypt(string plaintext)
    {
        csp = new RSACryptoServiceProvider();
        csp.ImportParameters(_publicKey);
        var data = Encoding.Unicode.GetBytes(plaintext);
        var cypher = csp.Encrypt(data, false);
        return Convert.ToBase64String(cypher);
    }
    public string Decrypt(string cypherText)
    {
        var dataByres = Convert.FromBase64String(cypherText);
        csp.ImportParameters(_privateKey);
        var plainText = csp.Decrypt(dataByres, false);
        return Encoding.Unicode.GetString(plainText);

    }
}

namespace prezent
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
