namespace BuscaStringsEnArquivos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txbChooseDirectory = new System.Windows.Forms.TextBox();
            this.txbKeyWord = new System.Windows.Forms.TextBox();
            this.btnSearchWordInDirectory = new System.Windows.Forms.Button();
            this.txbResults = new System.Windows.Forms.TextBox();
            this.txbFileTracking = new System.Windows.Forms.TextBox();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txbChooseDirectory
            // 
            this.txbChooseDirectory.Location = new System.Drawing.Point(137, 21);
            this.txbChooseDirectory.Name = "txbChooseDirectory";
            this.txbChooseDirectory.Size = new System.Drawing.Size(100, 23);
            this.txbChooseDirectory.TabIndex = 0;
            // 
            // txbKeyWord
            // 
            this.txbKeyWord.Location = new System.Drawing.Point(137, 50);
            this.txbKeyWord.Name = "txbKeyWord";
            this.txbKeyWord.Size = new System.Drawing.Size(100, 23);
            this.txbKeyWord.TabIndex = 1;
            // 
            // btnSearchWordInDirectory
            // 
            this.btnSearchWordInDirectory.Location = new System.Drawing.Point(361, 21);
            this.btnSearchWordInDirectory.Name = "btnSearchWordInDirectory";
            this.btnSearchWordInDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnSearchWordInDirectory.TabIndex = 2;
            this.btnSearchWordInDirectory.Text = "Search";
            this.btnSearchWordInDirectory.UseVisualStyleBackColor = true;
            this.btnSearchWordInDirectory.Click += new System.EventHandler(this.BtnSearchWordInDirectory_Click);
            // 
            // txbResults
            // 
            this.txbResults.Location = new System.Drawing.Point(47, 99);
            this.txbResults.Multiline = true;
            this.txbResults.Name = "txbResults";
            this.txbResults.Size = new System.Drawing.Size(389, 124);
            this.txbResults.TabIndex = 3;
            // 
            // txbFileTracking
            // 
            this.txbFileTracking.Location = new System.Drawing.Point(47, 264);
            this.txbFileTracking.Name = "txbFileTracking";
            this.txbFileTracking.Size = new System.Drawing.Size(389, 23);
            this.txbFileTracking.TabIndex = 4;
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.AutoSize = true;
            this.chkIgnoreCase.Location = new System.Drawing.Point(361, 54);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(86, 19);
            this.chkIgnoreCase.TabIndex = 5;
            this.chkIgnoreCase.Text = "Ignore case";
            this.chkIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Key Word:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Results:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(342, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Add the extension of the files you want to track down next time";
            this.toolTip1.SetToolTip(this.label4, "In order to include an extension, you have to follow this format \".txt\" splitting" +
        " the extensions by commas if you want to add more than one");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(364, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Currently searching through the files with the following extensions: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 346);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkIgnoreCase);
            this.Controls.Add(this.txbFileTracking);
            this.Controls.Add(this.txbResults);
            this.Controls.Add(this.btnSearchWordInDirectory);
            this.Controls.Add(this.txbKeyWord);
            this.Controls.Add(this.txbChooseDirectory);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txbChooseDirectory;
        private TextBox txbKeyWord;
        private Button btnSearchWordInDirectory;
        private TextBox txbResults;
        private TextBox txbFileTracking;
        private CheckBox chkIgnoreCase;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ToolTip toolTip1;
    }
}