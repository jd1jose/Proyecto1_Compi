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

namespace Proyecto1_compi1
{
    public partial class Form1 : Form
    {
        Analisis d = new Analisis();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void B_abrir_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
       
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\documentos";
                openFileDialog.Filter = "er files (*.er)|*.er";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            texto.Text = fileContent;
            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);

        }

        private void analisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            d.Analisis_txt(texto.Text);
            

        }

        private void generarElAFNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string>Tokens=d.AFN();
            Generador_AFN_AFD vamos = new Generador_AFN_AFD();
            vamos.Lista(Tokens);
        
            string[] name = vamos.getname().Split(',');
            for (int i =1; i<name.Length;i++) {
                pictureBox1.Image = Image.FromFile(
                    @"C:\Users\José David\Documents\Visual Studio 2015\Projects\Proyecto1_compi1\Proyecto1_compi1\bin\Debug\Dot\" + name[i] + ".png");
                //  
            }

            //string imagePath = Path.Combine(Application.StartupPath, "Imágenes\\Movimientos\\Rey.jpg");

            //Picture.Image = Image.FromFile(imagePath);
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Filter = "All files (*er)|*.er";
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "";
            // filtros
            save.Filter = "Archivos de er (*.er)|*.er|Todos los archivos (*.*)|*.*";

            if (save.ShowDialog() == DialogResult.OK)
            {
                texto.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
