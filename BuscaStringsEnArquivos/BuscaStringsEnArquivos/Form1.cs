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
            Text = "Word finder";
            StreamReader sr;
            try
            {
                sr = new StreamReader(Environment.GetEnvironmentVariable("homepath") + "\\extensiones.txt");
                label5.Text += sr.ReadToEnd();
                sr.Close();
                //igual mejor usar File.exists que este metodo
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
                sr = new StreamReader(Environment.GetEnvironmentVariable("homepath") + "\\extensiones.txt");
                extensiones = sr.ReadToEnd();
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                extensiones = ".txt";
            }
            {
                using (sr = new StreamReader(arquivo.FullName))
                {
                    //no me lee el pdf que hice aunque le ponga la palabra. Puede detectar que es.pdf, pero no leer su contenido
                    if (sr.ReadToEnd().Contains(word, chkIgnoreCase.Checked ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) && extensiones.Contains(arquivo.Extension.ToString()))
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
                //Regex extensionCheck = new Regex(@"(.pdf|.txt|.doc|.docx|.docm|.odt|.rtf|.csv|.xls|.xlsx|.xlsm|.ods|.pps|.ppt|.ppsx|.pptx|.ppsm|.pptm|.potx|.odp)");
                string extensionesValidas = "";
                if (txbFileTracking.Text.Contains(","))
                {
                    string[] extensions = txbFileTracking.Text.Split(",");
                    //creo que el regex no me funciona del todo bien, igual deberia sudar de el
                    //y hacer que se pudiesen meter todo tipo de extensiones??
                    for (int i = 0; i < extensions.Length; i++)
                    {
                        extensionesValidas += "." + extensions[i].Trim();
                    }
                }
                else
                {
                    extensionesValidas = "." + txbFileTracking.Text.Trim();
                }
                using (StreamWriter sw = new StreamWriter(Environment.GetEnvironmentVariable("homepath") + "\\extensiones.txt"))
                {
                    sw.Write(extensionesValidas);
                }
            }
        }
    }
}