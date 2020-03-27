using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_compi1
{
    class Archivotoken
    {
        public void Archivo(List<string> datos, string tipo)
        {
            if (tipo == "libre")
            {
                FileStream archivo = new FileStream(@"C:\Users\José David\Documents\Visual Studio 2015\Projects\Proyecto1_compi1\Proyecto1_compi1\bin\Debug\tokens.xlm", FileMode.OpenOrCreate);
                archivo.Close();
                StreamWriter escribir = new StreamWriter(@"C:\Users\José David\Documents\Visual Studio 2015\Projects\Proyecto1_compi1\Proyecto1_compi1\bin\Debug\tokens.xlm");
                escribir.WriteLine("< ListaTokens >");

                for (int i = 0; i < datos.Count; i++)
                {
                    string[] d = datos[i].Split('@');
                    escribir.WriteLine("< ListaTokens >");
                    escribir.WriteLine("< Token >");
                    escribir.WriteLine("< Nombre > " + d[1] + "</ Nombre >");
                    escribir.WriteLine(" < Valor >" + d[0] + "</ Valor >");
                    escribir.WriteLine("< Fila > " + d[2] + "</ Fila >");
                    escribir.WriteLine("< Columna >" + d[3] + "</ Columna >");
                    escribir.WriteLine(" </ Token >");

                }
                escribir.WriteLine("< /ListaTokens >");
                escribir.Flush();
                escribir.Close();
                archivo.Close();
            }
            else {
                FileStream archivo = new FileStream(@"C:\Users\José David\Documents\Visual Studio 2015\Projects\Proyecto1_compi1\Proyecto1_compi1\bin\Debug\errores.xlm", FileMode.OpenOrCreate);
                archivo.Close();
                StreamWriter escribir = new StreamWriter(@"C:\Users\José David\Documents\Visual Studio 2015\Projects\Proyecto1_compi1\Proyecto1_compi1\bin\Debug\errores.xlm");
                escribir.WriteLine("< ListaTokens >");

                for (int i = 0; i < datos.Count; i++)
                {
                    string[] d = datos[i].Split('@');
                    escribir.WriteLine("< ListaErrores >");
                    escribir.WriteLine(" <Error >");
                    escribir.WriteLine(" < Valor >" + d[0] + "</ Valor >");
                    escribir.WriteLine("< Fila > " + d[1] + "</ Fila >");
                    escribir.WriteLine("< Columna >" + d[2] + "</ Columna >");
                    escribir.WriteLine(" </ Error >");

                }
                escribir.WriteLine("< /ListaErrores >");
                escribir.Flush();
                escribir.Close();
                archivo.Close();

            }
        }
    }
}
