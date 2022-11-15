using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryFileManager
{
    public partial class Form2 : Form
    {
        public static bool modified=false;
        public string path;
        public Form2(string path)
        {
            InitializeComponent();
            
            this.path = path;
            try
            {
                StreamReader sr = new StreamReader(path);

                textBoxArquivoTxt.Text = sr.ReadToEnd();
                textBoxArquivoTxt.Enabled = !new FileInfo(path).IsReadOnly;
                modified = false;
                sr.Close();
            }
            catch (IOException)
            {
                
                //no se pudo leer el archivo
                throw;
            }

        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            modified = true;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBoxArquivoTxt.Enabled && modified)
            {
                DialogResult resposta = MessageBox.Show("Quere sobreescribir os cambios?", "Formulario", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter(path);
                        sw.Write(textBoxArquivoTxt.Text);
                        sw.Close();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }else if (resposta == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
