namespace Proyecto1_compi1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.B_abrir = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.console = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.B_anterior = new System.Windows.Forms.Button();
            this.B_siguiente = new System.Windows.Forms.Button();
            this.texto = new System.Windows.Forms.RichTextBox();
            this.analizarLexicamenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analisisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarElAFNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarElAFDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_abrir,
            this.guardarToolStripMenuItem,
            this.analizarLexicamenteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(754, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // B_abrir
            // 
            this.B_abrir.Name = "B_abrir";
            this.B_abrir.Size = new System.Drawing.Size(45, 20);
            this.B_abrir.Text = "Abrir";
            this.B_abrir.Click += new System.EventHandler(this.B_abrir_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(4, 338);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(371, 107);
            this.console.TabIndex = 2;
            this.console.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(419, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 218);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // B_anterior
            // 
            this.B_anterior.Location = new System.Drawing.Point(441, 286);
            this.B_anterior.Name = "B_anterior";
            this.B_anterior.Size = new System.Drawing.Size(75, 23);
            this.B_anterior.TabIndex = 4;
            this.B_anterior.Text = "Anterior";
            this.B_anterior.UseVisualStyleBackColor = true;
            // 
            // B_siguiente
            // 
            this.B_siguiente.Location = new System.Drawing.Point(571, 286);
            this.B_siguiente.Name = "B_siguiente";
            this.B_siguiente.Size = new System.Drawing.Size(75, 23);
            this.B_siguiente.TabIndex = 5;
            this.B_siguiente.Text = "Siguiente";
            this.B_siguiente.UseVisualStyleBackColor = true;
            this.B_siguiente.Click += new System.EventHandler(this.button2_Click);
            // 
            // texto
            // 
            this.texto.Location = new System.Drawing.Point(0, 27);
            this.texto.Name = "texto";
            this.texto.Size = new System.Drawing.Size(375, 282);
            this.texto.TabIndex = 6;
            this.texto.Text = "";
            // 
            // analizarLexicamenteToolStripMenuItem
            // 
            this.analizarLexicamenteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analisisToolStripMenuItem,
            this.generarElAFNToolStripMenuItem,
            this.generarElAFDToolStripMenuItem});
            this.analizarLexicamenteToolStripMenuItem.Name = "analizarLexicamenteToolStripMenuItem";
            this.analizarLexicamenteToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.analizarLexicamenteToolStripMenuItem.Text = "Acciones";
            // 
            // analisisToolStripMenuItem
            // 
            this.analisisToolStripMenuItem.Name = "analisisToolStripMenuItem";
            this.analisisToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.analisisToolStripMenuItem.Text = "Analisis";
            this.analisisToolStripMenuItem.Click += new System.EventHandler(this.analisisToolStripMenuItem_Click);
            // 
            // generarElAFNToolStripMenuItem
            // 
            this.generarElAFNToolStripMenuItem.Name = "generarElAFNToolStripMenuItem";
            this.generarElAFNToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.generarElAFNToolStripMenuItem.Text = "Generar el AFN";
            // 
            // generarElAFDToolStripMenuItem
            // 
            this.generarElAFDToolStripMenuItem.Name = "generarElAFDToolStripMenuItem";
            this.generarElAFDToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.generarElAFDToolStripMenuItem.Text = "Generar el AFD";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 457);
            this.Controls.Add(this.texto);
            this.Controls.Add(this.B_siguiente);
            this.Controls.Add(this.B_anterior);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.console);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem B_abrir;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button B_anterior;
        private System.Windows.Forms.Button B_siguiente;
        private System.Windows.Forms.RichTextBox texto;
        private System.Windows.Forms.ToolStripMenuItem analizarLexicamenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analisisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarElAFNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarElAFDToolStripMenuItem;
    }
}

