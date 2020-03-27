using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_compi1
{
    class Dibujo_Dot
    {

        public void Archivo(string datos, string nombre)
        {
            
            FileStream archivo = new FileStream(@"C:\Users\José David\Documents\Visual Studio 2015\Projects\Proyecto1_compi1\Proyecto1_compi1\bin\Debug\Dot\" + nombre+".dot", FileMode.OpenOrCreate);
            archivo.Close();
            StreamWriter escribir = new StreamWriter(@"C:\Users\José David\Documents\Visual Studio 2015\Projects\Proyecto1_compi1\Proyecto1_compi1\bin\Debug\Dot\" + nombre + ".dot");
            escribir.WriteLine("digraph G { \n rankdir = \"LR\"");
            escribir.WriteLine(datos);
            escribir.WriteLine("}");
            escribir.Flush();
            escribir.Close();
            archivo.Close();
            comando(nombre);
            try
            {
                //se le da la ruta del archivo que se desea abrir
                Process.Start(@"C:\Users\José David\Documents\Visual Studio 2015\Projects\Proyecto1_compi1\Proyecto1_compi1\bin\Debug\Dot\" + nombre+".png");
              

            }
            catch (Exception e)
            {
                e.StackTrace.ToString();
            }
        }

        public void comando(string nombre)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine("cd Dot");
            cmd.StandardInput.WriteLine("dot -Tpng "+nombre+".dot -o "+nombre+".png");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }
    }
}
