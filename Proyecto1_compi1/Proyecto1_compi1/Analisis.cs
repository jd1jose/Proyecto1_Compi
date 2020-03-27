using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Proyecto1_compi1;

namespace Proyecto1_compi1
{
    class Analisis
    {
        public List<string> Tokens = new List<string>();
        public List<string> error = new List<string>();
        private int errores = 0;
        public string consola = "";
        public string nombres = "";
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
                                Verificar(token, 0, fila, columnas);
                                token = "";
                                estadoinicial = 0;
                            }
                            if (Encoding.ASCII.GetBytes(listado[i] + "")[0] == 10)
                            {
                                fila++;
                                columnas = 0;
                            }
                            else { columnas++; }
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
                                                    Verificar(token, 0,fila,columnas);
                                                    columnas++;
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
                                MessageBox.Show("entra al error");
                                error.Add(listado[i] + "");
                                errores++;
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
                                    Verificar(token,1, fila, columnas);
                                    token = "";
                                    estadoinicial = 0;
                                }
                                if (Encoding.ASCII.GetBytes(listado[i] + "")[0] == 10)
                                {
                                    fila++;
                                    columnas = 0;
                                }
                                else { columnas++; }
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
                                    Verificar(token, 1, fila, columnas);
                                    columnas++;
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
                                error.Add(listado[i]+"");
                                errores++;
                            }


                            //fin del else grande de case 1
                        }
                        break;
                    //signos
                    case 2:
                        if (token == "/" && listado[i] == '/')
                        {
                            token += listado[i];
                            Verificar(token, 2, fila, columnas);
                            columnas++;
                            token = "";
                            estadoinicial = 3;
                        }
                        else if (token == "<" && listado[i] == '!')
                        {
                            token += listado[i];
                            Verificar(token, 2, fila, columnas);
                            columnas++;
                            token = "";
                            estadoinicial = 4;
                        }
                        else if (token == "-" && listado[i] == '>')
                        {
                            token += listado[i];
                            Verificar(token, 2, fila, columnas);
                            columnas++;
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
                                    Verificar(token, 2, fila, columnas);
                                    token = "";
                                    estadoinicial = 0;
                                }
                                if (Encoding.ASCII.GetBytes(listado[i] + "")[0] == 10)
                                {
                                    columnas = 0;
                                    fila++;
                                }
                                else { columnas++; }
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
                                    Verificar(token, 2, fila, columnas);
                                    columnas++;
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
                                    Verificar(token, 2, fila, columnas);
                                    columnas++;
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

                                    Verificar(listado[i] + "", 2,fila, columnas);
                                    columnas++;
                                    token = "";
                                    estadoinicial = 0;
                                } else {
                                    Verificar(token, 0, fila, columnas);
                                    columnas++;
                                    Verificar(listado[i] + "", 2, fila, columnas);
                                    columnas++;
                                    token = "";
                                    estadoinicial = 0;


                                }
                               
                                
                            }

                            
                            else {
                                //Error
                                error.Add(listado[i] + "");
                                errores++;
                            }
                        }
                        break;
                    //comentario de una linea
                    case 3:
                        if (Encoding.ASCII.GetBytes(listado[i] + "")[0] == 10)
                        {
                            Verificar(token, 3, fila, columnas);
                            fila++;
                            columnas = 0;
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
                          
                            Verificar(token, 4,fila,columnas);
                            columnas++;
                            token = "";
                            token = listado[i] + "" + listado[i + 1];
                            Verificar(token, 2, fila, columnas);
                            fila++;
                            columnas=0;
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
            Archivotoken archi = new Archivotoken();
            if (errores > 0)
            {
                MessageBox.Show("El Analisis termino con errores incluido");
                Console.WriteLine("los errores fueron");
                for (int i = 0; i < error.Count; i++)
                {

                    consola += error[i] + "\n";
                    Console.WriteLine(error[i]);
                }
                errores = 0;
                archi.Archivo(error,"erro");
                archi.Archivo(AFN(), "libre");
            }
            else {
                MessageBox.Show("el Analisis termino sin errores");
                for (int i = 0; i < Tokens.Count; i++)
                {
                    consola += Tokens[i] + "\n";
                    Console.WriteLine(Tokens[i]);
                }
                errores = 0;
               
                archi.Archivo(AFN(),"libre");
            }

           
        }
        public List<string> AFN(){
         
            return Tokens;
        }
        private void Verificar(string token, int id,int fila, int columna)
        {
            if (token == ".") { Tokens.Add(token + "@tk_concatenacion@"+fila+"@"+columna); id = -1; }
            else if (token == "|") { Tokens.Add(token + "@tk_or@" + fila + "@" + columna); id = -1; }
            else if (token == "CONJ") { Tokens.Add(token + "@tk_conjunto@" + fila + "@" + columna); id = -1; }
            else if (token == "\\") { Tokens.Add(token + "@tk_diagonal@" + fila + "@" + columna); id = -1; }
            else if (token == "+") { Tokens.Add(token + "@tk_masveces@" + fila + "@" + columna); id = -1; }
            else if (token == "*") { Tokens.Add(token + "@tk_ceromasveces@" + fila + "@" + columna); id = -1; }
            else if (token == "~") { Tokens.Add(token + "@tk_virgulia@" + fila + "@" + columna); id = -1; }
            else if (token == "{") { Tokens.Add(token + "@tk_iniciollave@" + fila + "@" + columna); id = -1; }
            else if (token == "}") { Tokens.Add(token + "@tk_finllave@" + fila + "@" + columna); id = -1; }
            else if (token == "<!") { Tokens.Add(token + "@tk_iniciocomenmulti@" + fila + "@" + columna); id = -1; }
            else if (token == "//") { Tokens.Add(token + "@tk_iniciocomenlineal@" + fila + "@" + columna); id = -1; }
            else if (token == "!>") { Tokens.Add(token + "@tk_fincomenmulti@" + fila + "@" + columna); id = -1; }
            else if (token == ",") { Tokens.Add(token + "@tkcoma@" + fila + "@" + columna); id = -1; }
            else if (token == ";") { Tokens.Add(token + "@tk_puntocoma@" + fila + "@" + columna); id = -1; }
            else if (token == ":") { Tokens.Add(token + "@tk_dospuntos@" + fila + "@" + columna); id = -1; }
            else if (token == "-") { Tokens.Add(token + "@tk_guion@" + fila + "@" + columna); id = -1; }
            else if (token == "\"") { Tokens.Add(token + "@tk_comilladoble@" + fila + "@" + columna); id = -1; }
            else if (token == "<") { Tokens.Add(token + "@tk_menorq@" + fila + "@" + columna); id = -1; }
            else if (token == ">") { Tokens.Add(token + "@tk_mayorq@" + fila + "@" + columna); id = -1; }
            else if (token == "%") { Tokens.Add(token + "@tk_porcentaje@" + fila + "@" + columna); id = -1; }
            else if (token == "?") { Tokens.Add(token + "@tk_interrogacion@" + fila + "@" + columna); id = -1; }
            else if (token == "->") { Tokens.Add(token + "@tk_indicador@" + fila + "@" + columna); id = -1; }
            else
            {
                if (id==0) {
                    if (Encoding.ASCII.GetBytes(token)[0] == 63)
                    {
                        error.Add(token);
                        errores++;
                    }
                    else
                    {
                        Tokens.Add(token + "@tk_cadena@" + fila + "@" + columna);
                    }

                }
                else if (id == 1) {
                    if (Encoding.ASCII.GetBytes(token)[0] == 63)
                    {
                        error.Add(token+"@"+fila + "@" + columna);
                        errores++;
                    }
                    else
                    {

                        Tokens.Add(token + "@tk_numero@" + fila + "@" + columna);
                    }
                }
                else if (id == 2) {
                    if (Encoding.ASCII.GetBytes(token)[0] == 63)
                    {
                        error.Add(token + "@" + fila + "@" + columna);
                        errores++;
                    }
                    else
                    {
                        Tokens.Add(token + "@tk_signo@" + fila + "@" + columna);
                    }
                   

                }
                else if (id == 3) {Tokens.Add(token + "@ tk_comentariolineal@" + fila + "@" + columna);}
                else if (id == 4) { Tokens.Add(token + "@ tk_comentariomultilineal@" + fila + "@" + columna); }
            }
        }
    }
}
