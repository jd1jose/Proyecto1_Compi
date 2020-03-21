using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

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
            int fila = 0;
            int columnas = 0;

            for (int i = 0; i < listado.Length; i++) {

                switch (estadoinicial) {
                    //letras
                    case 0:
                        if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 65 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 90 ||
                            Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 97 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 122)
                        {
                            if (token == "")
                            {
                                token = listado[i] + "";
                            }
                            else {
                                token += listado[i];
                            }

                        }
                        else if (Encoding.ASCII.GetBytes(listado[i] + "")[0] == 32 || Encoding.ASCII.GetBytes(listado[i] + "")[0] == 10)
                        {
                            if (token == "")
                            {
                               
                            }
                            else
                            {
                                Verificar(token,0);
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
                                if (token == "")
                                {
                                    
                                    token = listado[i] + "";
                                    estadoinicial = 2;
                                }
                                else
                                {
                                    Verificar(token,0);
                                    token = "";
                                    token = listado[i] + "";
                                    estadoinicial = 2;
                                }

                            }
                            else if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 48 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 57)
                            {
                                if (token == "")
                                {
                                    token = listado[i] + "";
                                    estadoinicial = 1;
                                }
                                else
                                {
                                    
                                    token += listado[i];
                                    estadoinicial = 0;
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
                            if (token=="") {
                                token = listado[i] + "";
                                estadoinicial = 1;
                            } else {
                                token += listado[i];
                                estadoinicial = 1;
                            }
                            
                        }
                        else
                        {
                            if (Encoding.ASCII.GetBytes(listado[i] + "")[0] == 32 || Encoding.ASCII.GetBytes(listado[i] + "")[0] == 10)
                            {

                                if (token == "")
                                {
                                    
                                }
                                else
                                {
                                    Verificar(token,1);
                                    token = "";
                                    estadoinicial = 0;
                                }
                            }
                            else if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 33 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 47 ||
                                     Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 58 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 64 ||
                                     Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 91 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 96 ||
                                     Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 123 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 126)
                            {
                                if (token == "")
                                {
                                    token = listado[i] + "";
                                    estadoinicial = 2;
                                }
                                else
                                {
                                    Verificar(token, 1);
                                    token = listado[i] + "";
                                    estadoinicial = 2;
                                }

                            }
                            else if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 65 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 90 ||
                                     Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 97 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 122)
                            {
                                if (token == "")
                                {
                                    token = listado[i] + "";
                                    estadoinicial = 0;
                                }
                                else
                                {
                                  //  Verificar(token, 0);
                                    token += listado[i];
                                    estadoinicial = 0;
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
                            Verificar(token, 2);
                            token = "";
                            estadoinicial = 3;
                        }
                        else if (token == "<" && listado[i] == '!')
                        {
                            token += listado[i];
                            Verificar(token, 2);
                            token = "";
                            estadoinicial = 4;
                        }
                        else if (token == "-" && listado[i] == '>')
                        {
                            token += listado[i];
                            Verificar(token, 2);
                            token = "";
                            estadoinicial = 0;
                        }
                        else
                        {
                            if (Encoding.ASCII.GetBytes(listado[i] + "")[0] == 32 || Encoding.ASCII.GetBytes(listado[i] + "")[0] == 10)
                            {

                                if (token == "")
                                {

                                }
                                else
                                {
                                    Verificar(token, 2);
                                    token = "";
                                    estadoinicial = 0;
                                }
                            }
                            else if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 65 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 90 ||
                                    Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 97 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 122)
                            {
                                if (token == "")
                                {
                                    token = listado[i] + "";
                                    estadoinicial = 0;
                                }
                                else
                                {
                                    Verificar(token, 2);
                                    token = listado[i] + "";
                                    estadoinicial = 0;
                                }
                            }
                            else if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 48 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 57)
                            {

                                if (token == "")
                                {
                                    token = listado[i] + "";
                                    estadoinicial = 1;
                                }
                                else
                                {
                                    Verificar(token, 2);
                                    token = listado[i] + "";
                                    estadoinicial = 1;
                                }
                            }
                            else if (Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 33 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 47 ||
                                    Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 58 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 64 ||
                                    Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 91 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 96 ||
                                    Encoding.ASCII.GetBytes(listado[i] + "")[0] >= 123 && Encoding.ASCII.GetBytes(listado[i] + "")[0] <= 126)
                            {
                                if (token=="") {

                                    Verificar(listado[i] + "", 2);
                                    token = "";
                                    estadoinicial = 0;
                                } else {
                                    Verificar(token, 0);
                                    Verificar(listado[i] + "", 2);
                                    token = "";
                                    estadoinicial = 0;


                                }
                               
                                
                            }

                            
                            else {
                                //Error
                            }
                        }
                        break;
                    //comentario de una linea
                    case 3:
                        if (Encoding.ASCII.GetBytes(listado[i] + "")[0] == 10)
                        {
                            Verificar(token, 3);
                            token = "";
                            estadoinicial = 0;
                        }
                        else {
                            token += listado[i];
                        }
                        break;
                    //comentario de varias lineas
                    case 4:
                        if (listado[i] == '!' && listado[i + 1] == '>')
                        {
                          
                            Verificar(token, 4);
                            token = "";
                            token = listado[i] + "" + listado[i + 1];
                            Verificar(token, 2);
                            token = "";
                            i++;
                            estadoinicial = 0;
                        }
                        else
                        {
                            token += listado[i];
                        }
                        break;
                        //fin del swhitch
                }
                //fin del for listado
            }
            for (int i=0; i<Tokens.Count;i++) {
                Console.WriteLine(Tokens[i]);
            }
           
        }

        private void Verificar(string token, int id)
        {
            if (token == ".") { Tokens.Add(token + "@ tk_concatenacion"); id = -1; }
            else if (token == "|") { Tokens.Add(token + "@ tk_or"); id = -1; }
            else if (token == "\\") { Tokens.Add(token + "@ tk_diagonal"); id = -1; }
            else if (token == "+") { Tokens.Add(token + "@ tk_mas"); id = -1; }
            else if (token == "*") { Tokens.Add(token + "@ tk_mul"); id = -1; }
            else if (token == "~") { Tokens.Add(token + "@ tk_virgulia"); id = -1; }
            else if (token == "{") { Tokens.Add(token + "@ tk_iniciollave"); id = -1; }
            else if (token == "}") { Tokens.Add(token + "@ tk_finllave"); id = -1; }
            else if (token == "<!") { Tokens.Add(token + "@ tk_iniciocomenmulti"); id = -1; }
            else if (token == "//") { Tokens.Add(token + "@ tk_iniciocomenlineal"); id = -1; }
            else if (token == "!>") { Tokens.Add(token + "@ tk_fincomenmulti"); id = -1; }
            else if (token == ";") { Tokens.Add(token + "@ tk_puntocoma"); id = -1; }
            else if (token == ":") { Tokens.Add(token + "@ tk_dospuntos"); id = -1; }
            else if (token == "-") { Tokens.Add(token + "@ tk_guion"); id = -1; }
            else if (token == "\"") { Tokens.Add(token + "@ tk_comilladoble"); id = -1; }
            else if (token == "<") { Tokens.Add(token + "@ tk_menorq"); id = -1; }
            else if (token == ">") { Tokens.Add(token + "@ tk_mayorq"); id = -1; }
            else if (token == "%") { Tokens.Add(token + "@ tk_porcentaje"); id = -1; }
            else
            {
                if (id==0) { Tokens.Add(token + "@ tk_cadena"); }
                else if (id == 1) { Tokens.Add(token + "@ tk_numero"); }
                else if (id == 2) { Tokens.Add(token + "@ tk_signo"); }
                else if (id == 3) { Tokens.Add(token + "@ tk_comentariolineal"); }
                else if (id == 4) { Tokens.Add(token + "@ tk_comentariomultilineal"); }
            }
        }
    }
}
