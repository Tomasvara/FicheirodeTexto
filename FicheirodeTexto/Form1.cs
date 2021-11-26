using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.IO;
using System.Text.RegularExpressions;


namespace FicheirodeTexto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string texto = "";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                texto = File.ReadAllText(openFileDialog1.FileName);
            txtCouteudo.Text = texto.ToString();



        }

        private void btnlimpar_Click(object sender, EventArgs e)
        {
            txtCouteudo.Clear();
        }

        private void btnContar_Click(object sender, EventArgs e)
        {
            // |-----------------------------------------------------------------------|
            // Contar palavras
            string texto = txtCouteudo.Text;

            char[] separator = { ' ' };
            texto = texto.Replace(Environment.NewLine, " ");

            int wordsCount = texto.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;
            int quantPlv = wordsCount;

            // |-----------------------------------------------------------------------|
            // Contar Caracteres 

            int quantCrc = 0;
            int i;
            for (i = 0; i < texto.Length; i++)
            {
                quantCrc++;
            }

            // |-----------------------------------------------------------------------|
            // Contar Paragrafo

            string textoPrf = txtCouteudo.Text.Trim();
            
            int quantPrf = 0;
            int prf;
            for (prf= 0; prf < textoPrf.Length; prf++)
            {
                if (textoPrf[prf] == '.' || textoPrf[prf] == '?' || textoPrf[prf] == '!')
                {
                    quantPrf++;
                }
            }
           
            // |-----------------------------------------------------------------------|

            string quant = "O ficheiro contém " + quantPlv + " palavras, " +quantCrc+ " caracteres e " +quantPrf+ " parágrafos.";
            txtQuant.Text = quant.ToString();
        }

        private void txtQuant_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (.txt)|.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(txtCouteudo.Text);
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


















}
