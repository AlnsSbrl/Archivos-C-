using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryFileManager
{
    public partial class Form1 : Form
    {
        static string path;
        public FileInfo arquivo;
        public Form1()
        {
            InitializeComponent();
        }

        private void BotonCambiarDirectorio_Click(object sender, EventArgs e)
        {
            try
            {
                path = textBoxPathDirectorio.Text;
                lbWarnings.Text = "";
                if (path.StartsWith("%") && path.EndsWith("%"))
                {
                    path = path.Trim('%');
                    Directory.SetCurrentDirectory(Environment.GetEnvironmentVariable(path));
                }
                else
                {
                    Directory.SetCurrentDirectory(path);
                    //TODO modificar los tries catches e poñer un so trai catch onde despois do control de excepcions NON se execute o metodo
                    //de cambiar listboxes
                }
                CambiarListBoxesSegunDirectorio();
            }
            catch (DirectoryNotFoundException)
            {
                lbWarnings.Text += "Non se atopou o directorio";
            }
            catch (System.Security.SecurityException)
            {
                lbWarnings.Text += "Non se pode acceder ao directorio";
            }
            catch (IOException)
            {
                lbWarnings.Text += "Erro na E/S de datos";
            }
            catch (ArgumentNullException)
            {
                lbWarnings.Text += "non existe esa variable de entorno";
            }
            catch (System.ArgumentException)
            {
                lbWarnings.Text += "O path non pode ser unha cadea vacía ou con espacios en branco";
            }
        }

        private void CambiarListBoxesSegunDirectorio()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            lbArquivoInfo.Text = "";
            listBoxArquivos.Items.Clear();
            listBoxSubdirectorios.Items.Clear();
            listBoxSubdirectorios.Items.Add("..\\");
            try
            {
                foreach (var arquivo in directoryInfo.GetFiles())
                {
                    listBoxArquivos.Items.Add(arquivo);
                }
                foreach (var directorio in directoryInfo.GetDirectories())
                {
                    listBoxSubdirectorios.Items.Add(directorio);
                }
                lbIndicaDirectorioActual.Text = "Directorio actual: " + Directory.GetCurrentDirectory().ToString();
            }
            catch (SystemException) { }
        }

        private void ListBoxSubdirectorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbWarnings.Text = "";
            try
            {
                if (listBoxSubdirectorios.SelectedIndex != -1)
                {
                    if (listBoxSubdirectorios.SelectedIndex == 0)
                    {
                        if (Directory.GetCurrentDirectory() == Directory.GetDirectoryRoot(path))
                        {
                            lbWarnings.Text = "Xa estás no root";
                        }
                        else
                        {
                            path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
                        }
                    }
                    else
                    {
                        path = Directory.GetCurrentDirectory().ToString() + "\\" + listBoxSubdirectorios.SelectedItem.ToString();
                    }
                    Directory.SetCurrentDirectory(path);
                    CambiarListBoxesSegunDirectorio();
                }
            }
            catch (System.Security.SecurityException)
            {
                lbWarnings.Text += "Non se pode acceder ao directorio seleccionado";
            }

        }

        private void ListBoxArquivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxArquivos.SelectedIndex != -1)
            {
                lbWarnings.Text = "";
                arquivo = new FileInfo(Directory.GetCurrentDirectory() + "\\" + listBoxArquivos.SelectedItem.ToString());
                float l = arquivo.Length;
                lbArquivoInfo.Text = "Tamaño en disco: " + (l < 1024 ? l + " B" : (l / 1024) < 1024 ? l / 1024 + " KB" : l / (1024 * 1024) < 1024 ? +l / (1024 * 1024) + " MB" : l / (1024 * 1024 * 1024) + " GB");
                if (arquivo.Extension == ".txt")
                {
                    string pathArquivo = arquivo.ToString();
                    Form2 f = new Form2(pathArquivo);
                    f.ShowDialog();
                }
            }
        }  

    private void TextBoxPathDirectorio_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            botonCambiarDirectorio.PerformClick();
        }
    }
}
}
