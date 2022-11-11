using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace BuscaStringsEnArquivos
{

    public delegate void Delegado(FileInfo arquivo, string palabra, TextBox resultados);
    public delegate void Delega(string texto, TextBox txtResult);
    public delegate void DelegaBorrador(TextBox txtResult);
    public partial class Form1 : Form
    {
        static private readonly object l;
        public Form1()
        {
            InitializeComponent();
            StreamReader sr;
            try
            {
                sr= new StreamReader(Environment.GetEnvironmentVariable("homedrive") + "\\extensiones.txt");
                label5.Text+= sr.ReadToEnd();
            }
            catch (FileNotFoundException)
            {
                label5.Text += ".txt";
            }
        }

        private void cambiaTexto(string texto, TextBox txtResult)
        {
            txtResult.AppendText(texto + Environment.NewLine);
        }
        private void suprimeTexto(TextBox txtResult)
        {
            txtResult.Clear();
        }
        public void encuentraPalabra(FileInfo arquivo, string word, TextBox txbResu)
        {
            StreamReader sr;
            string extensiones;
            try
            {            
                sr = new StreamReader(Environment.GetEnvironmentVariable("homedrive") + "\\extensiones.txt");
                extensiones = sr.ReadToEnd();
            }
            catch (FileNotFoundException)
            {
                extensiones = ".txt";
            }
            
            {
                using (sr = new StreamReader(arquivo.FullName))
                {
                    if (sr.ReadToEnd().Contains(word, chkIgnoreCase.Checked ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) && extensiones.Contains(arquivo.Extension))
                    {
                        Delega d = cambiaTexto;
                        Invoke(d, arquivo.Name, txbResu);
                    }
                }
            }
        }

        private void BtnSearchWordInDirectory_Click(object sender, EventArgs e)
        {
            DelegaBorrador d = suprimeTexto;
            Invoke(d, txbResults);
            string path = txbChooseDirectory.Text;
            string word = txbKeyWord.Text;
            DirectoryInfo directorio = new DirectoryInfo(path);
            foreach (FileInfo arquivo in directorio.GetFiles())
            {
                Thread thread = new Thread(() => encuentraPalabra(arquivo, txbKeyWord.Text, txbResults));
                thread.Start();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txbFileTracking.Text != "")
            {
                
                Regex extensionCheck= new Regex(@"^.*.(pdf|txt|doc|docx|docm|odt|rtf|csv|xls|xlsx|xlsm|ods|pps|ppt|ppsx|pptx|ppsm|pptm|potx|odp)");
                string[] extensions = txbFileTracking.Text.Split(",");
                string extensionesValidas="";
                foreach (string extension in extensions)
                {
                   if( extensionCheck.IsMatch(extension) && true /*comprobar si no está ya en el archivo */)
                    {
                        extensionesValidas += extension + ",";
                    }
                }
                try
                {
                    StreamWriter sw = new StreamWriter(Environment.GetEnvironmentVariable("homedrive") + "\\extensiones.txt");
                    sw.Write(extensionesValidas);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}