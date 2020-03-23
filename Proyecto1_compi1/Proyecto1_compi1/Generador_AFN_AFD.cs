using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_compi1
{
    class Generador_AFN_AFD
    {

        public List<string> Expresiones = new List<string>();
        public List<string> conjuntos = new List<string>();
        public List<string> tabla_simbolos = new List<string>();
        public List<string> d = new List<string>();

        public void Lista(List<string> Lista_Tokens) {
            tabla_simbolos = Lista_Tokens;
            exp();
            conjunto();
            Console.WriteLine("estas son las expresiones");
            for (int i=0;i<Expresiones.Count();i++) {
                Console.WriteLine(Expresiones[i]);
            }
            Console.WriteLine("estas son los conjuntos");
            for (int i = 0; i < conjuntos.Count(); i++) {
                Console.WriteLine(conjuntos[i]);
            }
        }
        public void exp() {
            string er = "";
            int sigue=0;
            int con = 0;
            for (int i = 0; i < tabla_simbolos.Count; i++)
            {
                string[] lista = tabla_simbolos[i].Split('@');
                if (lista[1] == "tk_conjunto")
                {
                    con = 1;
                }
                else if (lista[1] == "tk_puntocoma")
                {
                    con = 0;
                }
                if (lista[1] == "tk_cadena")
                {
                    er = lista[0];
                    sigue = 1;
                } else if (lista[1] == "tk_indicador" && sigue == 1 && con == 0) {
                    for (int m = i+1; m < tabla_simbolos.Count; m++)
                    {
                        lista = tabla_simbolos[m].Split('@');
                        if (lista[1]== "tk_puntocoma")
                        {
                            sigue = 0;
                            con = 0;
                            break;
                        }
                        else if(lista[1] == "tk_comilladoble")
                        {

                        }
                        else {
                            er += "@" + lista[0];
                        }
                    }
                    Expresiones.Add(er);
                 
                }
                
            }
        }
        public void conjunto()
        {
            string er = "";
            int sigue = 0;
            for (int i = 0; i < tabla_simbolos.Count; i++)
            {
                string[] lista = tabla_simbolos[i].Split('@');
                if (lista[1] == "tk_conjunto")
                {
                   
                    sigue = 1;
                }
                if (lista[1] == "tk_cadena" && sigue == 1)
                {
                    er = lista[0];
                    sigue++; 
                }
                if (lista[1]=="tk_indicador"&&sigue==2) {
                    int comas = 0;
                    int virgulia = 0;
                    for (int m = i+1; m < tabla_simbolos.Count; m++)
                    {
                        lista = tabla_simbolos[m].Split('@');
                        if (lista[1] == "tk_puntocoma")
                        {
                            break;
                        }
                        else
                        {
                            if (lista[1] == "tk_coma") {
                                comas++;
                            }
                            if (lista[1] == "tk_virgulia") {
                                virgulia++;
                            }
                            er += "@" + lista[0];
                        }
                    }

                    if (comas > 0) {

                        conjuntoex(er,0);
                    } else if (virgulia>0) {
                        conjuntoex(er, 1);
                    }
                }

            }
        }
        private void  conjuntoex(string datos,int tipo) {
            string[] dato = datos.Split('@');
            string expandido = "";
            int max = dato.Length-1;
            if (tipo == 0)
            {
                conjuntos.Add(datos);
            }
            else {
                expandido = dato[0];
                for (int i= Encoding.ASCII.GetBytes(dato[1])[0];i<= Encoding.ASCII.GetBytes(dato[max])[0];i++) {
                    expandido+="@"+Convert.ToChar(i).ToString();
                }
                conjuntos.Add(expandido);
            }
        }
    }
}
