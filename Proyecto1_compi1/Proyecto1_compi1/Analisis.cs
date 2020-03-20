using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto1_compi1
{
    class Analisis
    {
        public List<string> Tokens = new List<string>();
        public List<string> palabras = new List<string>();

        public void Analisis_txt(string texto) {
            char[] listado = texto.ToArray();
            string token = "";
            int estadoinicial = 0;
         
            for (int i=0; i<listado.Length;i++) {

                switch (estadoinicial) {
                    //letras
                    case 0:
                        if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 65 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 90 ||
                            Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 97 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 122)
                        {
                            if (token != null)
                            {
                                token += listado[i];
                                estadoinicial = 0;
                            }
                            else
                            {
                                token = listado[i] + "";
                            }

                        }
                        else if (Encoding.ASCII.GetBytes(listado[i] + "")[0] == 32 || Encoding.ASCII.GetBytes(listado[i] + "")[0] == 10)
                        {
                            if (token != null) {
                                Verificar(token);
                                token = "";
                                estadoinicial = 0;
                            }
                        }
                        else {
                            if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 33 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 47 ||
                            Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 58 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 64 ||
                            Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 91 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 96 ||
                            Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 123 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 126)
                            {

                                if (token != null)
                                {
                                    Verificar(token);
                                    token = "";
                                    token += listado[i];
                                    estadoinicial = 2;
                                }
                                else
                                {
                                    token = listado[i] + "";
                                    estadoinicial = 2;
                                }
                            }
                            else if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 48 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 57)
                            {

                                if (token != null)
                                {
                                    Verificar(token);
                                    token = "";
                                    token += listado[i];
                                    estadoinicial = 1;
                                }
                                else
                                {
                                    token = listado[i] + "";
                                    estadoinicial = 1;
                                }
                            }
                            else { //error
                            }
                        }
                        break;
                    //numeros
                    case 1:
                        if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 48 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 57)
                        {

                            if (token != null)
                            {
                                Verificar(token);
                                token = "";
                                token += listado[i];
                                estadoinicial = 1;
                            }
                            else
                            {
                                token = listado[i] + "";
                                estadoinicial = 1;
                            }
                        }
                        else
                        {
                            if (Encoding.ASCII.GetBytes(listado[i] + "")[0] == 32 || Encoding.ASCII.GetBytes(listado[i] + "")[0] == 10)
                            {
                                if (token != null)
                                {
                                    Verificar(token);
                                    token = "";
                                    estadoinicial = 0;
                                }
                            }
                            else if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 33 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 47 ||
                       Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 58 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 64 ||
                       Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 91 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 96 ||
                       Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 123 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 126)
                            {

                                if (token != null)
                                {
                                    Verificar(token);
                                    token = "";
                                    token += listado[i];
                                    estadoinicial = 2;
                                }
                                else
                                {
                                    token = listado[i] + "";
                                    estadoinicial = 2;
                                }
                            }
                            else if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 65 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 90 ||
                                     Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 97 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 122)
                            {
                                if (token != null)
                                {
                                    token += listado[i];
                                    estadoinicial = 0;
                                }
                                else
                                {
                                    token = listado[i] + "";
                                }

                            }
                            else {
                                //error
                            }


                            //fin del else grande de case 1
                        }
                        break;
                        //signos
                    case 2:
                        if (token == "/" && listado[i] == '/')
                        {
                            token += listado[i];
                            Verificar(token);
                            token = "";
                            estadoinicial = 3;
                        }
                        else if(token== "<" && listado[i]=='!') {
                            token += listado[i];
                            Verificar(token);
                            token = "";
                            estadoinicial = 4;
                        }
                    break;


                    //fin del swhitch
                }
                //fin del for listado
            }
        }

        private void Verificar(string token)
        {
            
        }
    }
}
