namespace DirectoryFileManager
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxPathDirectorio = new System.Windows.Forms.TextBox();
            this.botonCambiarDirectorio = new System.Windows.Forms.Button();
            this.lbDirectorio = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listBoxSubdirectorios = new System.Windows.Forms.ListBox();
            this.lbIndicaDirectorioActual = new System.Windows.Forms.Label();
            this.listBoxArquivos = new System.Windows.Forms.ListBox();
            this.lbIndicaArquivos = new System.Windows.Forms.Label();
            this.lbArquivoInfo = new System.Windows.Forms.Label();
            this.lbSubdirectorios = new System.Windows.Forms.Label();
            this.lbWarnings = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPathDirectorio
            // 
            this.textBoxPathDirectorio.Location = new System.Drawing.Point(124, 6);
            this.textBoxPathDirectorio.Name = "textBoxPathDirectorio";
            this.textBoxPathDirectorio.Size = new System.Drawing.Size(240, 20);
            this.textBoxPathDirectorio.TabIndex = 0;
            this.textBoxPathDirectorio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxPathDirectorio_KeyDown);
            // 
            // botonCambiarDirectorio
            // 
            this.botonCambiarDirectorio.Location = new System.Drawing.Point(386, 4);
            this.botonCambiarDirectorio.Name = "botonCambiarDirectorio";
            this.botonCambiarDirectorio.Size = new System.Drawing.Size(75, 23);
            this.botonCambiarDirectorio.TabIndex = 1;
            this.botonCambiarDirectorio.Text = "Cambiar";
            this.botonCambiarDirectorio.UseVisualStyleBackColor = true;
            this.botonCambiarDirectorio.Click += new System.EventHandler(this.BotonCambiarDirectorio_Click);
            // 
            // lbDirectorio
            // 
            this.lbDirectorio.AutoSize = true;
            this.lbDirectorio.Location = new System.Drawing.Point(12, 9);
            this.lbDirectorio.Name = "lbDirectorio";
            this.lbDirectorio.Size = new System.Drawing.Size(106, 13);
            this.lbDirectorio.TabIndex = 2;
            this.lbDirectorio.Text = "Escriba un directorio:";
            this.toolTip1.SetToolTip(this.lbDirectorio, "Pódense escribir tamén variables de entorno");
            // 
            // listBoxSubdirectorios
            // 
            this.listBoxSubdirectorios.FormattingEnabled = true;
            this.listBoxSubdirectorios.Location = new System.Drawing.Point(12, 70);
            this.listBoxSubdirectorios.Name = "listBoxSubdirectorios";
            this.listBoxSubdirectorios.Size = new System.Drawing.Size(237, 147);
            this.listBoxSubdirectorios.TabIndex = 3;
            this.listBoxSubdirectorios.SelectedIndexChanged += new System.EventHandler(this.ListBoxSubdirectorios_SelectedIndexChanged);
            // 
            // lbIndicaDirectorioActual
            // 
            this.lbIndicaDirectorioActual.AutoSize = true;
            this.lbIndicaDirectorioActual.Location = new System.Drawing.Point(9, 229);
            this.lbIndicaDirectorioActual.Name = "lbIndicaDirectorioActual";
            this.lbIndicaDirectorioActual.Size = new System.Drawing.Size(0, 13);
            this.lbIndicaDirectorioActual.TabIndex = 4;
            // 
            // listBoxArquivos
            // 
            this.listBoxArquivos.FormattingEnabled = true;
            this.listBoxArquivos.Location = new System.Drawing.Point(255, 70);
            this.listBoxArquivos.Name = "listBoxArquivos";
            this.listBoxArquivos.Size = new System.Drawing.Size(237, 147);
            this.listBoxArquivos.TabIndex = 5;
            this.listBoxArquivos.SelectedIndexChanged += new System.EventHandler(this.ListBoxArquivos_SelectedIndexChanged);
            // 
            // lbIndicaArquivos
            // 
            this.lbIndicaArquivos.AutoSize = true;
            this.lbIndicaArquivos.Location = new System.Drawing.Point(256, 54);
            this.lbIndicaArquivos.Name = "lbIndicaArquivos";
            this.lbIndicaArquivos.Size = new System.Drawing.Size(51, 13);
            this.lbIndicaArquivos.TabIndex = 6;
            this.lbIndicaArquivos.Text = "Arquivos:";
            // 
            // lbArquivoInfo
            // 
            this.lbArquivoInfo.AutoSize = true;
            this.lbArquivoInfo.Location = new System.Drawing.Point(252, 229);
            this.lbArquivoInfo.Name = "lbArquivoInfo";
            this.lbArquivoInfo.Size = new System.Drawing.Size(0, 13);
            this.lbArquivoInfo.TabIndex = 7;
            // 
            // lbSubdirectorios
            // 
            this.lbSubdirectorios.AutoSize = true;
            this.lbSubdirectorios.Location = new System.Drawing.Point(12, 54);
            this.lbSubdirectorios.Name = "lbSubdirectorios";
            this.lbSubdirectorios.Size = new System.Drawing.Size(60, 13);
            this.lbSubdirectorios.TabIndex = 8;
            this.lbSubdirectorios.Text = "Directorios:";
            // 
            // lbWarnings
            // 
            this.lbWarnings.AutoSize = true;
            this.lbWarnings.ForeColor = System.Drawing.Color.Red;
            this.lbWarnings.Location = new System.Drawing.Point(124, 33);
            this.lbWarnings.Name = "lbWarnings";
            this.lbWarnings.Size = new System.Drawing.Size(0, 13);
            this.lbWarnings.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 323);
            this.Controls.Add(this.lbWarnings);
            this.Controls.Add(this.lbSubdirectorios);
            this.Controls.Add(this.lbArquivoInfo);
            this.Controls.Add(this.lbIndicaArquivos);
            this.Controls.Add(this.listBoxArquivos);
            this.Controls.Add(this.lbIndicaDirectorioActual);
            this.Controls.Add(this.listBoxSubdirectorios);
            this.Controls.Add(this.lbDirectorio);
            this.Controls.Add(this.botonCambiarDirectorio);
            this.Controls.Add(this.textBoxPathDirectorio);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPathDirectorio;
        private System.Windows.Forms.Button botonCambiarDirectorio;
        private System.Windows.Forms.Label lbDirectorio;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListBox listBoxSubdirectorios;
        private System.Windows.Forms.Label lbIndicaDirectorioActual;
        private System.Windows.Forms.ListBox listBoxArquivos;
        private System.Windows.Forms.Label lbIndicaArquivos;
        private System.Windows.Forms.Label lbArquivoInfo;
        private System.Windows.Forms.Label lbSubdirectorios;
        private System.Windows.Forms.Label lbWarnings;
    }
}

